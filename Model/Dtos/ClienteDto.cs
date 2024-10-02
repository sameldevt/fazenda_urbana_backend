using Model.Entities;

namespace Model.Dtos
{
    public record VisualizarClienteDto
    {
        public int Id { get; init; }
        public string Nome { get; init; }
        public string Telefone { get; init; }
        public string Email { get; init; }
        public string Logradouro { get; init; }
        public string Numero { get; init; }
        public string Cidade { get; init; }
        public string CEP { get; init; }
        public string Complemento { get; init; }
        public string Estado { get; init; }
        public string InformacoesAdicionais { get; init; }

        public VisualizarClienteDto() { }
    }

    public record CadastrarClienteDto
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

        public CadastrarClienteDto() { }
    }

    public record AtualizarClienteDto
    {
        public int Id { get; init; }
        public string Nome { get; init; }
        public string Telefone { get; init; }
        public string Email { get; init; }
        public string Logradouro { get; init; }
        public string Numero { get; init; }
        public string Cidade { get; init; }
        public string CEP { get; init; }
        public string Complemento { get; init; }
        public string Estado { get; init; }
        public string InformacoesAdicionais { get; init; }

        public AtualizarClienteDto() { }
    }
}