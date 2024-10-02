using Microsoft.AspNetCore.Mvc;
using Model.Dtos;
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
        public async Task<ActionResult> Registrar([FromBody] RegistrarUsuarioDto registrarUsuarioDto)
        {
            await _usuarioService.Registrar(registrarUsuarioDto);
            return Created(nameof(Registrar), "Usuário registrado com sucesso.");
        }

        [HttpPost("entrar")]
        public async Task<ActionResult> Entrar([FromBody] EntrarUsuarioDto entrarUsuarioDto)
        {
            await _usuarioService.Entrar(entrarUsuarioDto);
            return Ok("Usuário autenticado com sucesso.");
        }

        [HttpPost("recuperar-senha")]
        public async Task<ActionResult> RecuperarSenha([FromBody] RecuperarSenhaDto recuperarSenhaDto)
        {
            await _usuarioService.RecuperarSenha(recuperarSenhaDto);
            return Ok("Senha recuperada com sucesso.");
        }
    }
}