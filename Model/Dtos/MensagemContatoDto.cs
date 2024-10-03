namespace Model.Dtos
{
    public record RegistrarMensagemDto
    {
        public string NomeUsuario { get; init; }
        public string EmailUsuario { get; init; }
        public string Conteudo { get; init; }

        public RegistrarMensagemDto() { }
    }

    public record VisualizarMensagemDto 
    {
        public int Id { get; init; }
        public string NomeUsuario { get; init; }
        public string EmailUsuario { get; init; }
        public string Conteudo { get; init; }
        public DateTime DataEnvio { get; init; }
        public bool Respondido { get; init; }
    
        public VisualizarMensagemDto() { }
    }

    public record AtualizarMensagemDto
    {
        public int Id { get; init; }
        public string NomeUsuario { get; init; }
        public string EmailUsuario { get; init; }
        public string Conteudo { get; init; }
        public bool Respondido { get; init; }

        public AtualizarMensagemDto() { }
    }
}