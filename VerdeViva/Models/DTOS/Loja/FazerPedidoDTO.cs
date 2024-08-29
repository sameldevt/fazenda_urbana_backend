using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using _.VerdeViva.Models.Entities.Loja;

namespace _.VerdeViva.Models.DTOS.Loja;

public record FazerPedidoDTO(
    int UsuarioId,
    ICollection<PedidoProdutoDTO> PedidoProdutos
);