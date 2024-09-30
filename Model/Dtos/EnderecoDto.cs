namespace Model.Dtos
{
    public record EnderecoDto
    (
        string Logradouro,
        string Numero,
        string Cidade, 
        string CEP,
        string Complemento, 
        string Estado, 
        string InformacoesAdicionais
    );
}
