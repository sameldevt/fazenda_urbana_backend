using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace _.Desktop.Models
{
    public class Produto
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public string Nome { get; set; }

        public string Descricao { get; set; }

        [Required]
        [Column(TypeName = "decimal(18,2)")]
        public decimal PrecoUnitario { get; set; }

        [Required]
        [Column(TypeName = "decimal(18,2)")]
        public decimal PrecoQuilo { get; set; }

        [Required]
        public int QuantidadeEstoque { get; set; }

        [Required]
        public int CategoriaId { get; set; }

        public virtual Categoria Categoria { get; set; }

        public string ImagemUrl { get; set; }

        public virtual InformacoesNutricionais InformacoesNutricionais { get; set; }
    }

    public class Categoria
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public DateTime DataCriacao { get; set; } = DateTime.UtcNow;
        public ICollection<Produto> Produtos { get; set; }
    }

    public class InformacoesNutricionais
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public int ProdutoId { get; set; }

        public virtual Produto Produto { get; set; }

        public int Calorias { get; set; }
        public decimal Proteinas { get; set; }
        public decimal Carboidratos { get; set; }
        public decimal Fibras { get; set; }
        public decimal Gorduras { get; set; }
    }
}
