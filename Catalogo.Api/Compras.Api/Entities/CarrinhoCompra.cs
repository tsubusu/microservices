namespace Compras.Api.Entities
{
    public class CarrinhoCompra
    {
        public CarrinhoCompra()
        {

        }

        public CarrinhoCompra(string nomeUsuario)
        {
            NomeUsuario = nomeUsuario;
        }

        public string NomeUsuario { get; set; }
        public List<ItemCarrinhoCompra> Itens { get; set; }

        public decimal TotalPreco
        {
            get
            {
                var total = 0M;
                Itens?.ForEach(x => total += x.Preco * x.Quantidade);

                return total;
            }
        }
    }
}
