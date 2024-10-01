namespace Model.Dtos
{
    public record AtualizarClienteDto
    (
        int Id,
        string Nome,
        string Telefone,
        string Email,
        string Logradouro,
        string Numero,
        string Cidade,
        string CEP,
        string Complemento,
        string Estado,
        string InformacoesAdicionais
    );
}