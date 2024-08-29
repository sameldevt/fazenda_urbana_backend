using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using _.VerdeViva.Models.Entities.Dashboard.Cliente;
using _.VerdeViva.Models.Entities.Producao;

namespace _.VerdeViva.Models.Entities.Loja;

public class Pedido
{
    public int PedidoId { get; set; } // Chave Primária
    public DateTime Data { get; set; } // Data do pedido
    // Chave estrangeira para Usuario
    public int UsuarioId { get; set; }
    public Usuario Usuario { get; set; }

    // Relacionamento muitos-para-muitos com Produto
    public ICollection<PedidoProduto> PedidoProdutos { get; set; }
}
