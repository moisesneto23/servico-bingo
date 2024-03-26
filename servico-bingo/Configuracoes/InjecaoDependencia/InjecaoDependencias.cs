using OrcamentoGenerico.Api.Configuracoes.UnitOfWorkConfig;
using Microsoft.EntityFrameworkCore;
using OrcamentoGenerico.Api.Configuracoes.Contexto;


using OrcamentoGenerico.Api.Configuracoes.Notifications;



namespace OrcamentoGenerico.Api.Configuracoes
{
    public static class InjecaoDependencias
    {
        public static IServiceCollection ConfigureDependencyInjection(this IServiceCollection services, IConfiguration configuration)
        {
            //RegisterOfertarConcursosContext(services, configuration);
            RegisterNotificationContext(services);
            RegisterUoW(services);
            RegisterApplication(services);
            //RegisterMappingsProfile(services);
            RegisterRepositories(services);
            RegisterServices(services);

            return services;
        }

        public static void RegisterOfertarConcursosContext(IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("Conexao");
            services.AddDbContext<ContextoConfig>(options =>
              options.UseSqlServer(connectionString));
        }

        private static void RegisterNotificationContext(IServiceCollection services)
        {
            services.AddScoped<NotificationContext>();
        }

        private static void RegisterUoW(IServiceCollection services)
        {
            services.AddScoped<IUnitOfWork, UnitOfWork>();
        }

        private static void RegisterApplication(IServiceCollection services)
        {

            //services.AddScoped<IEmpresaAplication, EmpresaAplication>();
            //services.AddScoped<ICategoriaItemAplication, CategoriaItemAplication>();
            //services.AddScoped<IItemAplication, ItemAplication>();

            //services.AddScoped<ICategoriaProdutoAplication, CategoriaProdutoAplication>();
            //services.AddScoped<IItemProdutoAplication, ItemProdutoAplication>();
            //services.AddScoped<IProdutoAplication, ProdutoAplication>();

        }

        public static void RegisterServices(IServiceCollection services)
        {
            //services.AddScoped<IEmpresaService, EmpresaService>();
            //services.AddScoped<IUsuarioService, UsuarioService>();
            //services.AddScoped<IColaboradorService, ColaboradorService>();
            //services.AddScoped<ICategoriaItemService, CategoriaItemService>();
            //services.AddScoped<IItemService, ItemService>();

            //services.AddScoped<ICategoriaProdutoService, CategoriaProdutoService>();
            //services.AddScoped<IItemProdutoService, ItemProdutoService>();
            //services.AddScoped<IProdutoService, ProdutoService>();

        }
        public static void RegisterRepositories(IServiceCollection services)
        {
            //services.AddScoped<IEmpresaRepository, EmpresaRepository>();
    
            //services.AddScoped<IUsuarioRepository, UsuarioRepository>();
            //services.AddScoped<IColaboradorRepository, ColaboradorRepository>();
            //services.AddScoped<ICategoriaItemRepository, CategoriaRepository>();
            //services.AddScoped<IItemRepository, ItemRepository>();

            //services.AddScoped<ICategoriaProdutosRepository, CategoriaProdutosRepository>();
            //services.AddScoped<IProdutoItemDimencaoRepository, ProdutoItemDimencaoRepository>();
            //services.AddScoped<IProdutoRepository, ProdutoRepository>();


        }

        /*public static void RegisterMappingsProfile(IServiceCollection services)
        {
            services.AddAutoMapper(typeof(DomainToDTOProfile));
        }*/

    }
}
