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
        public async Task<ActionResult<IEnumerable<ClienteDto>>> BuscarTodos()
        {
            var clientes = await _clienteService.BuscarTodosAsync();
            return Ok(clientes);
        }

        [HttpGet("buscar/{id}")]
        public async Task<ActionResult<ClienteDto>> Buscar(int id)
        {
            var cliente = await _clienteService.BuscarPorIdAsync(id);

            return Ok(cliente);
        }

        [HttpGet("buscar-email")]
        public async Task<ActionResult<ClienteDto>> BuscarPorEmail(string email)
        {
            var cliente = await _clienteService.BuscarPorEmailAsync(email);

            return Ok(cliente);
        }

        [HttpPost("cadastrar")]
        public async Task<ActionResult<ClienteDto>> Cadastrar([FromBody] CadastrarClienteDto cadastrarClienteDto)
        {
            var clienteCadastradoDto = await _clienteService.CadastrarAsync(cadastrarClienteDto);
            return Created(nameof(Cadastrar), clienteCadastradoDto);
        }

        [HttpPut("atualizar")]
        public async Task<ActionResult<ClienteDto>> Atualizar([FromBody] ClienteDto atualizarClienteDto)
        {
            var clienteAtualizado = await _clienteService.AtualizarAsync(atualizarClienteDto);
            return Ok(clienteAtualizado);
        }

        [HttpDelete("remover/{id}")]
        public async Task<ActionResult<ClienteDto>> Remover(int id)
        {
            var clienteRemovido = await _clienteService.RemoverAsync(id);
            return Ok(clienteRemovido);
        }
    }
}
