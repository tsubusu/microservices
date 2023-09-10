using Npgsql;

namespace Desconto.Api.Data
{
    public class Contexto : IContexto
    {
        private readonly NpgsqlConnection conexao;

        public Contexto(IConfiguration configuration)
        {
            conexao = new NpgsqlConnection(configuration.GetValue<string>("DatabaseSettings:ConnectionString"));
        }

        public NpgsqlConnection ObterConexao()
        {
            return conexao;
        }

    }
}
