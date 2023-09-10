using Npgsql;

namespace Desconto.Api.Data
{
    public interface IContexto
    {
        NpgsqlConnection ObterConexao();
    }
}
