using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Model.Entities
{
    public class Estoque
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public int ProdutoId { get; set; }

        public virtual Produto Produto { get; set; }

        [Required]
        public int QuantidadeDisponível { get; set; }

        public string Localização { get; set; }

        public DateTime DataUltimaAtualização { get; set; }

        public int QuantidadeMínima { get; set; }

        public int QuantidadeMáxima { get; set; }

        public int? FornecedorId { get; set; }

        public virtual Fornecedor Fornecedor { get; set; }

        public string Notas { get; set; }
    }
}
