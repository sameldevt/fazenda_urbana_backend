using Model.Entities;

namespace Model.Dtos
{
    public record ClienteDto : UsuarioDto
    {
        public ClienteDto() { }
    }

    public record CadastrarClienteDto
    {
        public string Nome { get; init; }
        public string Senha { get; init; }
        public DateTime DataCadastro { get; set; }
        public ContatoDto Contato { get; init; }
        public ICollection<Endereco> Enderecos { get; init; }

        public CadastrarClienteDto() { }
    }
}