using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using _.VerdeViva.Models.Entities.Producao;

namespace _.VerdeViva.Models.DTOS.Producao;

public record CadastrarProdutoDTO(
    string Nome,
    string Descricao,
    decimal PrecoUnitario,
    decimal PrecoQuilo,
    int QuantidadeEstoque,
    string ImagemUrl,       
    int CategoriaId,
    Nutriente Nutriente
);