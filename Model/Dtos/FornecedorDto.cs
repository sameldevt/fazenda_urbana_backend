using Model.Entities;

namespace Model.Dtos
{
    public record VisualizarFornecedorDto
    {
        public int Id { get; init; }
        public string Nome { get; init; }
        public string CNPJ { get; init; }
        public string Endereco { get; init; }
        public string Telefone { get; init; }
        public string Email { get; init; }
        public string Website { get; init; }
        public string ContatoPrincipal { get; init; }
        public string Observacoes { get; init; }
        public DateTime DataCadastro { get; init; }

        public VisualizarFornecedorDto() { }
    }

    public record CadastrarFornecedorDto
    {
        public string Nome { get; init; }
        public string CNPJ { get; init; }
        public string Endereco { get; init; }
        public string Telefone { get; init; }
        public string Email { get; init; }
        public string Website { get; init; }
        public string ContatoPrincipal { get; init; }
        public string Observacoes { get; init; }
        public DateTime DataCadastro { get; init; }

        public CadastrarFornecedorDto() { }
    }


    public record AtualizarFornecedorDto
    {
        public int Id { get; init; }
        public string Nome { get; init; }
        public string CNPJ { get; init; }
        public string Endereco { get; init; }
        public string Telefone { get; init; }
        public string Email { get; init; }
        public string Website { get; init; }
        public string ContatoPrincipal { get; init; }
        public string Observacoes { get; init; }
        public DateTime DataCadastro { get; init; }

        public AtualizarFornecedorDto() { }
    }
}
