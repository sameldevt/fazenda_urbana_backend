using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using _.VerdeViva.Models.DTOS.Dashboard;

namespace _.VerdeViva.Data.Repositories.Dashboard;

public interface IDashboardRepository
{
    void SalvarContatoMensagem(ContatoMensagemDTO contatoMensagemDTO);
}
