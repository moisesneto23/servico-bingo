using Microsoft.AspNetCore.Builder;
using OrcamentoGenerico.Api.Configuracoes;
using OrcamentoGenerico.Api.Configuracoes.EcessaoRandler;
using System.Text.Json.Serialization;

namespace servico_bingo
{
    public class Startup
    {
        //private readonly string _myAllowSpecificOrigins = "MyAllowSpecificOrigins";
        public readonly IConfiguration _configuration;

        public Startup(IConfiguration configuration)
        {
            _configuration = configuration;
        }


        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            //var connectionString = _configuration.GetConnectionString("OfertarConcursosDatabase");
            //services.AddDbContext<ContextoConfig>(options =>
            //  options.UseSqlServer(connectionString));

            services.AddControllers()
                .AddJsonOptions(options =>
                {
                    options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
                });
            //services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            services.AddSwaggerConfiguration(_configuration);
            //services.AddHealthCheckConfig(_configuration);
            //services.ConfigureDependencyInjection(_configuration);
            //services.AddFilterConfig(); depois ver como implementar as permissões de usuario
            //services.AddAuthenticationConfig(_configuration);
            //services.AddHttpContextAccessor();
            /*services.AddCors(options =>
            {
                options.AddPolicy(name: _myAllowSpecificOrigins,
                                  builder =>
                                  {
                                      builder
                                        .AllowAnyOrigin()
                                        .AllowAnyHeader()
                                        .AllowAnyMethod();
                                  });
            });*/
            services.AddCors();

            //_configuration.AddSerilogConfig();
        }


        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, ILoggerFactory loggerFactory)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            if (env.IsEnvironment("producao") is false)
            {
                app.UseSwaggerConfig(_configuration);
            }

            app.UseCors(x => x
               .AllowAnyOrigin()
               .AllowAnyMethod()
               .AllowAnyHeader());

            app.UseHttpsRedirection();

            app.UseRouting();

            //app.UseAuthentication();

            //app.UseAuthorization();
            //pesquisar o que é esses middlwares
            //app.UseMiddleware<EnableRequestRewindMiddleware>();
            //app.UseMiddleware<JwtTokenIdentityMiddleware>();

            //pesquisar o que esse metodo faz
            //app.UseExceptionHandler(env, loggerFactory);

            //app.UseCors(_myAllowSpecificOrigins);

            //ApplicationContext.Configure(app.ApplicationServices.GetRequiredService<IHttpContextAccessor>());

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                //endpoints.MapHealthChecks(_configuration["HealthCheck:Path"]);
            });
        }
    }
}
