using AutoMapper;
using Desconto.Grpc.Entities;
using Desconto.Grpc.Protos;
using Desconto.Grpc.Repository;
using Grpc.Core;

namespace Desconto.Grpc.Services
{
    public class DescontoService : DescontoProtoService.DescontoProtoServiceBase
    {
        private readonly IDescontoRepository _descontoRepository;
        private readonly IMapper _mapper;

        public DescontoService(IDescontoRepository descontoRepository, IMapper mapper)
        {
            _descontoRepository = descontoRepository ?? throw new ArgumentNullException(nameof(descontoRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public override async Task<CupomModel> GetDesconto(GetDescontoRequest request, ServerCallContext context)
        {
            var cupom = _descontoRepository.GetDesconto(request.NomeProduto);

            if (cupom is null)
                throw new RpcException(new Status(StatusCode.NotFound, 
                    $"Desconto com NomeProduto = {request.NomeProduto} não encontrado"));

            return _mapper.Map<CupomModel>(cupom);                
        }

        public override async Task<CupomModel> CreateDesconto(CreateDescontoRequest request, ServerCallContext context)
        {
            var cupom = _mapper.Map<Cupom>(request.Cupom);
            await _descontoRepository.CreateDesconto(cupom);

            return _mapper.Map<CupomModel>(cupom);
        }

        public override async Task<CupomModel> UpdateDesconto(UpdateDescontoRequest request, ServerCallContext context)
        {
            var cupom = _mapper.Map<Cupom>(request.Cupom);
            await _descontoRepository.UpdatetDesconto(cupom);

            return _mapper.Map<CupomModel>(cupom);
        }

        public override async Task<DeleteDescontoResponse> DeleteDesconto(DeleteDescontoRequest request, ServerCallContext context)
        {
            var excluido = await _descontoRepository.DeleteDesconto(request.NomeProduto);
            return new DeleteDescontoResponse() { Success = excluido };
        }
    }
}
