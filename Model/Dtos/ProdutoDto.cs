using Model.Entities;

namespace Model.Dtos
{
    public record VisualizarProdutoDto
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
    }


    public record CadastrarProdutoDto
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
    }

    public record AtualizarProdutoDto
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
    }
}
