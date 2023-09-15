using Desconto.Grpc.Entities;

namespace Desconto.Grpc.Repository
{
    public interface IDescontoRepository
    {
        Task<Cupom> GetDesconto(string nomeProduto);
        Task<bool> CreateDesconto(Cupom cupom);
        Task<bool> UpdatetDesconto(Cupom cupom);
        Task<bool> DeleteDesconto(string nomeProduto);
    }
}
