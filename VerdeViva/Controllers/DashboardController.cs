using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using _.VerdeViva.Models.DTOS.Dashboard;
using _.VerdeViva.Services;
using Microsoft.AspNetCore.Mvc;

namespace _.VerdeViva.Controllers;

[ApiController]
[Route("verdeviva/dashboard")]
public class DashboardController : ControllerBase
{
    private readonly DashboardService _dashboardService;

    public DashboardController(DashboardService dashboardService)
    {
        _dashboardService = dashboardService;
    }

    [HttpPost("fale-conosco")]
    public IActionResult FaleConosco([FromBody] ContatoMensagemDTO contatoMensagemDTO)
    {
        _dashboardService.SalvarContatoMensagem(contatoMensagemDTO);

        return CreatedAtAction(
            actionName: nameof(FaleConosco),
            value: "Mensagem recebida com sucesso"
        );
    }

    [HttpPost("entrar")]
    public async Task<IActionResult> Entrar([FromBody] EfetuarLoginDTO efetuarLoginDTO)
    {
        string message = await _dashboardService.EfetuarLogin(efetuarLoginDTO);

        return CreatedAtAction(
            actionName: nameof(Entrar),
            value: message
        );
    }
}
