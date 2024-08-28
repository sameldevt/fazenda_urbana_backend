using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _.VerdeViva.Models.DTOS.Dashboard
{
    public record DadosCartaoDTO(
        string NumeroCartao,
        string NomeTitular,
        DateTime Vencimento,
        string CVV,
        FormaDePagamento FormaDePagamento 
    );
}