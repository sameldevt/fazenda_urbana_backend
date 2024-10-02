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

    public record VisualizarPedidoDto
    (
        int Id,
        DateTime DataPedido,
        DateTime DataEntrega,
        string Status,
        decimal Total,
        string EnderecoEntrega,
        string FormaPagamento,
        string Observacoes,
        ICollection<IItemPedidoDto> Itens
    ) : IPedidoDto
    {
        public VisualizarPedidoDto(Pedido pedido) : this(
            pedido.Id,
            pedido.DataPedido,
            pedido.DataEntrega ?? DateTime.MinValue,
            pedido.Status,
            pedido.Total,
            pedido.EnderecoEntrega,
            pedido.FormaPagamento,
            pedido.Observacoes,
            pedido.Itens.Select(p => ItemPedidoDtoFactory.Criar(TipoDto.Visualizar, p)).ToList()
        )
        { }
    }


    public record CadastrarPedidoDto
    (
        int IdCliente,
        DateTime DataPedido,
        DateTime DataEntrega,
        string Status,
        decimal Total,
        string EnderecoEntrega,
        string FormaPagamento,
        string Observacoes,
        ICollection<IItemPedidoDto> Itens
    ) : IPedidoDto
    {
        public CadastrarPedidoDto(Pedido pedido) : this(
            pedido.ClienteId,
            pedido.DataPedido,
            pedido.DataEntrega ?? DateTime.MinValue,
            pedido.Status,
            pedido.Total,
            pedido.EnderecoEntrega,
            pedido.FormaPagamento,
            pedido.Observacoes,
            pedido.Itens.Select(i => ItemPedidoDtoFactory.Criar(TipoDto.Cadastrar, i)).ToList()
            )
        {

        }
    }

    public record VisualizarItemPedidoDto
    (
        int Id,
        IProdutoDto Produto,
        int Quantidade,
        decimal PrecoUnitario,
        decimal SubTotal
    ) : IItemPedidoDto
    {
        public VisualizarItemPedidoDto(ItemPedido itemPedido) : this(
            itemPedido.Id,
            ProdutoDtoFactory.Criar(TipoDto.Visualizar, itemPedido.Produto),
            itemPedido.Quantidade,
            itemPedido.PrecoUnitario,
            itemPedido.SubTotal
        )
        { }
    }

    public record CadastrarItemPedidoDto
    (
        VisualizarProdutoDto Produto,
        int Quantidade,
        decimal PrecoUnitario,
        decimal SubTotal
    ) : IItemPedidoDto
    {
        public CadastrarItemPedidoDto(ItemPedido itemPedido) : this(
            (VisualizarProdutoDto)ProdutoDtoFactory.Criar(TipoDto.Cadastrar, itemPedido.Produto),
            itemPedido.Quantidade,
            itemPedido.PrecoUnitario,
            itemPedido.SubTotal
        )
        { }
    }


    public record AlterarStatusPedidoDto
    (
        int Id,
        string Status
    );
}