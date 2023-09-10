using Desconto.Api.Entities;
using Desconto.Api.Repository;
using Microsoft.AspNetCore.Mvc;

namespace Desconto.Api.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class DescontoController : ControllerBase
    {
        private readonly IDescontoRepository _descontoRepository;

        public DescontoController(IDescontoRepository descontoRepository)
        {
            _descontoRepository = descontoRepository;
        }

        [HttpGet]
        [ProducesResponseType(typeof(Cupom), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(Cupom), StatusCodes.Status200OK, Type = typeof(Cupom))]
        public async Task<ActionResult<Cupom>> ObterCupom(string nomeProduto)
        {
            return Ok(await _descontoRepository.GetDesconto(nomeProduto));
        }

        [HttpPost]
        [ProducesResponseType(typeof(bool), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(bool), StatusCodes.Status200OK, Type = typeof(Cupom))]
        public async Task<ActionResult<bool>> CriarProduto(Cupom cupom)
        {
            if (cupom is null)
                return BadRequest("cupom inválido.");

            return Ok(await _descontoRepository.CreateDesconto(cupom));
        }

        [HttpPut]
        [ProducesResponseType(typeof(bool), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(bool), StatusCodes.Status200OK, Type = typeof(Cupom))]
        public async Task<ActionResult<bool>> AtualizarProduto(Cupom cupom)
        {
            if (cupom is null)
                return BadRequest("cupom inválido.");

            return Ok(await _descontoRepository.UpdatetDesconto(cupom));
        }

        [HttpDelete]
        [ProducesResponseType(typeof(bool), StatusCodes.Status200OK, Type = typeof(Cupom))]
        public async Task<ActionResult<bool>> ExcluirProduto(string nomeProduto)
        {
            return Ok(await _descontoRepository.DeleteDesconto(nomeProduto));
        }
    }
}