using Model.Entities;

namespace Model.Dtos
{
    public record ProdutoDto
    {
        public int Id { get; init; }
        public string Nome { get; init; }
        public string Descricao { get; init; }
        public decimal PrecoQuilo { get; init; }
        public decimal QuantidadeEstoque { get; init; }
        public string ImagemUrl { get; set; }
        public CategoriaDto Categoria { get; init; }
        public NutrientesDto Nutrientes { get; set; }
        public FornecedorDto Fornecedor { get; set; }

        public ProdutoDto() { }
    }

    public record AtualizarProdutoDto
    {
        public int Id { get; init; }
        public string Nome { get; init; }
        public string Descricao { get; init; }
        public decimal PrecoQuilo { get; init; }
        public decimal QuantidadeEstoque { get; init; }
        public string ImagemUrl { get; set; }
        public int CategoriaId { get; init; }
        public NutrientesDto Nutrientes { get; set; }
        public int FornecedorId { get; set; }

        public AtualizarProdutoDto() { }
    }

    public record ProdutoPedidoDto
    {
        public string Nome { get; init; }
        public string Descricao { get; init; }
        public decimal PrecoQuilo { get; init; }
        public string ImagemUrl { get; set; }
        public int CategoriaId { get; init; }
        public int FornecedorId { get; set; }
        public NutrientesDto Nutrientes { get; set; }

        public ProdutoPedidoDto() { }
    }

    public record CadastrarProdutoDto
    {
        public string Nome { get; init; }
        public string Descricao { get; init; }
        public decimal PrecoQuilo { get; init; }
        public decimal QuantidadeEstoque { get; init; }
        public string ImagemUrl { get; set; }
        public NutrientesDto Nutrientes { get; set; }
        public int CategoriaId { get; init; }
        public int FornecedorId { get; set; }

        public CadastrarProdutoDto() { }
    }

    public record CategoriaDto
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public DateTime DataCriacao { get; set; }

        public CategoriaDto() { }
    }

    public record CadastrarCategoriaDto
    {
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public DateTime DataCriacao { get; set; } = DateTime.UtcNow;
        public CadastrarCategoriaDto() { }
    }

    public record NutrientesDto
    {
        public decimal Calorias { get; set; }
        public decimal Proteinas { get; set; }
        public decimal Carboidratos { get; set; }
        public decimal Fibras { get; set; }
        public decimal Gorduras { get; set; }

        public NutrientesDto() { }
    }
}
