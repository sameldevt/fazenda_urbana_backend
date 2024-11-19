using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Model.Enum;
using Services;

namespace Model.Entities
{
    public class Fazenda
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public string Nome { get; set; }

        public string Localizacao { get; set; }

        public double Area { get; set; }

        public DateTime DataFundacao { get; set; }

        public ICollection<Funcionario> Funcionarios { get; set; }

        public ICollection<Equipamento> Equipamentos { get; set; }

        public ICollection<Cultura> Culturas { get; set; }

        public int NumeroEstufas { get; set; }

        public bool Ativo { get; set; }
    }


    public class Colheita
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public DateTime DataInicio { get; set; }

        public DateTime DataFim { get; set; }

        public decimal AreaColhida { get; set; }

        public decimal QuantidadeColhida { get; set; }

        [Required]
        public int ProdutoId { get; set; }

        public Produto Produto { get; set; }

        [Required]
        public int CulturaId { get; set; }

        public Cultura Cultura { get; set; }

        public Colheita() { }
    }

    public class Cultura
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public string Nome { get; set; }

        [Required]
        public TipoColheita Tipo { get; set; }

        [Required]
        public CicloCultura Ciclo { get; set; }

        [Required]
        public DateTime DataPlantio { get; set; }

        [Required]
        public DateTime DataColheitaPrevista { get; set; }

        [Required]
        public int ProdutoId { get; set; }

        public Produto Produto { get; set; }

        public ICollection<Colheita> Colheitas { get; set; }

        public ICollection<CulturaInsumo> CulturaInsumos { get; set; }

        [Required]
        public int FazendaId { get; set; }

        public Fazenda Fazenda { get; set; } 

        public Cultura() { }
    }

    public class CulturaInsumo
    {
        [Required]
        public int CulturaId { get; set; }
        public Cultura Cultura { get; set; }

        [Required]
        public int InsumoId { get; set; }
        public Insumo Insumo { get; set; }

        public decimal Quantidade { get; set; }
    }

}
