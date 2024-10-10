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
            var response = await _usuarioService.Registrar(registrarUsuarioDto);
            return Created(nameof(Registrar), response);
        }

        [HttpPost("entrar")]
        public async Task<ActionResult<ClienteDto>> Entrar([FromBody] EntrarUsuarioDto entrarUsuarioDto)
        {
            var response = await _usuarioService.Entrar(entrarUsuarioDto);
            return Ok(response);
        }

        [HttpPost("alterar-senha")]
        public async Task<ActionResult<ClienteDto>> RecuperarSenha([FromBody] RecuperarSenhaDto recuperarSenhaDto)
        {
            var response = await _usuarioService.RecuperarSenha(recuperarSenhaDto);
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
}