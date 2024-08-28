using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _.VerdeViva.Models.DTOS.Dashboard
{
    public record ContatoMensagemDTO(
        string Nome,
        string Sobrenome,
        string Email,
        string Mensagem
    );
}