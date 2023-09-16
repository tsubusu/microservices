using Compras.Api.GrpcServices;
using Compras.Api.Repository;
using Desconto.Grpc.Protos;

namespace Catalogo.Api.Config
{
    public static class InjecaoDependenciaConfig
    {
        public static void CriarInjecao(IServiceCollection services, IConfiguration configuration)
        {
            services.AddGrpcClient<DescontoProtoService.DescontoProtoServiceClient>(
                options => options.Address = new Uri(configuration["GrpcSettings:DescontoUrl"]));
            services.AddScoped<DescontoGrpcService>();
            services.AddScoped<ICarrinhoCompraRepository, CarrinhoCompraRepository>();
        }
    }
}
