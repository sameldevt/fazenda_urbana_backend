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

        [HttpPost("registrar")]
        public async Task<IActionResult> Registrar([FromBody] string perfil)
        {
            //await _perfilService.RegistrarAsync(perfil);
            return Ok();
        }

        [HttpPost("entrar")]
        public IActionResult Entrar([FromBody] string loginDto)
        {
            // Implementar lógica de login aqui, possivelmente utilizando um serviço de autenticação
            return Ok();
        }

        [HttpPost("sair")]
        public IActionResult Sair()
        {
            // Implementar lógica de logout aqui, possivelmente removendo um token de autenticação
            return Ok();
        }

        [HttpPut("atualizar/{id}")]
        public async Task<IActionResult> AtualizarPerfil(int id, [FromBody] string perfil)
        {
            //await _perfilService.AtualizarAsync(perfil);
            return Ok();
        }

        [HttpPost("recuperar-senha")]
        public async Task<IActionResult> RecuperarSenha([FromBody] string email)
        {
            return Ok();
        }
    }
}
