using Compras.Api.Entities;
using Compras.Api.GrpcServices;
using Compras.Api.Repository;
using Microsoft.AspNetCore.Mvc;

namespace Compras.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CarrinhoCompraController : ControllerBase
    {
        private readonly ICarrinhoCompraRepository _carrinhoComprasRepository;
        private readonly DescontoGrpcService _descontoGrpcService;

        public CarrinhoCompraController(ICarrinhoCompraRepository carrinhoComprasRepository, DescontoGrpcService descontoGrpcService)
        {
            _carrinhoComprasRepository = carrinhoComprasRepository;
            _descontoGrpcService = descontoGrpcService;
        }

        [HttpGet("nomeUsuario", Name = "ObterCarrinhoCompra")]
        [ProducesResponseType(typeof(IEnumerable<CarrinhoCompra>), StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<CarrinhoCompra>>> ObterCarrinhoCompra(string nomeUsuario)
        {
            var carrinhoCompra = await _carrinhoComprasRepository.ObterCarrinhoCompra(nomeUsuario);
            return Ok(carrinhoCompra ?? new CarrinhoCompra(nomeUsuario));
        }

        [HttpPut]
        [ProducesResponseType(typeof(CarrinhoCompra), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(CarrinhoCompra), StatusCodes.Status200OK, Type = typeof(CarrinhoCompra))]
        public async Task<ActionResult<CarrinhoCompra>> AtualizarProduto(CarrinhoCompra carrinhoCompra)
        {
            foreach (var item in carrinhoCompra.Itens)
            {
                var cupom = await _descontoGrpcService.GetDesconto(item.NomeProduto);
                item.Preco -= cupom.Valor;
            }

            return Ok(await _carrinhoComprasRepository.AtualizarCarrinhoCompra(carrinhoCompra));
        }

        [HttpDelete]
        [ProducesResponseType(typeof(CarrinhoCompra), StatusCodes.Status200OK, Type = typeof(CarrinhoCompra))]
        public async Task<ActionResult<CarrinhoCompra>> ExcluirProduto(string nomeUsuario)
        {
            await _carrinhoComprasRepository.ExcluirCarrinhoCompra(nomeUsuario);
            return Ok();
        }
    }
}