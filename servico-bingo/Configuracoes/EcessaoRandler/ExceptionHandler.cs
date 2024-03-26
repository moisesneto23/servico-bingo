using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using SendGrid.Helpers.Errors.Model;
using System.Net;
using System.Text;
using System.Text.Json;

namespace OrcamentoGenerico.Api.Configuracoes.EcessaoRandler
{
    public static class ExceptionHandler
    {
        public static void UseExceptionHandler(this IApplicationBuilder app, IWebHostEnvironment env, ILoggerFactory loggerFactory)
        {
            app.UseExceptionHandler(appError =>
            {
                appError.Run(async context =>
                {
                    context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                    context.Response.ContentType = "application/json";

                    // Faço o tratamento de erros e adiciono o erro no objeto do response que será capturado pelo middleware de RequestResponse
                    var contextFeature = context.Features.Get<IExceptionHandlerFeature>();

                    if (contextFeature != null)
                    {
                        RegisterLog(context.Request, loggerFactory, contextFeature.Error);
                        await HandleExceptionAsync(context, contextFeature.Error, env);
                    }

                });
            });
        }

        private static Task HandleExceptionAsync(HttpContext context, Exception exception, IWebHostEnvironment env)
        {
            var response = ExceptionResponseFactory.Create(context, exception, env);

            var result = JsonSerializer.Serialize(response.Details);
            context.Response.ContentType = response.ContentType;
            context.Response.StatusCode = response.Details.Status.Value;
            return context.Response.WriteAsync(result);
        }

        private static void RegisterLog(HttpRequest req, ILoggerFactory loggerFactory, Exception ex)
        {
            var logger = loggerFactory.CreateLogger("ExceptionHandler");

            var args = SetArgs(req);
            logger.LogError(ex, "Method:{Method}; Path {Path}; Body {Body}", args);
        }

        private static object[] SetArgs(HttpRequest req)
        {
            var args = new string[3];
            args[0] = req.Method;
            args[1] = req.Path;
            req.Body.Position = 0;
            if (req.ContentLength is null)
                return args;

            using (StreamReader reader
                  = new StreamReader(req.Body, Encoding.UTF8, true, 1024, true))
            {
                args[2] = reader.ReadToEnd();
            }

            return args;
        }

        private static class ExceptionResponseFactory
        {
            public static ExceptionResponse Create(HttpContext context, Exception exception, IWebHostEnvironment env)
            {
                var isProduction = env.IsEnvironment("producao");
                var errorCode = string.Empty;
                var statusCode = ObterStatusCode(exception);

                var detail = exception.Message.Replace($"{Environment.NewLine}", " ");

                var details = new ProblemDetails
                {
                    Title = statusCode.ToString(),
                    Instance = context.Request.Path,
                    Detail = detail,
                    Status = (int)statusCode,
                    Type = "about:blank",
                };

                details.Extensions.Add("ErrorCode", errorCode);
                details.Extensions.Add("TraceId", context.TraceIdentifier);
                if (isProduction is false)
                    details.Extensions.Add("Exception", exception.ToString());

                return new ExceptionResponse(details, "application/json", details.Status.Value);
            }

            private static int ObterStatusCode(Exception ex)
            {
                switch (ex)
                {
                    case BadRequestException _:
                    case EntityValidationException _:
                        return (int)HttpStatusCode.BadRequest;
                    case NotFoundException _:
                        return (int)HttpStatusCode.NotFound;
                    case UnauthorizedException _:
                        return (int)HttpStatusCode.Unauthorized;
                    case ForbiddenException _:
                        return (int)HttpStatusCode.Forbidden;
                    case ServiceUnavailableException _:
                        return (int)HttpStatusCode.ServiceUnavailable;
                    case InternalServerErrorException _:
                        return (int)HttpStatusCode.InternalServerError;
                    case StatusCodeException _:
                        return GetGenericStatusCode(ex.Message);
                    default:
                        return (int)HttpStatusCode.InternalServerError;
                }
            }

            private static int GetGenericStatusCode(string exMessage)
            {
                var croped = CropStatusCodeFromMessage(exMessage).Trim();
                croped = croped.Replace("_$!_", string.Empty);

                return int.Parse(croped);
            }

            private static string CropStatusCodeFromMessage(string message)
            {
                return message.Substring(0, 12);
            }
        }

        private class ExceptionResponse
        {
            public ExceptionResponse(ProblemDetails details, string contentType, int? statusCode)
            {
                ContentType = contentType;
                StatusCode = statusCode;
                Details = details;
            }
            public string ContentType { get; }
            public int? StatusCode { get; }
            public ProblemDetails Details { get; }
        }
    }
}
