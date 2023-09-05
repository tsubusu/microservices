namespace Compras.Api.Entities
{
    public class Pagamento
    {
        public string NomeUsuario { get; set; }
        public decimal Preco { get; set; }

        public string Nome { get; set; }
        public string Sobrenome { get; set; }
        public string Email { get; set; }
        public string Endereco { get; set; }
        public string Pais { get; set; }
        public string UF { get; set; }
        public string CEP { get; set; }

        public string NomeCartao { get; set; }
        public string NumeroCartao { get; set; }
        public DateOnly Validade { get; set; }
        public int CVV { get; set; }
        public string ModoPagamento { get; set; }
    }
}
