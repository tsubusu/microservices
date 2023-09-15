using Desconto.Grpc.Data;
using Desconto.Grpc.Repository;

namespace Desconto.Grpc.Config
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
