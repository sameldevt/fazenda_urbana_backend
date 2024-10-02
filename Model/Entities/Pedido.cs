using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Services;
using Model.Dtos;

namespace Model.Entities
{
    public class Pedido
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public int ClienteId { get; set; }

        public virtual Cliente Cliente { get; set; }

        [Required]
        public DateTime DataPedido { get; set; }

        public DateTime? DataEntrega { get; set; }

        [Required]
        public string Status { get; set; }

        [Required]
        [Column(TypeName = "decimal(18,2)")]
        public decimal Total { get; set; }

        public string EnderecoEntrega { get; set; }

        public string FormaPagamento { get; set; }

        public string Observacoes { get; set; }

        public virtual ICollection<ItemPedido> Itens { get; set; } = new HashSet<ItemPedido>();

        public Pedido() { }

        public Pedido(CadastrarPedidoDto cadastrarPedidoDto)
        {
            ClienteId = cadastrarPedidoDto.IdCliente;
            DataPedido = cadastrarPedidoDto.DataPedido;
            DataEntrega = cadastrarPedidoDto.DataEntrega;
            Status = cadastrarPedidoDto.Status;
            Total = cadastrarPedidoDto.Total;
            EnderecoEntrega = cadastrarPedidoDto.EnderecoEntrega;
            FormaPagamento = cadastrarPedidoDto.FormaPagamento;
            Observacoes = cadastrarPedidoDto.Observacoes;
            Itens = cadastrarPedidoDto.Itens.Select(i => new ItemPedido(i)).ToList();
        }
    }

    public class ItemPedido
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public int PedidoId { get; set; }

        public virtual Pedido Pedido { get; set; }

        [Required]
        public int ProdutoId { get; set; }

        public virtual Produto Produto { get; set; }

        [Required]
        public int Quantidade { get; set; }

        [Required]
        [Column(TypeName = "decimal(18,2)")]
        public decimal PrecoUnitario { get; set; }

        [Required]
        [Column(TypeName = "decimal(18,2)")]
        public decimal SubTotal { get; set; }

        public ItemPedido() { }

        public ItemPedido(IItemPedidoDto cadastrarItemPedidoDto) 
        {
            var dto = (CadastrarItemPedidoDto)cadastrarItemPedidoDto;

            Produto = new Produto(dto.Produto);
            Quantidade = dto.Quantidade;
            PrecoUnitario = dto.PrecoUnitario;
            SubTotal = dto.SubTotal;
        }
    }
}
