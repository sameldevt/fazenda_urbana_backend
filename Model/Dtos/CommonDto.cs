namespace Model.Dtos
{
    public record UsuarioDto
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public DateTime DataCadastro { get; set; }
        public ContatoDto Contato { get; set; }
        public ICollection<EnderecoDto> Enderecos { get; set; }

        public UsuarioDto() { }
    }

    public record ContatoDto
    {
        public string Telefone { get; init; }
        public string Email { get; init; }

        public ContatoDto() { }
    }

    public record EnderecoDto
    {
        public string Logradouro { get; init; } 
        public string Numero { get; init; }
        public string Cidade { get; init; }
        public string CEP { get; init; }
        public string Complemento { get; init; }
        public string Estado { get; init; }
        public string InformacoesAdicionais { get; init; }

        public EnderecoDto() { }
    }

}
