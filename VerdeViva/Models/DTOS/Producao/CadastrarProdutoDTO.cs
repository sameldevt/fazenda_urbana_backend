using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _.VerdeViva.Models.DTOS.Producao;

public record CadastrarProdutoDTO(
    string Nome,
    decimal PrecoUnitario,
    decimal PrecoQuilo,
    int QuantidadeEstoque,
    string ImagemUrl,       
    int CategoriaId
);
