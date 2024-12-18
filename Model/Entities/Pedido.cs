﻿using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Services;
using Model.Dtos;
using Model.Enum;

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
        public StatusPedido Status { get; set; }

        [Required]
        [Column(TypeName = "decimal(18,2)")]
        public decimal Total { get; set; }

        public string EnderecoEntrega { get; set; }

        public string FormaPagamento { get; set; }

        public virtual ICollection<ItemPedido> Itens { get; set; } = new HashSet<ItemPedido>();

        public Pedido() { }
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
        public decimal Quantidade { get; set; }

        [Required]
        [Column(TypeName = "decimal(18,2)")]
        public decimal SubTotal { get; set; }

        public ItemPedido() { }

        public override string ToString()
        {
            return $"{Quantidade}";
        }
    }
}
