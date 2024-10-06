using Model.Entities;

namespace Model.Dtos
{
    public record ProdutoDto
    {
        public int Id { get; init; }
        public string Nome { get; init; }
        public string Descricao { get; init; }
        public decimal PrecoQuilo { get; init; }
        public int QuantidadeEstoque { get; init; }
        public string ImagemUrl { get; set; }
        public CategoriaDto Categoria { get; init; }
        public Nutrientes Nutrientes { get; set; }

        public ProdutoDto() { }
    }


    public record CadastrarProdutoDto
    {
        public string Nome { get; init; }
        public string Descricao { get; init; }
        public decimal PrecoQuilo { get; init; }
        public int QuantidadeEstoque { get; init; }
        public string ImagemUrl { get; set; }
        public CategoriaDto Categoria { get; init; }
        public Nutrientes Nutrientes { get; set; }

        public CadastrarProdutoDto() { }
    }

    public record CategoriaDto
    {
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public DateTime DataCriacao { get; set; } = DateTime.UtcNow;

        public CategoriaDto() { }
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
