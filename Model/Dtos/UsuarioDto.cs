using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;

namespace Model.Dtos
{
    public record EntrarUsuarioDto
    {
        public string Email {  get; set; }
        public string Senha { get; set; }

        public EntrarUsuarioDto() { }
    }

    public record CadastrarUsuarioDto
    {
        public string Nome { get; init; }
        public string Senha { get; init; }
        public ContatoDto Contato { get; init; }

        public CadastrarUsuarioDto() { }
    }

    public record CadastrarEnderecoDto
    {
        public string Email { get; set; }

        public string Logradouro { get; set; }

        public string Numero { get; set; }

        public string Cidade { get; set; }

        public string CEP { get; set; }

        public string Complemento { get; set; }

        public string Estado { get; set; }

        public CadastrarEnderecoDto() { }
    }

    public record RecuperarSenhaDto
    {
        public string Email { get; init; }
        public string NovaSenha { get; init; }

        public RecuperarSenhaDto() { }
    }
}