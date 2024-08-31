using _.Desktop.Models;
using _.Desktop.Services;
using Microsoft.AspNetCore.Mvc;

namespace _.Desktop.Controllers
{
    [ApiController]
    [Route("verdeviva/gestao/fornecedores")]
    public class FornecedorController : ControllerBase
    {
        private readonly IFornecedorService _fornecedorService;

        public FornecedorController(IFornecedorService fornecedorService)
        {
            _fornecedorService = fornecedorService;
        }

        [HttpGet("listar-todos")]
        public async Task<ActionResult<IEnumerable<Fornecedor>>> ListarTodos()
        {
            var fornecedores = await _fornecedorService.ListarTodosAsync();
            return Ok(fornecedores);
        }

        [HttpGet("buscar/{id}")]
        public async Task<ActionResult<Fornecedor>> Buscar(int id)
        {
            var fornecedor = await _fornecedorService.BuscarPorIdAsync(id);
            if (fornecedor == null)
                return NotFound();

            return Ok(fornecedor);
        }

        [HttpPost("adicionar")]
        public async Task<ActionResult> Adicionar([FromBody] Fornecedor fornecedor)
        {
            await _fornecedorService.AdicionarAsync(fornecedor);
            return CreatedAtAction(nameof(Buscar), new { id = fornecedor.Id }, fornecedor);
        }

        [HttpPut("atualizar/{id}")]
        public async Task<ActionResult> Atualizar(int id, [FromBody] Fornecedor fornecedor)
        {
            await _fornecedorService.AtualizarAsync(id, fornecedor);
            return NoContent();
        }

        [HttpDelete("remover/{id}")]
        public async Task<ActionResult> Remover(int id)
        {
            await _fornecedorService.RemoverAsync(id);
            return NoContent();
        }
    }

}
