using Compras.Api.Repository;

namespace Catalogo.Api.Config
{
    public static class InjecaoDependenciaConfig
    {
        public static void CriarInjecao(IServiceCollection services)
        {
            services.AddScoped<ICarrinhoCompraRepository, CarrinhoCompraRepository>();
        }
    }
}
