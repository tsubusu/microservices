using Catalogo.Api.Entities;

namespace Catalogo.Api.Repository
{
    public interface IProdutoRepository
    {
        Task<IEnumerable<Produto>> ObterProdutos();
        Task<Produto> ObterProduto(string id);
        Task<IEnumerable<Produto>> ObterProdutoPorNome(string name);
        Task<IEnumerable<Produto>> ObterProdutosPorCategoria(string name);
        Task CriarProduto(Produto produto);
        Task<bool> AtualizarProduto(Produto produto);
        Task<bool> ExcluirProduto(string id);
    }
}
