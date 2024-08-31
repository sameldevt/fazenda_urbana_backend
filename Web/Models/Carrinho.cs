using _.Desktop.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace _.Web.Models
{
    public class Carrinho
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public int ClienteId { get; set; }

        public virtual Cliente Cliente { get; set; }

        public virtual List<ItemCarrinho> Itens { get; set; } = new List<ItemCarrinho>();
    }

    public class ItemCarrinho
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public int CarrinhoId { get; set; }

        public virtual Carrinho Carrinho { get; set; }

        [Required]
        public int ProdutoId { get; set; }

        public virtual Produto Produto { get; set; }

        [Required]
        public int Quantidade { get; set; }

        [Required]
        [Column(TypeName = "decimal(18,2)")]
        public decimal PrecoUnitario { get; set; }

        [Required]
        [Column(TypeName = "decimal(18,2)")]
        public decimal Subtotal => Quantidade * PrecoUnitario;
    }

}
