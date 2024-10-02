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
        public ActionResult<FaleConosco> EnviarMensagem([FromBody] FaleConosco faleConosco)
        {
            var mensagemRegistrada = _faleConoscoService.EnviarMensagemAsync(faleConosco);
            return Created(nameof(EnviarMensagem), mensagemRegistrada);
        }
    }

}
