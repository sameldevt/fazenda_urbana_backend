using Model.Entities;

namespace Model.Dtos
{
    public interface IPedidoDto { }

    public static class PedidoDtoFactory
    {
        public static IPedidoDto Criar(TipoDto tipoDto, Pedido pedido)
        {
            return tipoDto switch
            {
                TipoDto.Visualizar => new VisualizarPedidoDto(pedido),
                TipoDto.Cadastrar => new CadastrarPedidoDto(pedido),
            };
        }
    }

    public interface IItemPedidoDto { }

    public static class ItemPedidoDtoFactory
    {
        public static IItemPedidoDto Criar(TipoDto tipoDto, ItemPedido itemPedido)
        {
            return tipoDto switch
            {
                TipoDto.Visualizar => new VisualizarItemPedidoDto(itemPedido),
                TipoDto.Cadastrar => new CadastrarItemPedidoDto(itemPedido),
            };
        }
    }

    public record VisualizarPedidoDto : IPedidoDto
    {
        public int Id { get; init; }
        public DateTime DataPedido { get; init; }
        public DateTime DataEntrega { get; init; }
        public string Status { get; init; }
        public decimal Total { get; init; }
        public string EnderecoEntrega { get; init; }
        public string FormaPagamento { get; init; }
        public string Observacoes { get; init; }
        public ICollection<IItemPedidoDto> Itens { get; init; }

        public VisualizarPedidoDto() { }

        public VisualizarPedidoDto(Pedido pedido) : this()
        {
            Id = pedido.Id;
            DataPedido = pedido.DataPedido;
            DataEntrega = pedido.DataEntrega ?? DateTime.MinValue;
            Status = pedido.Status;
            Total = pedido.Total;
            EnderecoEntrega = pedido.EnderecoEntrega;
            FormaPagamento = pedido.FormaPagamento;
            Observacoes = pedido.Observacoes;
            Itens = pedido.Itens.Select(p => ItemPedidoDtoFactory.Criar(TipoDto.Visualizar, p)).ToList();
        }
    }

    public record CadastrarPedidoDto : IPedidoDto
    {
        public int IdCliente { get; init; }
        public DateTime DataPedido { get; init; }
        public DateTime DataEntrega { get; init; }
        public string Status { get; init; }
        public decimal Total { get; init; }
        public string EnderecoEntrega { get; init; }
        public string FormaPagamento { get; init; }
        public string Observacoes { get; init; }
        public ICollection<IItemPedidoDto> Itens { get; init; }

        public CadastrarPedidoDto() { }

        public CadastrarPedidoDto(Pedido pedido) : this()
        {
            IdCliente = pedido.ClienteId;
            DataPedido = pedido.DataPedido;
            DataEntrega = pedido.DataEntrega ?? DateTime.MinValue;
            Status = pedido.Status;
            Total = pedido.Total;
            EnderecoEntrega = pedido.EnderecoEntrega;
            FormaPagamento = pedido.FormaPagamento;
            Observacoes = pedido.Observacoes;
            Itens = pedido.Itens.Select(i => ItemPedidoDtoFactory.Criar(TipoDto.Cadastrar, i)).ToList();
        }
    }


    public record VisualizarItemPedidoDto : IItemPedidoDto
    {
        public int Id { get; init; }
        public IProdutoDto Produto { get; init; }
        public int Quantidade { get; init; }
        public decimal PrecoUnitario { get; init; }
        public decimal SubTotal { get; init; }

        public VisualizarItemPedidoDto() { }

        public VisualizarItemPedidoDto(ItemPedido itemPedido) : this()
        {
            Id = itemPedido.Id;
            Produto = ProdutoDtoFactory.Criar(TipoDto.Visualizar, itemPedido.Produto);
            Quantidade = itemPedido.Quantidade;
            PrecoUnitario = itemPedido.PrecoUnitario;
            SubTotal = itemPedido.SubTotal;
        }
    }

    public record CadastrarItemPedidoDto : IItemPedidoDto
    {
        public VisualizarProdutoDto Produto { get; init; }
        public int Quantidade { get; init; }
        public decimal PrecoUnitario { get; init; }
        public decimal SubTotal { get; init; }

        public CadastrarItemPedidoDto() { }

        public CadastrarItemPedidoDto(ItemPedido itemPedido) : this()
        {
            Produto = (VisualizarProdutoDto)ProdutoDtoFactory.Criar(TipoDto.Cadastrar, itemPedido.Produto);
            Quantidade = itemPedido.Quantidade;
            PrecoUnitario = itemPedido.PrecoUnitario;
            SubTotal = itemPedido.SubTotal;
        }
    }

    public record AlterarStatusPedidoDto
    {
        public int Id { get; init; }
        public string Status { get; init; }

        public AlterarStatusPedidoDto() { }

        public AlterarStatusPedidoDto(int id, string status) : this()
        {
            Id = id;
            Status = status;
        }
    }
}