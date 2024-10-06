namespace Model.Dtos
{
    public record MensagemContatoDto
    {
        public int Id { get; init; }
        public string NomeUsuario { get; init; }
        public string EmailUsuario { get; init; }
        public string Conteudo { get; init; }
        public DateTime DataEnvio { get; init; }
        public bool Respondido { get; init; }

        public MensagemContatoDto() { }
    }

    public record CadastrarMensagemContatoDto 
    {
        public string NomeUsuario { get; init; }
        public string EmailUsuario { get; init; }
        public string Conteudo { get; init; }
        public DateTime DataEnvio { get; init; }

        public CadastrarMensagemContatoDto() { }
    }
}