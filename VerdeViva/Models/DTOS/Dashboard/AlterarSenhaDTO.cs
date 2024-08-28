using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _.VerdeViva.Models.DTOS.Dashboard
{
    public record AlterarSenhaDTO(
        string Email,
        string NovaSenha,
        string ConfirmarNovaSenha
    );
}