using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;

namespace Model.Dtos
{
    public record EntrarUsuarioDto
    {
        public string Email {  get; set; }
        public string Senha { get; set; }

        public EntrarUsuarioDto() { }
    }

    public record RegistrarUsuarioDto
    {
        public string Nome { get; init; }
        public string Senha { get; init; }
        public string Telefone { get; init; }
        public string Email { get; init; }
        public string Logradouro { get; init; }
        public string Numero { get; init; }
        public string Cidade { get; init; }
        public string CEP { get; init; }
        public string Complemento { get; init; }
        public string Estado { get; init; }
        public string InformacoesAdicionais { get; init; }

        public RegistrarUsuarioDto() { }
    }

    public record RecuperarSenhaDto
    {
        public string Email { get; init; }
        public string NovaSenha { get; init; }

        public RecuperarSenhaDto() { }
    }
}