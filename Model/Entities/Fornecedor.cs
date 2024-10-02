using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Model.Dtos;

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

        public Fornecedor() { }

        public Fornecedor(CadastrarFornecedorDto cadastrarFornecedorDto)
        {
            Nome = cadastrarFornecedorDto.Nome;
            CNPJ = cadastrarFornecedorDto.CNPJ;
            Endereco = cadastrarFornecedorDto.Endereco;
            Telefone = cadastrarFornecedorDto.Telefone;
            Email = cadastrarFornecedorDto.Email;
            Website = cadastrarFornecedorDto.Website;
            ContatoPrincipal = cadastrarFornecedorDto.ContatoPrincipal;
            Observacoes = cadastrarFornecedorDto.Observacoes;
            DataCadastro = cadastrarFornecedorDto.DataCadastro;
        }

        public Fornecedor(AtualizarFornecedorDto atualizarFornecedorDto)
        {
            Nome = atualizarFornecedorDto.Nome;
            CNPJ = atualizarFornecedorDto.CNPJ;
            Endereco = atualizarFornecedorDto.Endereco;
            Telefone = atualizarFornecedorDto.Telefone;
            Email = atualizarFornecedorDto.Email;
            Website = atualizarFornecedorDto.Website;
            ContatoPrincipal = atualizarFornecedorDto.ContatoPrincipal;
            Observacoes = atualizarFornecedorDto.Observacoes;
            DataCadastro = atualizarFornecedorDto.DataCadastro;
        }
    }
}
