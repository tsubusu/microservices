using Desconto.Api.Entities;

namespace Desconto.Api.Repository
{
    public interface IDescontoRepository
    {
        Task<Cupom> GetDesconto(string nomeProduto);
        Task<bool> CreateDesconto(Cupom cupom);
        Task<bool> UpdatetDesconto(Cupom cupom);
        Task<bool> DeleteDesconto(string nomeProduto);
    }
}
