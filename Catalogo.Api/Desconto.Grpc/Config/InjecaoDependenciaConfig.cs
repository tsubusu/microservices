using AutoMapper;
using Desconto.Grpc.Data;
using Desconto.Grpc.Mapper;
using Desconto.Grpc.Repository;

namespace Desconto.Grpc.Config
{
    public static class InjecaoDependenciaConfig
    {
        public static void CriarInjecao(IServiceCollection services)
        {
            services.AddScoped<IContexto, Contexto>();
            services.AddScoped<IDescontoRepository, DescontoRepository>();

            var mapperConfig = new MapperConfiguration(cfg =>
            {
                // Adicione seus profiles de mapeamento aqui
                cfg.AddProfile<DescontoProfile>();
                // Adicione outros profiles, se necessário
            });
            IMapper mapper = mapperConfig.CreateMapper();
            services.AddSingleton(mapper);
        }
    }
}
