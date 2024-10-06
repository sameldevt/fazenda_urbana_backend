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
        public async Task<ActionResult<VisualizarClienteDto>> Registrar([FromBody] RegistrarUsuarioDto registrarUsuarioDto)
        {
            var response = await _usuarioService.Registrar(registrarUsuarioDto);
            return Created(nameof(Registrar), response);
        }

        [HttpPost("entrar")]
        public async Task<ActionResult<VisualizarClienteDto>> Entrar([FromBody] EntrarUsuarioDto entrarUsuarioDto)
        {
            var response = await _usuarioService.Entrar(entrarUsuarioDto);
            return Ok(response);
        }

        [HttpPost("alterar-senha")]
        public async Task<ActionResult<VisualizarClienteDto>> RecuperarSenha([FromBody] RecuperarSenhaDto recuperarSenhaDto)
        {
            var response = await _usuarioService.RecuperarSenha(recuperarSenhaDto);
            return Ok(response);
        }
    }
}