using Dapper;
using Desconto.Api.Data;
using Desconto.Api.Entities;
using Npgsql;

namespace Desconto.Api.Repository
{
    public class DescontoRepository : IDescontoRepository
    {
        private readonly NpgsqlConnection _conexao;
        public DescontoRepository(IContexto contexto)
        {
            _conexao = contexto.ObterConexao();
        }

        public async Task<Cupom> GetDesconto(string nomeProduto)
        {
            var cupom = await _conexao.QueryFirstOrDefaultAsync<Cupom>("SELECT * FROM Cupom WHERE NomeProduto = @NomeProduto", new { NomeProduto = nomeProduto});

            if (cupom is null)
                return new Cupom();

            return cupom;
        }

        public async Task<bool> CreateDesconto(Cupom cupom)
        {
            var inseridoComSucesso = await _conexao.ExecuteAsync("INSERT INTO Cupom (NomeProduto, Descricao, Valor)" +
                " VALUES (@NomeProduto, @Descricao, @Valor)", new { NomeProduto = cupom.NomeProduto, Descricao = cupom.Descricao, Valor = cupom.Valor });

            if (inseridoComSucesso == 0)
                return false;

            return true;
        }

        public async Task<bool> UpdatetDesconto(Cupom cupom)
        {
            var alteradoComSucesso = await _conexao.ExecuteAsync("UPDATE Cupom SET NomeProduto = @NomeProduto, Descricao = @Descricao, Valor = @Valor" +
                " WHERE Id = @Id", new { NomeProduto = cupom.NomeProduto, Descricao = cupom.Descricao, Valor = cupom.Valor, Id = cupom.Id });

            if (alteradoComSucesso == 0)
                return false;

            return true;
        }

        public async Task<bool> DeleteDesconto(string nomeProduto)
        {
            var excluidoComSucesso = await _conexao.ExecuteAsync("DELETE FROM Cupom WHERE NomeProduto = @NomeProduto", new { NomeProduto = nomeProduto });

            if (excluidoComSucesso == 0)
                return false;

            return true;
        }
    }
}
