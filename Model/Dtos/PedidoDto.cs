using Model.Entities;

namespace Model.Dtos
{
    public enum PedidoDtoTipo
    {
        Visualizar,
        Cadastrar,
        Atualizar,
    }
    public interface IPedidoDto { }

    public static class PedidoDtoFactory
    {
        public static IPedidoDto Criar(PedidoDtoTipo tipoDto, Pedido pedido)
        {
            return tipoDto switch
            {

            }
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
        ICollection<IPedidoDto> Itens
    ) : IPedidoDto
    {
        public VisualizarPedidoDto(Pedido pedido) : this(
            Id: pedido.Id,
            DataPedido: pedido.DataPedido,
            DataEntrega: pedido.DataEntrega ?? DateTime.MinValue,
            Status: pedido.Status,
            Total: pedido.Total,
            EnderecoEntrega: pedido.EnderecoEntrega,
            FormaPagamento: pedido.FormaPagamento,
            Observacoes: pedido.Observacoes,
            Itens: pedido.Itens.Select(p => PedidoDtoFactory.Criar(PedidoDtoTipo.Visualizar, p)).ToList()
        )
        { }
    }

    public record VisualizarItemPedidoDto
    (
        int Id,
        IProdutoDto Produto,
        int Quantidade,
        decimal PrecoUnitario,
        decimal SubTotal
    ) : IPedidoDto
    {
        public VisualizarItemPedidoDto(ItemPedido itemPedido) : this(
            itemPedido.Id,
            ProdutoDtoFactory.Criar(ProdutoDtoTipo.Visualizar, itemPedido.Produto),
            itemPedido.Quantidade,
            itemPedido.PrecoUnitario,
            itemPedido.Subtotal
        )
        { }
    }

    public record CadastrarItemPedidoDto
    (
        CadastrarProdutoDto Produto,
        int Quantidade,
        decimal PrecoUnitario,
        decimal SubTotal
    ) : IPedidoDto
    {
        public CadastrarItemPedidoDto()
        {

        }
    }

    public record CadastrarPedidoDto
    (
        DateTime DataPedido,
        DateTime DataEntrega,
        string Status,
        decimal Total,
        string EnderecoEntrega,
        string FormaPagamento,
        string Observacoes,
        ICollection<VisualizarItemPedidoDto> Itens
    )
    {
        public static Pedido ConverterDto(CadastrarPedidoDto cadastrarPedidoDto)
        {
            return new Pedido
            {
                DataPedido = cadastrarPedidoDto.DataPedido,
                DataEntrega = cadastrarPedidoDto.DataEntrega,
                Status = cadastrarPedidoDto.Status,
                Total = cadastrarPedidoDto.Total,
                EnderecoEntrega = cadastrarPedidoDto.EnderecoEntrega,
                FormaPagamento = cadastrarPedidoDto.FormaPagamento,
                Observacoes = cadastrarPedidoDto.Observacoes,
                Itens = cadastrarPedidoDto.Itens.Select(i =>
                    new ItemPedido
                    {
                        Id = i.Id,
                        Produto = VisualizarProdutoDto.ConverterProdutoDto(i.Produto),
                        Quantidade = i.Quantidade,
                        PrecoUnitario = i.PrecoUnitario,
                        Subtotal = i.SubTotal
                    }
                ).ToList()
            };
        }
    }

    public record AlterarStatusPedidoDto
    (
        int Id,
        string Status
    );
}