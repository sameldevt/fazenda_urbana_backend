using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace _.Desktop.Models
{
    public class Fornecedor
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public string Nome { get; set; }

        [Required]
        public string CNPJ { get; set; }

        public string Endereco { get; set; }

        public string Telefone { get; set; }

        [EmailAddress]
        public string Email { get; set; }

        public string Website { get; set; }

        public string ContatoPrincipal { get; set; }

        public string Observações { get; set; }

        public DateTime DataCadastro { get; set; }
    }
}
