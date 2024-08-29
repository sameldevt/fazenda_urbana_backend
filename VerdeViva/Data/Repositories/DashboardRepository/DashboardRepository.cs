using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using _.VerdeViva.Data;
using _.VerdeViva.Data.Repositories.DashboardRepository;
using _.VerdeViva.Models.DTOS.Dashboard;
using _.VerdeViva.Models.Entities.Dashboard;

namespace _.VerdeViva.Data.Repositories.DashboardRepository;

public class DashboardRepository : IDashboardRepository
{
    private readonly ApplicationDbContext _context;

    public DashboardRepository(ApplicationDbContext context)
    {
        _context = context;
    }
    public void SalvarContatoMensagem(ContatoMensagemDTO contatoMensagemDTO)
    {
        ContatoMensagem contatoMensagem = ContatoMensagem.From(contatoMensagemDTO);
        
        _context.Mensagem.Add(contatoMensagem);
        _context.SaveChanges();
    }
}
