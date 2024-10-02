using Model.Entities;

namespace Model.Dtos
{
    public record VisualizarPedidoDto
    {
        public int Id { get; init; }
        public DateTime DataPedido { get; init; }
        public DateTime DataEntrega { get; init; }
        public string Status { get; init; }
        public decimal Total { get; init; }
        public string EnderecoEntrega { get; init; }
        public string FormaPagamento { get; init; }
        public string Observacoes { get; init; }
        public ICollection<VisualizarItemPedidoDto> Itens { get; init; }

        public VisualizarPedidoDto() { }
    }

    public record CadastrarPedidoDto 
    {
        public int IdCliente { get; init; }
        public DateTime DataPedido { get; init; }
        public DateTime DataEntrega { get; init; }
        public string Status { get; init; }
        public decimal Total { get; init; }
        public string EnderecoEntrega { get; init; }
        public string FormaPagamento { get; init; }
        public string Observacoes { get; init; }
        public ICollection<VisualizarItemPedidoDto> Itens { get; init; }

        public CadastrarPedidoDto() { }
    }


    public record VisualizarItemPedidoDto
    {
        public int Id { get; init; }
        public VisualizarProdutoDto Produto { get; init; }
        public int Quantidade { get; init; }
        public decimal PrecoUnitario { get; init; }
        public decimal SubTotal { get; init; }

        public VisualizarItemPedidoDto() { }
    }

    public record CadastrarItemPedidoDto
    {
        public VisualizarProdutoDto Produto { get; init; }
        public int Quantidade { get; init; }
        public decimal PrecoUnitario { get; init; }
        public decimal SubTotal { get; init; }

        public CadastrarItemPedidoDto() { }
    }

    public record AlterarStatusPedidoDto
    {
        public int Id { get; init; }
        public string Status { get; init; }

        public AlterarStatusPedidoDto() { }
    }
}