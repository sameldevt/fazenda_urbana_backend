using Model.Entities;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Model.Enum;

namespace Model.Dtos
{
    public record FazendaDto
    {
        public int Id { get; set; }
        public string Nome { get; set; }

        public string Localizacao { get; set; }

        public double Area { get; set; }

        public DateTime DataFundacao { get; set; }
            
        public ICollection<FuncionarioDto> Funcionarios { get; set; }

        public ICollection<EquipamentoDto> Equipamentos { get; set; }

        public ICollection<ColheitaDto> Colheitas { get; set; }

        public int NumeroEstufas { get; set; }

        public bool Ativo { get; set; }
    }

    public record CadastrarFazendaDto
    {
        public string Nome { get; set; }
        public string Localizacao { get; set; }
        public double Area { get; set; }
        public DateTime DataFundacao { get; set; }
        public ICollection<int> FuncionariosIds { get; set; }
        public ICollection<int> EquipamentosIds { get; set; }
        public ICollection<int> ColheitasIds { get; set; }
        public int NumeroEstufas { get; set; }
        public bool Ativo { get; set; }

        public CadastrarFazendaDto() { }
    }

    public record ColheitaDto
    {
        public int Id { get; set; }
        public DateTime DataInicio { get; set; }
        public DateTime DataFim { get; set; }
        public decimal AreaColhida { get; set; }
        public decimal QuantidadeColhida { get; set; }
        public int ProdutoId { get; set; }
        public int CulturaId { get; set; }
        public CulturaDto Cultura { get; set; }
    }

    public record CadastrarColheitaDto
    {
        public DateTime DataInicio { get; set; }

        public DateTime DataFim { get; set; }

        public decimal AreaColhida { get; set; }

        public decimal QuantidadeColhida { get; set; }

        public int ProdutoId { get; set; }

        public int CulturaId { get; set; }
    }
    

    public record CulturaDto
    {
        public int Id { get; set; }

        public string Nome { get; set; }

        public TipoColheita Tipo { get; set; }

        public CicloCultura Ciclo { get; set; }

        public DateTime DataPlantio { get; set; }

        public DateTime DataColheitaPrevista { get; set; }

        public CulturaDto() { }
    }

    public record CadastrarCulturaDto
    {
        public string Nome { get; set; }

        public TipoColheita Tipo { get; set; }

        public CicloCultura Ciclo { get; set; }

        public DateTime DataPlantio { get; set; }

        public DateTime DataColheitaPrevista { get; set; }

        public CadastrarCulturaDto() { }
    }
}
