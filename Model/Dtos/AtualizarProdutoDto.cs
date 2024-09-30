namespace Model.Dtos
{
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
    );
}
