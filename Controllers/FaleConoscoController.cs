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
        public IActionResult EnviarMensagem([FromBody] FaleConosco faleConosco)
        {
            _faleConoscoService.EnviarMensagemAsync(faleConosco);
            return Created(nameof(EnviarMensagem), faleConosco);
        }
    }

}
