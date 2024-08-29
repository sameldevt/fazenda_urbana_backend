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

    [HttpPost("enviar-contato-mensagem")]
    public IActionResult EnviarContatoMensagem([FromBody] ContatoMensagemDTO contatoMensagemDTO)
    {
        _dashboardService.SalvarContatoMensagem(contatoMensagemDTO);

        return CreatedAtAction(
            actionName: nameof(EnviarContatoMensagem),
            value: "Mensagem recebida com sucesso"
        );
    }

    [HttpPost("efetuar-login")]
    public async Task<IActionResult> EfetuarLogin([FromBody] EfetuarLoginDTO efetuarLoginDTO)
    {
        string message = await _dashboardService.EfetuarLogin(efetuarLoginDTO);

        return CreatedAtAction(
            actionName: nameof(EfetuarLogin),
            value: message
        );
    }

    [HttpPost("efetuar-cadastro")]
    public async Task<IActionResult> EfetuarCadastro([FromBody] EfetuarCadastroDTO efetuarCadastroDTO)
    {
        string message = await _dashboardService.EfetuarCadastro(efetuarCadastroDTO);

        return CreatedAtAction(
            actionName: nameof(EfetuarCadastro),
            value: message
        );
    }
}
