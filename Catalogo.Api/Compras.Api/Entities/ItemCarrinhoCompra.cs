namespace Compras.Api.Entities
{
    public class ItemCarrinhoCompra
    {
        public int IdProduto { get; set; }
        public string NomeProduto { get; set; }
        public int Quantidade { get; set; }
        public decimal Preco { get; set; }
    }
}
