using Model.Entities;

namespace Model.Dtos
{
    public record VisualizarFornecedorDto
    (
        int Id,
        string Nome,
        string CNPJ,
        string Endereco,
        string Telefone,
        string Email,
        string Website,
        string ContatoPrincipal,
        string Observacoes,
        DateTime DataCadastro
    )
    {
        public static VisualizarFornecedorDto ConverterObjeto(Fornecedor fornecedor)
        {
            return new VisualizarFornecedorDto
            (
                fornecedor.Id,
                fornecedor.Nome,
                fornecedor.CNPJ,
                fornecedor.Endereco,
                fornecedor.Telefone,
                fornecedor.Email,
                fornecedor.Website,
                fornecedor.ContatoPrincipal,
                fornecedor.Observacoes,
                fornecedor.DataCadastro
            );
        }
    }

    public record CadastrarFornecedorDto
    (
        string Nome,
        string CNPJ,
        string Endereco,
        string Telefone,
        string Email,
        string Website,
        string ContatoPrincipal,
        string Observacoes,
        DateTime DataCadastro
    );

    public record AtualizarFornecedorDto
    (
        int Id,
        string Nome,
        string CNPJ,
        string Endereco,
        string Telefone,
        string Email,
        string Website,
        string ContatoPrincipal,
        string Observacoes,
        DateTime DataCadastro
    );
}
