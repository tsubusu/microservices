using Catalogo.Api.Entities;
using Catalogo.Api.Repository;
using Microsoft.AspNetCore.Mvc;

namespace Catalogo.Api.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class CatalogoController : ControllerBase
    {
        private readonly IProdutoRepository _produtoRepository;

        public CatalogoController(IProdutoRepository produtoRepository)
        {
            _produtoRepository = produtoRepository ?? throw new ArgumentNullException(nameof(produtoRepository));
        }

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<Produto>), StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<Produto>>> ObterProdutos()
        {
            var produtos = await _produtoRepository.ObterProdutos();
            return Ok(produtos);
        }

        [HttpGet("{id:length(24)}", Name = "ObterProduto")]
        [ProducesResponseType(typeof(Produto), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(Produto), StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<Produto>>> ObterProduto(string id)
        {
            var produto = await _produtoRepository.ObterProduto(id);

            if (produto is null)
                return NotFound();

            return Ok(produto);
        }

        [Route("[action]/{categoria}", Name = "ObterProdutosPorCategoria")]
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<Produto>), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(IEnumerable<Produto>), StatusCodes.Status200OK, Type = typeof(IEnumerable<Produto>))]
        public async Task<ActionResult<IEnumerable<Produto>>> ObterProdutosPorCategoria(string categoria)
        {
            var produtos = await _produtoRepository.ObterProdutosPorCategoria(categoria);

            if (produtos is null)
                return BadRequest("Categoria inválida.");

            return Ok(produtos);
        }

        [HttpPost]
        [ProducesResponseType(typeof(Produto), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(Produto), StatusCodes.Status200OK, Type = typeof(IEnumerable<Produto>))]
        public async Task<ActionResult<Produto>> CriarProduto(Produto produto)
        {
            if (produto is null)
                return BadRequest("Produto inválido.");

            await _produtoRepository.CriarProduto(produto);

            return CreatedAtRoute("ObterProduto", new { id = produto.Id }, produto);
        }

        [HttpPut]
        [ProducesResponseType(typeof(Produto), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(Produto), StatusCodes.Status200OK, Type = typeof(IEnumerable<Produto>))]
        public async Task<ActionResult<Produto>> AtualizarProduto(Produto produto)
        {
            if (produto is null)
                return BadRequest("Produto inválido.");

            return Ok(await _produtoRepository.AtualizarProduto(produto));
        }

        [HttpDelete("{id:length(24)}", Name = "ExcluirProduto")]
        [ProducesResponseType(typeof(Produto), StatusCodes.Status200OK, Type = typeof(IEnumerable<Produto>))]
        public async Task<ActionResult<Produto>> ExcluirProduto(string id)
        {
            return Ok(await _produtoRepository.ExcluirProduto(id));
        }
    }
}