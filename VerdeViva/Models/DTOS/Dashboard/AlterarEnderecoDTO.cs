using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _.VerdeViva.Models.DTOS.Dashboard
{
    public record AlterarEnderecoDTO(
        string Logradouro,
        string Numero,
        string Cidade,
        string CEP,
        string Complemento,
        string Estado,
        string InformacoesAdicionais
    );
}