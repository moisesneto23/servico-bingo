using Microsoft.OpenApi.Models;

namespace OrcamentoGenerico.Api.Configuracoes
{
    public static class SwaggerConfig
    {
        public static void AddSwaggerConfiguration(this IServiceCollection services, IConfiguration configuration)
        {
            if (services == null) throw new ArgumentNullException(nameof(services));

            var applicationName = GetApplicationName(configuration);
            var applicationDescription = GetApplicationDescription(configuration);

            services.AddSwaggerGen(s =>
            {
                s.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = applicationName,
                    Description = applicationDescription,
                });

                s.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Description = "Inclua no campo abaixo a palavra 'Bearer' seguida de espaço e do token JWT",
                    Name = "Authorization",
                    Scheme = "Bearer",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.ApiKey
                });

                s.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "Bearer"
                            }
                        },
                        new string[] {}
                    }
                });
                //s.EnableAnnotations();
            });
        }

        public static void UseSwaggerConfig(this IApplicationBuilder app, IConfiguration configuration)
        {
            if (app == null) throw new ArgumentNullException(nameof(app));

            //string routerPrefix = Environment.GetEnvironmentVariable("VIRTUAL_PATH") ?? String.Empty;
            //var applicationName = GetApplicationName(configuration);

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
                //c.SwaggerEndpoint($"{routerPrefix}/swagger/v1/swagger.json", applicationName);
                //c.RoutePrefix = string.Empty;
            });
        }

        private static IConfigurationSection GetApplicationParameters(IConfiguration configuration)
        {
            return configuration.GetSection("Application");
        }

        private static string GetApplicationName(IConfiguration configuration)
        {
            var applicationParameters = GetApplicationParameters(configuration);
            return applicationParameters.GetValue<string>("ApplicationName");
        }

        private static string GetApplicationDescription(IConfiguration configuration)
        {
            var applicationParameters = GetApplicationParameters(configuration);
            return applicationParameters.GetValue<string>("applicationDescription");
        }
    }

}
