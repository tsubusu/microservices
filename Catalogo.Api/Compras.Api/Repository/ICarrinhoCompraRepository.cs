using Compras.Api.Entities;

namespace Compras.Api.Repository
{
    public interface ICarrinhoCompraRepository
    {
        Task<CarrinhoCompra> ObterCarrinhoCompra(string nomeUsuario);
        Task<CarrinhoCompra> AtualizarCarrinhoCompra(CarrinhoCompra carrinhoCompra);
        Task ExcluirCarrinhoCompra(string nomeUsuario);
    }
}
