//using Serilog;
//using Serilog.Events;
//using Serilog.Exceptions;
//using Serilog.Sinks.Elasticsearch;

//namespace OrcamentoGenerico.Api.Configuracoes
//{

//    internal static class SerilogConfig
//    {
//        public static IConfiguration AddSerilogConfig(this IConfiguration configuration)
//        {
//            LogEventLevel minimumLevelDefault = GetLogEventLevel(configuration["Logging:MinLoggingLevel"]);

//            LogEventLevel minimumLevelConsoleDefault = GetLogEventLevel(configuration["Logging:MinLoggingLevelConsole"]);

//            Log.Logger = GetLoggerConfiguration(configuration, minimumLevelDefault, minimumLevelConsoleDefault)
//                .CreateLogger();

//            return configuration;
//        }

//        private static LogEventLevel GetLogEventLevel(string value)
//        {
//            LogEventLevel response;
//            response = Enum.TryParse(value, true, out response) ? response : LogEventLevel.Warning;
//            return response;
//        }

//        private static LoggerConfiguration GetLoggerConfiguration(IConfiguration configuration, LogEventLevel minimumLevelDefault, LogEventLevel minimumLevelConsoleDefault)
//        {
//            return new LoggerConfiguration()
//                .MinimumLevel.Is(minimumLevelDefault)
//                .MinimumLevel.Override("Microsoft", LogEventLevel.Information)
//                .MinimumLevel.Override("System", LogEventLevel.Error)
//                .Enrich.WithProperty("Application", configuration["Application:ApplicationName"])
//                .Enrich.WithProperty("Environment", Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT"))
//                .Enrich.FromLogContext()
//                .Enrich.WithExceptionDetails()
//                .Enrich.WithMachineName()
//                .WriteTo.Console(restrictedToMinimumLevel: minimumLevelConsoleDefault)
//                .WriteTo.Elasticsearch(new ElasticsearchSinkOptions(new Uri(configuration.GetConnectionString("LogElasticSource")))
//                {
//                    MinimumLogEventLevel = minimumLevelDefault,
//                    IndexFormat = configuration["ElasticSearch:IndexFormat"]
//                });
//        }
//    }
//}
