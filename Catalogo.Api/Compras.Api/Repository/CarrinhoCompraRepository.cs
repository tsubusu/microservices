using Compras.Api.Entities;
using Microsoft.Extensions.Caching.Distributed;
using System.Text.Json;

namespace Compras.Api.Repository
{
    public class CarrinhoCompraRepository : ICarrinhoCompraRepository
    {
        private readonly IDistributedCache _redisCache;

        public CarrinhoCompraRepository(IDistributedCache redisCache)
        {
            _redisCache = redisCache ?? throw new ArgumentNullException(nameof(redisCache));
        }

        public async Task<CarrinhoCompra> ObterCarrinhoCompra(string nomeUsuario)
        {
            var carrinhoCompra = await _redisCache.GetStringAsync(nomeUsuario);

            if (string.IsNullOrEmpty(carrinhoCompra))
                return null;

            return JsonSerializer.Deserialize<CarrinhoCompra>(carrinhoCompra);
        }

        public async Task<CarrinhoCompra> AtualizarCarrinhoCompra(CarrinhoCompra carrinhoCompra)
        {
            await _redisCache.SetStringAsync(carrinhoCompra.NomeUsuario,
                JsonSerializer.Serialize(carrinhoCompra));

            return await ObterCarrinhoCompra(carrinhoCompra.NomeUsuario);
        }

        public async Task ExcluirCarrinhoCompra(string nomeUsuario)
        {
            await _redisCache.RemoveAsync(nomeUsuario);
        }
    }
}
