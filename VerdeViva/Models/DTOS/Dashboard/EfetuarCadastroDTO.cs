using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _.VerdeViva.Models.DTOS.Dashboard
{
    public record CadastroDTO(
        string NomeCompleto,
        string Telefone,
        string Email,
        string ConfirmarEmail,
        string Senha,
        string ConfirmarSenha
    );
}