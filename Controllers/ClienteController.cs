using Model.Entities;
using Services;
using Microsoft.AspNetCore.Mvc;

namespace Controllers
{
    [ApiController]
    [Route("verdeviva/clientes")]
    public class ClienteController : ControllerBase
    {
        private readonly IClienteService _clienteService;

        public ClienteController(IClienteService clienteService)
        {
            _clienteService = clienteService;
        }

        [HttpGet("listar-todos")]
        public async Task<ActionResult<IEnumerable<Cliente>>> ListarTodos()
        {
            var clientes = await _clienteService.ListarTodosAsync();
            return Ok(clientes);
        }

        [HttpGet("buscar/{id}")]
        public async Task<ActionResult<Cliente>> Buscar(int id)
        {
            var cliente = await _clienteService.BuscarPorIdAsync(id);
            if (cliente == null)
                return NotFound();

            return Ok(cliente);
        }

        [HttpPost("adicionar")]
        public async Task<ActionResult> Adicionar([FromBody] Cliente cliente)
        {
            await _clienteService.AdicionarAsync(cliente);
            return CreatedAtAction(nameof(Buscar), new { id = cliente.Id }, cliente);
        }

        [HttpPut("atualizar/{id}")]
        public async Task<ActionResult> Atualizar(int id, [FromBody] Cliente cliente)
        {
            await _clienteService.AtualizarAsync(id, cliente);
            return NoContent();
        }

        [HttpDelete("remover/{id}")]
        public async Task<ActionResult> Remover(int id)
        {
            await _clienteService.RemoverAsync(id);
            return NoContent();
        }
    }


}
