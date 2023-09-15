using Npgsql;

namespace Desconto.Grpc.Data
{
    public interface IContexto
    {
        NpgsqlConnection ObterConexao();
    }
}
