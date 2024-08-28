using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using _.VerdeViva.Data.Repositories.Dashboard;
using _.VerdeViva.Data.Repositories.Cliente;
using _.VerdeViva.Models.DTOS.Dashboard;
using _.VerdeViva.Models.Entities.Dashboard.Cliente;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http.HttpResults;

namespace _.VerdeViva.Services;

public class DashboardService
{
    private readonly IDashboardRepository _dashboardRepository;

    private readonly IUsuarioRepository _usuarioRepository;

    public DashboardService(IDashboardRepository dashboardRepository, IUsuarioRepository usuarioRepository)
    {
        _dashboardRepository = dashboardRepository;
        _usuarioRepository = usuarioRepository;
    }

    public void SalvarContatoMensagem(ContatoMensagemDTO contatoMensagemDTO)
    {
        _dashboardRepository.SalvarContatoMensagem(contatoMensagemDTO);
    }

    public async Task<string> EfetuarLogin(EfetuarLoginDTO efetuarLoginDTO)
    {
        string EmailUsuario = efetuarLoginDTO.Email;

        var UsuarioBanco = await _usuarioRepository.BuscarPorEmail(EmailUsuario);

        if(UsuarioBanco == null)
        {
            return "Usuário não encontrado";
        }

        string SenhaRequisicao = efetuarLoginDTO.Senha;
        string SenhaBanco = UsuarioBanco.Senha;

        if(SenhaRequisicao.Equals(SenhaBanco))
        {
            return "Usuário autenticado com sucesso";
        }

        return "Credenciais inválidas!";
    }
}
