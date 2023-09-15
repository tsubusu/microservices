namespace Desconto.Grpc.Entities
{
    public class Cupom
    {
        public int Id { get; set; }
        public string NomeProduto { get; set; }
        public string Descricao { get; set; }
        public int Valor { get; set; }
    }
}
