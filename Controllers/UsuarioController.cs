using Microsoft.AspNetCore.Mvc;
using Model.Dtos;
using Model.Common;

using Services;

namespace Controllers
{
    [ApiController]
    [Route("verdeviva/usuario")]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioService _usuarioService;

        public UsuarioController(IUsuarioService usuarioService)
        {
            _usuarioService = usuarioService;
        }

        [HttpPost("registrar")]
        public async Task<ActionResult<ClienteDto>> Registrar([FromBody] CadastrarUsuarioDto registrarUsuarioDto)
        {
            var response = await _usuarioService.RegistrarCliente(registrarUsuarioDto);
            return Created(nameof(Registrar), response);
        }

        [HttpPost("entrar")]
        public async Task<ActionResult<ClienteDto>> Entrar([FromBody] EntrarUsuarioDto entrarUsuarioDto)
        {
            var response = await _usuarioService.EntrarCliente(entrarUsuarioDto);
            return Ok(response);
        }

        [HttpPost("alterar-senha")]
        public async Task<ActionResult<ClienteDto>> RecuperarSenha([FromBody] RecuperarSenhaDto recuperarSenhaDto)
        {
            var response = await _usuarioService.RecuperarSenhaCliente(recuperarSenhaDto);
            return Ok(response);
        }

        [HttpPost("cadastrar-endereco")]
        public async Task<ActionResult<ClienteDto>> CadastrarEndereco([FromBody] CadastrarEnderecoDto cadastrarEnderecoDto)
        {
            var response = await _usuarioService.CadastrarEndereco(cadastrarEnderecoDto);
            return Created(nameof(CadastrarEndereco),response);
        }

        [HttpGet("buscar-pedidos")]
        public async Task<ActionResult<List<PedidoDto>>> BuscarPedidos(int id)
        {
            var reponse = await _usuarioService.BuscarPedidos(id);
            return Ok(reponse);
        }
    }

    [ApiController]
    [Route("verdeviva/operador")]
    public class OperadorController : ControllerBase
    {
        private readonly IUsuarioService _usuarioService;

        public OperadorController(IUsuarioService usuarioService)
        {
            _usuarioService = usuarioService;
        }

        [HttpPost("registrar")]
        public async Task<ActionResult<FuncionarioDto>> Registrar([FromBody] CadastrarFuncionarioDto cadastrarFuncionarioDto)
        {
            var response = await _usuarioService.RegistrarFuncionario(cadastrarFuncionarioDto);
            return Created(nameof(Registrar), response);
        }

        [HttpPost("entrar")]
        public async Task<ActionResult<FuncionarioDto>> Entrar([FromBody] EntrarFuncionarioDto entrarFuncionarioDto)
        {
            var response = await _usuarioService.EntrarFuncionario(entrarFuncionarioDto);
            return Ok(response);
        }

        [HttpPost("alterar-senha")]
        public async Task<ActionResult<FuncionarioDto>> RecuperarSenha([FromBody] RecuperarSenhaDto recuperarSenhaDto)
        {
            var response = await _usuarioService.RecuperarSenhaFuncionario(recuperarSenhaDto);
            return Ok(response);
        }
    }
}