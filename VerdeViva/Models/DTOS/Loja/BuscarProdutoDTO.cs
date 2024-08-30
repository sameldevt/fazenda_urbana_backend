using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using _.VerdeViva.Models.Entities.Producao;
using Microsoft.AspNetCore.SignalR;

namespace _.VerdeViva.Models.DTOS.Loja;

public record BuscarProdutoDTO(
    int Id, 
    string Nome,
    string Descricao,
    decimal PrecoUnitario,
    decimal PrecoQuilo,
    int QuantidadeEstoque,
    Nutriente Nutriente,
    Categoria Categoria
);
