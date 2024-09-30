using Model.Entities;
using Services;
using Microsoft.AspNetCore.Mvc;

namespace Controllers
{
    [ApiController]
    [Route("verdeviva/fale-conosco")]
    public class FaleConoscoController : ControllerBase
    {
        private readonly IFaleConoscoService _faleConoscoService;

        public FaleConoscoController(IFaleConoscoService faleConoscoService)
        {
            _faleConoscoService = faleConoscoService;
        }

        [HttpPost("enviar-mensagem")]
        public async Task<IActionResult> EnviarMensagem([FromBody] FaleConosco faleConosco)
        {
            await _faleConoscoService.EnviarMensagemAsync(faleConosco);
            return Ok();
        }
    }

}
