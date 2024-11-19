using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Model.Dtos;
using Model.Enum;

namespace Model.Entities
{
    public class Fornecedor : Usuario
    {
        [Required]
        public string CNPJ { get; set; }
        public string Website { get; set; }
        public virtual ICollection<Insumo> Insumos { get; set; }
        public virtual ICollection<Equipamento> Equipamentos { get; set; }

        public Fornecedor() { }
    }

    public class Insumo
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public string Nome { get; set; }

        public string Descricao { get; set; }

        public string ImagemUrl { get; set; }

        [Required]
        public string Categoria { get; set; }

        [Required]
        public decimal QuantidadeEstoque { get; set; }

        [Required]
        public decimal PrecoUnitario { get; set; }

        [Required]
        public DateTime DataCompra { get; set; }

        [Required]
        public DateTime DataFabricacao { get; set; }

        [Required]
        public DateTime DataVencimento { get; set; }

        [Required]
        public int FornecedorId { get; set; }

        public Fornecedor Fornecedor { get; set; }

        public ICollection<CulturaInsumo> CulturaInsumos { get; set; }

        public Insumo() { }
    }

    public class Equipamento
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public string Nome { get; set; }

        [Required]
        public string Descricao { get; set; }

        public string ImagemUrl { get; set; }

        [Required]
        public TipoEquipamento Tipo { get; set; }

        [Required]
        public string Marca { get; set; }

        [Required]
        public string Modelo { get; set; }

        [Required]
        public DateTime DataCompra { get; set; }

        [Required]
        public string AnoFabricacao { get; set; }

        [Required]
        public decimal ValorAquisicao { get; set; }

        [Required]
        public string LocalizacaoAtual { get; set; }

        [Required]
        public int FazendaId { get; set; }

        public Fazenda Fazenda { get; set; }

        [Required]
        public int FornecedorId { get; set; }

        public Fornecedor Fornecedor { get; set; }

        public Equipamento () { } 
    }
}
