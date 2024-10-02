using Model.Entities;

namespace Model.Dtos
{
    public interface IProdutoDto { }

    public static class ProdutoDtoFactory
    {
        public static IProdutoDto Criar(TipoDto tipoDto, Produto produto)
        {
            return tipoDto switch
            {
                TipoDto.Visualizar => new VisualizarProdutoDto(produto),
                TipoDto.Cadastrar => new CadastrarProdutoDto(produto),
                TipoDto.Atualizar => new AtualizarProdutoDto(produto),
            };
        }
    }
    public record VisualizarProdutoDto : IProdutoDto
    {
        public int Id { get; init; }
        public string Nome { get; init; }
        public string Descricao { get; init; }
        public decimal PrecoUnitario { get; init; }
        public decimal PrecoQuilo { get; init; }
        public int QuantidadeEstoque { get; init; }
        public string NomeCategoria { get; init; }
        public string DescricaoCategoria { get; init; }
        public string ImagemUrl { get; init; }
        public decimal Calorias { get; init; }
        public decimal Proteinas { get; init; }
        public decimal Carboidratos { get; init; }
        public decimal Fibras { get; init; }
        public decimal Gorduras { get; init; }

        public VisualizarProdutoDto() { }

        public VisualizarProdutoDto(Produto produto) : this()
        {
            Id = produto.Id;
            Nome = produto.Nome;
            Descricao = produto.Descricao;
            PrecoUnitario = produto.PrecoUnitario;
            PrecoQuilo = produto.PrecoQuilo;
            QuantidadeEstoque = produto.QuantidadeEstoque;
            NomeCategoria = produto.Categoria.Nome;
            DescricaoCategoria = produto.Categoria.Descricao;
            ImagemUrl = produto.ImagemUrl;
            Calorias = produto.Nutrientes.Calorias;
            Proteinas = produto.Nutrientes.Proteinas;
            Carboidratos = produto.Nutrientes.Carboidratos;
            Fibras = produto.Nutrientes.Fibras;
            Gorduras = produto.Nutrientes.Gorduras;
        }
    }


    public record CadastrarProdutoDto : IProdutoDto
    {
        public string Nome { get; init; }
        public string Descricao { get; init; }
        public decimal PrecoUnitario { get; init; }
        public decimal PrecoQuilo { get; init; }
        public int QuantidadeEstoque { get; init; }
        public string NomeCategoria { get; init; }
        public string DescricaoCategoria { get; init; }
        public string ImagemUrl { get; init; }
        public decimal Calorias { get; init; }
        public decimal Proteinas { get; init; }
        public decimal Carboidratos { get; init; }
        public decimal Fibras { get; init; }
        public decimal Gorduras { get; init; }

        public CadastrarProdutoDto() { }

        public CadastrarProdutoDto(Produto produto) : this()
        {
            Nome = produto.Nome;
            Descricao = produto.Descricao;
            PrecoUnitario = produto.PrecoUnitario;
            PrecoQuilo = produto.PrecoQuilo;
            QuantidadeEstoque = produto.QuantidadeEstoque;
            NomeCategoria = produto.Categoria.Nome;
            DescricaoCategoria = produto.Categoria.Descricao;
            ImagemUrl = produto.ImagemUrl;
            Calorias = produto.Nutrientes.Calorias;
            Proteinas = produto.Nutrientes.Proteinas;
            Carboidratos = produto.Nutrientes.Carboidratos;
            Fibras = produto.Nutrientes.Fibras;
            Gorduras = produto.Nutrientes.Gorduras;
        }
    }

    public record AtualizarProdutoDto : IProdutoDto
    {
        public int Id { get; init; }
        public string Nome { get; init; }
        public string Descricao { get; init; }
        public decimal PrecoUnitario { get; init; }
        public decimal PrecoQuilo { get; init; }
        public int QuantidadeEstoque { get; init; }
        public string ImagemUrl { get; init; }
        public string NomeCategoria { get; init; }
        public string DescricaoCategoria { get; init; }
        public decimal Calorias { get; init; }
        public decimal Proteinas { get; init; }
        public decimal Carboidratos { get; init; }
        public decimal Fibras { get; init; }
        public decimal Gorduras { get; init; }

        public AtualizarProdutoDto() { }

        public AtualizarProdutoDto(Produto produto) : this()
        {
            Id = produto.Id;
            Nome = produto.Nome;
            Descricao = produto.Descricao;
            PrecoUnitario = produto.PrecoUnitario;
            PrecoQuilo = produto.PrecoQuilo;
            QuantidadeEstoque = produto.QuantidadeEstoque;
            NomeCategoria = produto.Categoria.Nome;
            DescricaoCategoria = produto.Categoria.Descricao;
            ImagemUrl = produto.ImagemUrl;
            Calorias = produto.Nutrientes.Calorias;
            Proteinas = produto.Nutrientes.Proteinas;
            Carboidratos = produto.Nutrientes.Carboidratos;
            Fibras = produto.Nutrientes.Fibras;
            Gorduras = produto.Nutrientes.Gorduras;
        }
    }

}
