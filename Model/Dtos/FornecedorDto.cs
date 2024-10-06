using Model.Entities;

namespace Model.Dtos
{
    public record FornecedorDto : UsuarioDto
    {
        public string CNPJ { get; init; }

        public FornecedorDto() { }
    }

    public record CadastrarFornecedorDto
    {
        public string Nome { get; init; }
        public string Senha { get; init; }
        public string CNPJ { get; init; }
        public string Website { get; init; }
        public DateTime DataCadastro { get; init; }
        public ContatoDto Contato { get; init; }
        public ICollection<Endereco> Enderecos { get; init; }

        public CadastrarFornecedorDto() { }
    }
}
