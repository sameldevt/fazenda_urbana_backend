using Model.Entities;
using System.Reflection.Metadata.Ecma335;

namespace Model.Dtos
{
    public record FuncionarioDto : UsuarioDto
    {
        public int Id { get; set; }
        public string Cargo { get; set; }
        public string NumeroRegistro { get; set; }
        public FuncionarioDto() { }
    }

    public record CadastrarFuncionarioDto
    {
        public string Cargo { get; set; }
        public string NumeroRegistro { get; set; }
        public DateTime DataCadastro { get; set; }
        public ContatoDto Contato { get; init; }
        public IEnumerable<Endereco> Enderecos { get; init; }

        public CadastrarFuncionarioDto() { }
    }
}
