using Model.Entities;
using Services;
using Microsoft.AspNetCore.Mvc;
using Model.Dtos;

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
        public async Task<ActionResult<IEnumerable<ClienteDto>>> ListarTodos()
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

        [HttpPost("cadastrar")]
        public async Task<ActionResult<ClienteDto>> Cadastrar([FromBody] ClienteDto cliente)
        {
            await _clienteService.AdicionarAsync(cliente);
            return CreatedAtAction(nameof(Buscar), new { id = cliente.Id }, cliente);
        }

        [HttpPut("atualizar")]
        public async Task<ActionResult<ClienteDto>> Atualizar([FromBody] ClienteDto cliente)
        {
            await _clienteService.AtualizarAsync(cliente);
            return NoContent();
        }

        [HttpDelete("remover/{id}")]
        public async Task<ActionResult<ClienteDto>> Remover(int id)
        {
            await _clienteService.RemoverAsync(id);
            return NoContent();
        }
    }


}
