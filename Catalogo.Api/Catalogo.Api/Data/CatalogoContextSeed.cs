using Catalogo.Api.Entities;
using MongoDB.Driver;

namespace Catalogo.Api.Data
{
    public class CatalogoContextSeed
    {
        public static void SeedData(IMongoCollection<Produto> produtosCollection)
        {
            var existProduto = produtosCollection.Find(p => true).Any();

            if (!existProduto)
            {
                produtosCollection.InsertManyAsync(CriarProdutos());
            }
        }

        private static IEnumerable<Produto> CriarProdutos()
        {
            var produtos = new List<Produto>() { };

            for (int i = 0; i < 10; i++)
            {
                produtos.Add(
                    new Produto()
                    {
                        //Id = "1234" + i,
                        Nome = "Nome Teste " + i,
                        Categoria = "Categoria Teste " + i,
                        Descricao = "Descricao Teste " + i,
                        Imagem = "Imagem Teste " + i,
                        Preco = 10.01M + i
                    });
            }

            return produtos;
        }
    }
}
