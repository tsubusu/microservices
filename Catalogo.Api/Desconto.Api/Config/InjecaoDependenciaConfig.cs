using Desconto.Api.Data;
using Desconto.Api.Repository;

namespace Desconto.Api.Config
{
    public static class InjecaoDependenciaConfig
    {
        public static void CriarInjecao(IServiceCollection services)
        {
            services.AddScoped<IContexto, Contexto>();
            services.AddScoped<IDescontoRepository, DescontoRepository>();
        }
    }
}
