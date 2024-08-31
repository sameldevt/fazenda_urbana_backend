using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace _.Desktop.Models
{
    public class Pedido
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public int ClienteId { get; set; }

        public virtual Cliente Cliente { get; set; }

        [Required]
        public DateTime DataPedido { get; set; }

        public DateTime? DataEntrega { get; set; }

        [Required]
        public string Status { get; set; }

        [Required]
        [Column(TypeName = "decimal(18,2)")]
        public decimal Total { get; set; }

        public string EnderecoEntrega { get; set; }

        public string FormaPagamento { get; set; }

        public string Notas { get; set; }

        public virtual ICollection<ItemPedido> Itens { get; set; } = new HashSet<ItemPedido>();
    }

    public class ItemPedido
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public int PedidoId { get; set; }

        public virtual Pedido Pedido { get; set; }

        [Required]
        public int ProdutoId { get; set; }

        public virtual Produto Produto { get; set; }

        [Required]
        public int Quantidade { get; set; }

        [Required]
        [Column(TypeName = "decimal(18,2)")]
        public decimal PreçoUnitario { get; set; }

        [Required]
        [Column(TypeName = "decimal(18,2)")]
        public decimal Subtotal { get; set; }
    }
}
