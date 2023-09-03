using Catalogo.Api.Data;
using Catalogo.Api.Entities;
using MongoDB.Driver;

namespace Catalogo.Api.Repository
{
    public class ProdutoRepository : IProdutoRepository
    {
        private readonly ICatalogoContext _context;
        private readonly IMongoCollection<Produto> _produtoContext;
        public ProdutoRepository(ICatalogoContext context)
        {
            _context = context;
            _produtoContext = context.Produtos;
        }

        public async Task<bool> AtualizarProduto(Produto produto)
        {
            var resultadoAtualizar = await _produtoContext.ReplaceOneAsync(filter: x => x.Id.Equals(produto.Id), replacement: produto);
            return resultadoAtualizar.IsAcknowledged && resultadoAtualizar.ModifiedCount > 0;
        }

        public async Task CriarProduto(Produto produto)
        {
            await _produtoContext.InsertOneAsync(produto);
        }

        public async Task<bool> ExcluirProduto(string id)
        {
            var resultadoDelete = await _produtoContext.DeleteOneAsync(x => x.Id.Equals(id));
            return resultadoDelete.IsAcknowledged && resultadoDelete.DeletedCount > 0;
        }

        public async Task<Produto> ObterProduto(string id)
        {
            var filtro = Builders<Produto>.Filter.Eq(x => x.Id, id);
            return await _produtoContext.Find(filtro).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<Produto>> ObterProdutosPorCategoria(string categoria)
        {
            return await _produtoContext.Find(x => x.Categoria.Equals(categoria)).ToListAsync();
        }

        public async Task<IEnumerable<Produto>> ObterProdutoPorNome(string nome)
        {
            var filtro = Builders<Produto>.Filter.ElemMatch(x => x.Nome, nome);
            return await _produtoContext.Find(filtro).ToListAsync();
        }

        public async Task<IEnumerable<Produto>> ObterProdutos()
        {
            return await _produtoContext.Find(x => true).ToListAsync();
        }
    }
}
