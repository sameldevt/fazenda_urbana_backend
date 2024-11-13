using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Model.Dtos;

namespace Model.Entities
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
        public decimal PrecoQuilo { get; set; }

        [Required]
        public decimal QuantidadeEstoque { get; set; }

        public string ImagemUrl { get; set; }

        [Required]
        public int FornecedorId { get; set; }

        public virtual Fornecedor Fornecedor { get; set; }

        [Required]
        public int CategoriaId { get; set; }

        public virtual Categoria Categoria { get; set; }

        [Required]
        public int NutrientesId { get; set; }

        public virtual Nutrientes Nutrientes { get; set; }

        public Produto() { }
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

        public Categoria() { }
    }

    public class Nutrientes
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal Calorias { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal Proteinas { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal Carboidratos { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal Fibras { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal Gorduras { get; set; }

        [Required]
        public int ProdutoId { get; set; }
        public virtual Produto Produto { get; set; }

        public Nutrientes() { }
    }
}
