using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Model.Entities
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

        public string Observacoes { get; set; }

        public DateTime DataCadastro { get; set; }

        // Construtor tradicional
        public Fornecedor(string nome, string cNPJ, string endereco, string telefone, string email, string website, string contatoPrincipal, string observacoes, DateTime dataCadastro)
        {
            Nome = nome;
            CNPJ = cNPJ;
            Endereco = endereco;
            Telefone = telefone;
            Email = email;
            Website = website;
            ContatoPrincipal = contatoPrincipal;
            Observacoes = observacoes;
            DataCadastro = dataCadastro;
        }
    }
}
