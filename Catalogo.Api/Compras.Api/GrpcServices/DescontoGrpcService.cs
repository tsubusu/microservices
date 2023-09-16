using Desconto.Grpc.Protos;

namespace Compras.Api.GrpcServices
{
    public class DescontoGrpcService
    {
        private readonly DescontoProtoService.DescontoProtoServiceClient _descontoProtoService;

        public DescontoGrpcService(DescontoProtoService.DescontoProtoServiceClient descontoProtoService)
        {
            _descontoProtoService = descontoProtoService ?? throw new ArgumentNullException(nameof(descontoProtoService));
        }

        public async Task<CupomModel> GetDesconto(string nomeProduto)
        {
            var descontoRequest = new GetDescontoRequest() { NomeProduto = nomeProduto };
            return await _descontoProtoService.GetDescontoAsync(descontoRequest);
        }
    }
}
