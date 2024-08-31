using _.Web.Models;
using _.Web.Services;
using Microsoft.AspNetCore.Mvc;

namespace _.Web.Controllers
{
    [ApiController]
    [Route("verdeviva/clientes/perfil")]
    public class PerfilController : ControllerBase
    {
        private readonly IPerfilService _perfilService;

        public PerfilController(IPerfilService perfilService)
        {
            _perfilService = perfilService;
        }

        [HttpPost("registro")]
        public async Task<IActionResult> Registrar([FromBody] Perfil perfil)
        {
            await _perfilService.RegistrarAsync(perfil);
            return Ok();
        }

        [HttpPost("login")]
        public async Task<IActionResult> Entrar([FromBody] LoginDto loginDto)
        {
            // Implementar lógica de login aqui, possivelmente utilizando um serviço de autenticação
            return Ok();
        }

        [HttpPost("logout")]
        public IActionResult Sair()
        {
            // Implementar lógica de logout aqui, possivelmente removendo um token de autenticação
            return Ok();
        }

        [HttpGet("detalhes/{id}")]
        public async Task<IActionResult> VerPerfil(int id)
        {
            var perfil = await _perfilService.BuscarAsync(id);
            if (perfil == null)
            {
                return NotFound();
            }
            return Ok(perfil);
        }

        [HttpPut("atualizar/{id}")]
        public async Task<IActionResult> AtualizarPerfil(int id, [FromBody] Perfil perfil)
        {
            await _perfilService.AtualizarAsync(perfil);
            return Ok();
        }

        [HttpPost("recuperar-senha")]
        public async Task<IActionResult> RecuperarSenha([FromBody] string email)
        {
            await _perfilService.RecuperarSenhaAsync(email);
            return Ok();
        }
    }

    public record LoginDto
    (
        string Email,
        string Senha
    );
}
