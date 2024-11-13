using Model.Entities;
using System.Reflection.Metadata.Ecma335;

namespace Model.Dtos
{
    public record FuncionarioDto : UsuarioDto
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Cargo { get; set; }
        public string NumeroRegistro { get; set; }
        public ContatoDto Contato { get; init; }
        public IEnumerable<Endereco> Enderecos { get; init; }

        public FuncionarioDto() { }
    }

    public record EntrarOperadorDto
    {
        public string Email { get; set; }
        public string Senha { get; set; }

        public EntrarOperadorDto() { }
    }

    public record CadastrarOperadorDto
    {
        public string Nome { get; init; }
        public string Senha { get; init; }
        public ContatoDto Contato { get; init; }
        public CadastrarOperadorDto() { }
    }

    public record CadastrarFuncionarioDto
    {
        public string Nome { get; init; }
        public string Senha { get; init; }
        public string Cargo { get; init; }
        public DateTime DataRegistro { get; init; }
        public ContatoDto Contato { get; init; }
        public IEnumerable<EnderecoDto> Enderecos { get; init; }
        public CadastrarFuncionarioDto() { }
    }
}
