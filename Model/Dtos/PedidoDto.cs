using Model.Entities;
using Model.Enum;

namespace Model.Dtos
{
    public record PedidoDto
    {
        public int Id { get; init; }
        public DateTime DataPedido { get; init; }
        public DateTime DataEntrega { get; init; }
        public StatusPedido Status { get; init; }
        public decimal Total { get; init; }
        public string EnderecoEntrega { get; init; }
        public string FormaPagamento { get; init; }
        public string Observacoes { get; init; }
        public ICollection<ItemPedidoDto> Itens { get; init; }

        public PedidoDto() { }
    }

    public record CadastrarPedidoDto 
    {
        public int IdCliente { get; init; }
        public DateTime DataPedido { get; init; }
        public DateTime DataEntrega { get; init; }
        public StatusPedido Status { get; init; }
        public decimal Total { get; init; }
        public string EnderecoEntrega { get; init; }
        public string FormaPagamento { get; init; }
        public string Observacoes { get; init; }
        public ICollection<ItemPedidoDto> Itens { get; init; }

        public CadastrarPedidoDto() { }
    }


    public record ItemPedidoDto
    {
        public int Id { get; init; }
        public ProdutoDto Produto { get; init; }
        public int Quantidade { get; init; }
        public decimal PrecoUnitario { get; init; }
        public decimal SubTotal { get; init; }

        public ItemPedidoDto() { }
    }
}