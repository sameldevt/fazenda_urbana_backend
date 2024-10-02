using Model.Entities;

namespace Model.Dtos
{
    public enum ProdutoDtoTipo
    {
        Visualizar,
        Cadastrar,
        Atualizar,
    }

    public interface IProdutoDto { }

    public static class ProdutoDtoFactory
    {
        public static IProdutoDto Criar(ProdutoDtoTipo tipoDto, Produto produto)
        {
            return tipoDto switch
            {
                ProdutoDtoTipo.Visualizar => new VisualizarProdutoDto(produto),
                ProdutoDtoTipo.Cadastrar => new CadastrarProdutoDto(produto),
                ProdutoDtoTipo.Atualizar => new AtualizarProdutoDto(produto),
            };
        }
    }

    public record VisualizarProdutoDto
    (
        int Id,
        string Nome,
        string Descricao,
        decimal PrecoUnitario,
        decimal PrecoQuilo,
        int QuantidadeEstoque,
        string NomeCategoria,
        string DescricaoCategoria,
        string ImagemUrl,
        decimal Calorias,
        decimal Proteinas,
        decimal Carboidratos,
        decimal Fibras,
        decimal Gorduras
    ) : IProdutoDto
    {
        public VisualizarProdutoDto(Produto produto) : this(
            produto.Id,
            produto.Nome,
            produto.Descricao,
            produto.PrecoUnitario,
            produto.PrecoQuilo,
            produto.QuantidadeEstoque,
            produto.Categoria.Nome,
            produto.Categoria.Descricao,
            produto.ImagemUrl,
            produto.Nutrientes.Calorias,
            produto.Nutrientes.Proteinas,
            produto.Nutrientes.Carboidratos,
            produto.Nutrientes.Fibras,
            produto.Nutrientes.Gorduras
        )
        { }
    }

    public record CadastrarProdutoDto
    (
        string Nome,
        string Descricao,
        decimal PrecoUnitario,
        decimal PrecoQuilo,
        int QuantidadeEstoque,
        string NomeCategoria,
        string DescricaoCategoria,
        string ImagemUrl,
        decimal Calorias,
        decimal Proteinas,
        decimal Carboidratos,
        decimal Fibras,
        decimal Gorduras
    ) : IProdutoDto
    {
        public CadastrarProdutoDto(Produto produto) : this(
            produto.Nome,
            produto.Descricao,
            produto.PrecoUnitario,
            produto.PrecoQuilo,
            produto.QuantidadeEstoque,
            produto.Categoria.Nome,
            produto.Categoria.Descricao,
            produto.ImagemUrl,
            produto.Nutrientes.Calorias,
            produto.Nutrientes.Proteinas,
            produto.Nutrientes.Carboidratos,
            produto.Nutrientes.Fibras,
            produto.Nutrientes.Gorduras
        )
        { }
    }

    public record AtualizarProdutoDto
    (
        int Id,
        string Nome,
        string Descricao,
        decimal PrecoUnitario,
        decimal PrecoQuilo,
        int QuantidadeEstoque,
        string ImagemUrl,
        string NomeCategoria,
        string DescricaoCategoria,
        decimal Calorias,
        decimal Proteinas,
        decimal Carboidratos,
        decimal Fibras,
        decimal Gorduras
    ) : IProdutoDto
    {
        public AtualizarProdutoDto(Produto produto) : this(
            produto.Id,
            produto.Nome,
            produto.Descricao,
            produto.PrecoUnitario,
            produto.PrecoQuilo,
            produto.QuantidadeEstoque,
            produto.Categoria.Nome,
            produto.Categoria.Descricao,
            produto.ImagemUrl,
            produto.Nutrientes.Calorias,
            produto.Nutrientes.Proteinas,
            produto.Nutrientes.Carboidratos,
            produto.Nutrientes.Fibras,
            produto.Nutrientes.Gorduras
        )
        { }
    }
}
