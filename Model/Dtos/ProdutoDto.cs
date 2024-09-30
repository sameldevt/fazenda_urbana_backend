using Model.Entities;

namespace Model.Dtos
{
    public record ProdutoDto
    (
        string Nome,
        string Descricao,
        decimal PrecoUnitario,
        decimal PrecoQuilo,
        int QuantidadeEstoque,
        string Categoria,
        string ImagemUrl,
        InformacoesNutricionaisDto InformacoesNutricionais
    )
    {
        public static ProdutoDto FromProduto(Produto produto)
        {
            if (produto == null)
            {
                return null;
            }

            return new ProdutoDto(
                Nome: produto.Nome,
                Descricao: produto.Descricao,
                PrecoUnitario: produto.PrecoUnitario,
                PrecoQuilo: produto.PrecoQuilo,
                QuantidadeEstoque: produto.QuantidadeEstoque,
                Categoria: produto.Categoria?.Nome ?? "Categoria Desconhecida", 
                ImagemUrl: produto.ImagemUrl ?? "Imagem não disponível",
                InformacoesNutricionais: InformacoesNutricionaisDto.FromInformacoesNutricionais(produto.InformacoesNutricionais)
                    ?? InformacoesNutricionaisDto.Empty()
             );
        }

    }
}
