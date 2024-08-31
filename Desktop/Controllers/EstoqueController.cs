using _.Desktop.Models;
using _.Desktop.Services;
using Microsoft.AspNetCore.Mvc;

namespace _.Desktop.Controllers
{
    [ApiController]
    [Route("verdeviva/gestao/estoque")]
    public class EstoqueController : ControllerBase
    {
        private readonly IEstoqueService _estoqueService;

        public EstoqueController(IEstoqueService estoqueService)
        {
            _estoqueService = estoqueService;
        }

        [HttpGet("listar-todos")]
        public async Task<ActionResult<IEnumerable<Produto>>> ListarTodos()
        {
            var produtos = await _estoqueService.ListarTodosAsync();
            return Ok(produtos);
        }

        [HttpPut("atualizar-quantidade/{id}")]
        public async Task<ActionResult> AtualizarQuantidade(int id, [FromBody] int novaQuantidade)
        {
            await _estoqueService.AtualizarQuantidadeAsync(id, novaQuantidade);
            return NoContent();
        }
    }


}
