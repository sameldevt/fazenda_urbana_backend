using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using _.VerdeViva.Models.Entities.Producao;

namespace _.VerdeViva.Models.Entities.Loja;
public class PedidoProduto
{
    public int FkPedido { get; set; } 
    public Pedido Pedido { get; set; }

    public int FkProduto { get; set; }     

    public Produto Produto { get; set; }

    public int Quantidade { get; set; }
}