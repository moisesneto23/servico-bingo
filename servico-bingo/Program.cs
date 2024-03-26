using servico_bingo;

public class Program
{
    public static void Main(string[] args)
    {
        CreateHostBuilder(args).Build().Run();
    }

    public static IHostBuilder CreateHostBuilder(string[] args) =>
        Host.CreateDefaultBuilder(args)
         .ConfigureWebHostDefaults(webBuilder =>
         {
             webBuilder.UseStartup<Startup>();
         });
    /*.ConfigureAppConfiguration((ctx, config) =>
    {
        if (ctx.HostingEnvironment.EnvironmentName is "desenvolvimento" or "local")
        {
            config.AddUserSecrets<Program>(true);
        }
    })
    .ConfigureWebHostDefaults(webBuilder => { webBuilder.UseStartup<Startup>(); })
    .AddConfigServer()
    .UseSerilog();*/
}
