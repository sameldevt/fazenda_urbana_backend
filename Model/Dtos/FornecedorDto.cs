using Model.Entities;

namespace Model.Dtos
{
    public interface IFornecedorDto { }

    public static class FornecedorDtoFactory
    {
        public static IFornecedorDto Criar(TipoDto tipoDto, Fornecedor fornecedor)
        {
            return tipoDto switch
            {
                TipoDto.Visualizar => new VisualizarFornecedorDto(fornecedor),
                TipoDto.Cadastrar => new CadastrarFornecedorDto(fornecedor),
                TipoDto.Atualizar => new AtualizarFornecedorDto(fornecedor),
            };
        }
    }

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
    ) : IFornecedorDto
    {
        public VisualizarFornecedorDto(Fornecedor fornecedor) : this(
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
        ) { }
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
    ) : IFornecedorDto
    {
        public CadastrarFornecedorDto(Fornecedor fornecedor) : this (
            fornecedor.Nome,
            fornecedor.CNPJ,
            fornecedor.Endereco,
            fornecedor.Telefone,
            fornecedor.Email,
            fornecedor.Website,
            fornecedor.ContatoPrincipal,
            fornecedor.Observacoes,
            fornecedor.DataCadastro
        ) { }
    }

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
    ) : IFornecedorDto
    {
        public AtualizarFornecedorDto(Fornecedor fornecedor) : this(
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
        ) { }
    }
}
