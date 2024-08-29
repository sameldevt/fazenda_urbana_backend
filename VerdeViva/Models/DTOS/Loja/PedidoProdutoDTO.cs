using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _.VerdeViva.Models.DTOS.Loja;

public record PedidoProdutoDTO(
    int ProdutoId,
    int Quantidade
);
