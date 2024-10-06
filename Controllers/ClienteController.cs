using Model.Entities;
using Services;
using Microsoft.AspNetCore.Mvc;
using Model.Dtos;

namespace Controllers
{
    [ApiController]
    [Route("verdeviva/cliente")]
    public class ClienteController : ControllerBase
    {
        private readonly IClienteService _clienteService;

        public ClienteController(IClienteService clienteService)
        {
            _clienteService = clienteService;
        }

        [HttpGet("buscar-todos")]
        public async Task<ActionResult<IEnumerable<VisualizarClienteDto>>> BuscarTodos()
        {
            var clientes = await _clienteService.BuscarTodosAsync();
            return Ok(clientes);
        }

        [HttpGet("buscar/{id}")]
        public async Task<ActionResult<VisualizarClienteDto>> Buscar(int id)
        {
            var cliente = await _clienteService.BuscarPorIdAsync(id);

            return Ok(cliente);
        }

        [HttpGet("buscar-email")]
        public async Task<ActionResult<VisualizarClienteDto>> BuscarPorEmail(string email)
        {
            var cliente = await _clienteService.BuscarPorEmailAsync(email);

            return Ok(cliente);
        }

        [HttpPost("cadastrar")]
        public async Task<ActionResult<VisualizarClienteDto>> Cadastrar([FromBody] CadastrarClienteDto cadastrarClienteDto)
        {
            var clienteCadastradoDto = await _clienteService.CadastrarAsync(cadastrarClienteDto);
            return Created(nameof(Cadastrar), clienteCadastradoDto);
        }

        [HttpPut("atualizar")]
        public async Task<ActionResult<VisualizarClienteDto>> Atualizar([FromBody] AtualizarClienteDto atualizarClienteDto)
        {
            var clienteAtualizado = await _clienteService.AtualizarAsync(atualizarClienteDto);
            return Ok(clienteAtualizado);
        }

        [HttpDelete("remover/{id}")]
        public async Task<ActionResult<VisualizarClienteDto>> Remover(int id)
        {
            var clienteRemovido = await _clienteService.RemoverAsync(id);
            return Ok(clienteRemovido);
        }
    }
}
