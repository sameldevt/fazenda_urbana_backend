using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using _.VerdeViva.Models.Entities.Dashboard.Cliente;
using _.VerdeViva.Models.Entities.Producao;

namespace _.VerdeViva.Models.Entities.Loja;

public class Pedido
{
    [Key]
    public int Id { get; set; } 
    public DateTime Data { get; set; } 
    public int FkUsuario { get; set; }
    public Usuario Usuario { get; set; }

    public ICollection<PedidoProduto> PedidoProdutos { get; set; }
}
