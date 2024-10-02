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

    public record VisualizarFornecedorDto : IFornecedorDto
    {
        public int Id { get; init; }
        public string Nome { get; init; }
        public string CNPJ { get; init; }
        public string Endereco { get; init; }
        public string Telefone { get; init; }
        public string Email { get; init; }
        public string Website { get; init; }
        public string ContatoPrincipal { get; init; }
        public string Observacoes { get; init; }
        public DateTime DataCadastro { get; init; }

        public VisualizarFornecedorDto() { }

        public VisualizarFornecedorDto(Fornecedor fornecedor) : this()
        {
            Id = fornecedor.Id;
            Nome = fornecedor.Nome;
            CNPJ = fornecedor.CNPJ;
            Endereco = fornecedor.Endereco;
            Telefone = fornecedor.Telefone;
            Email = fornecedor.Email;
            Website = fornecedor.Website;
            ContatoPrincipal = fornecedor.ContatoPrincipal;
            Observacoes = fornecedor.Observacoes;
            DataCadastro = fornecedor.DataCadastro;
        }
    }

    public record CadastrarFornecedorDto : IFornecedorDto
    {
        public string Nome { get; init; }
        public string CNPJ { get; init; }
        public string Endereco { get; init; }
        public string Telefone { get; init; }
        public string Email { get; init; }
        public string Website { get; init; }
        public string ContatoPrincipal { get; init; }
        public string Observacoes { get; init; }
        public DateTime DataCadastro { get; init; }

        public CadastrarFornecedorDto() { }

        public CadastrarFornecedorDto(Fornecedor fornecedor) : this()
        {
            Nome = fornecedor.Nome;
            CNPJ = fornecedor.CNPJ;
            Endereco = fornecedor.Endereco;
            Telefone = fornecedor.Telefone;
            Email = fornecedor.Email;
            Website = fornecedor.Website;
            ContatoPrincipal = fornecedor.ContatoPrincipal;
            Observacoes = fornecedor.Observacoes;
            DataCadastro = fornecedor.DataCadastro;
        }
    }


    public record AtualizarFornecedorDto : IFornecedorDto
    {
        public int Id { get; init; }
        public string Nome { get; init; }
        public string CNPJ { get; init; }
        public string Endereco { get; init; }
        public string Telefone { get; init; }
        public string Email { get; init; }
        public string Website { get; init; }
        public string ContatoPrincipal { get; init; }
        public string Observacoes { get; init; }
        public DateTime DataCadastro { get; init; }

        public AtualizarFornecedorDto() { }

        public AtualizarFornecedorDto(Fornecedor fornecedor) : this()
        {
            Id = fornecedor.Id;
            Nome = fornecedor.Nome;
            CNPJ = fornecedor.CNPJ;
            Endereco = fornecedor.Endereco;
            Telefone = fornecedor.Telefone;
            Email = fornecedor.Email;
            Website = fornecedor.Website;
            ContatoPrincipal = fornecedor.ContatoPrincipal;
            Observacoes = fornecedor.Observacoes;
            DataCadastro = fornecedor.DataCadastro;
        }
    }

}
