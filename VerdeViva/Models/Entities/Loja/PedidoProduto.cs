using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using _.VerdeViva.Models.Entities.Producao;

namespace _.VerdeViva.Models.Entities.Loja;
public class PedidoProduto
{
    public int PedidoId { get; set; } // Chave estrangeira para Pedido
    public Pedido Pedido { get; set; }

    public int ProdutoId { get; set; } // Chave estrangeira para Produto
    public Produto Produto { get; set; }

    public int Quantidade { get; set; } // Quantidade do produto no pedido
}