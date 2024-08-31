using _.Desktop.Models;
using _.Desktop.Services;
using Microsoft.AspNetCore.Mvc;

namespace _.Desktop.Controllers
{
    [ApiController]
    [Route("verdeviva/gestao/produtos")]
    public class ProdutoController : ControllerBase
    {
        private readonly IManagerProdutoService _produtoService;

        public ProdutoController(IManagerProdutoService produtoService)
        {
            _produtoService = produtoService;
        }

        [HttpGet("listar-todos")]
        public async Task<ActionResult<IEnumerable<Produto>>> ListarTodos()
        {
            var produtos = await _produtoService.ListarTodosAsync();
            return Ok(produtos);
        }

        [HttpGet("buscar/{id}")]
        public async Task<ActionResult<Produto>> Buscar(int id)
        {
            var produto = await _produtoService.BuscarPorIdAsync(id);
            if (produto == null)
                return NotFound();

            return Ok(produto);
        }

        [HttpPost("adicionar-novo")]
        public async Task<ActionResult> AdicionarNovo([FromBody] Produto produto)
        {
            await _produtoService.AdicionarNovoAsync(produto);
            return CreatedAtAction(nameof(Buscar), new { id = produto.Id }, produto);
        }

        [HttpPut("atualizar/{id}")]
        public async Task<ActionResult> Atualizar(int id, [FromBody] Produto produto)
        {
            await _produtoService.AtualizarAsync(id, produto);
            return NoContent();
        }

        [HttpDelete("remover/{id}")]
        public async Task<ActionResult> Remover(int id)
        {
            await _produtoService.RemoverAsync(id);
            return NoContent();
        }
    }

}
