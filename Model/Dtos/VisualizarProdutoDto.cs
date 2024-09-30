using Model.Entities;

namespace Model.Dtos
{
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
        decimal Calorias,
        decimal Proteinas,
        decimal Carboidratos,
        decimal Fibras,
        decimal Gorduras
    )
    {
        public static VisualizarProdutoDto ConverterProduto(Produto produto)
        {
            return new VisualizarProdutoDto(
                Id: produto.Id,
                Nome: produto.Nome,
                Descricao: produto.Descricao,
                PrecoUnitario: produto.PrecoUnitario,
                PrecoQuilo: produto.PrecoQuilo,
                QuantidadeEstoque: produto.QuantidadeEstoque,
                NomeCategoria: produto.Categoria.Nome,
                DescricaoCategoria: produto.Categoria.Descricao,
                Calorias: produto.InformacoesNutricionais.Calorias,
                Proteinas: produto.InformacoesNutricionais.Proteinas,
                Carboidratos: produto.InformacoesNutricionais.Carboidratos,
                Fibras: produto.InformacoesNutricionais.Fibras,
                Gorduras: produto.InformacoesNutricionais.Gorduras
            );
        }
    }
}
