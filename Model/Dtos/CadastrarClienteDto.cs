namespace Model.Dtos
{
    public record CadastrarClienteDto
    (
        string Nome,
        string Senha,
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