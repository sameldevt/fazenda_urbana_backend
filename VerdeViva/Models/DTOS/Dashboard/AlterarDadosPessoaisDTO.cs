using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _.VerdeViva.Models.DTOS.Dashboard
{
    public record AlterarDadosPessoaisDTO(
        string NomeCompleto,
        string Email,
        string Telefone,
        string Senha
    );
}