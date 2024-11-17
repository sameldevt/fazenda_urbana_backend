using Model.Entities;
using Model.Enum;
using System.ComponentModel.DataAnnotations;

namespace Model.Dtos
{
    public record FornecedorDto : UsuarioDto
    {
        public string Website { get; init; }
        public string CNPJ { get; init; }
        public virtual ICollection<InsumoDto> Insumos { get; set; }
        public virtual ICollection<EquipamentoDto> Equipamentos { get; set; }

        public FornecedorDto() { }
    }

    public record CadastrarFornecedorDto
    {
        public string Nome { get; init; }
        public string CNPJ { get; init; }
        public string Website { get; init; }
        public DateTime DataCadastro { get; init; }
        public ContatoDto Contato { get; init; }
        public ICollection<EnderecoDto> Enderecos { get; init; }

        public CadastrarFornecedorDto() { }
    }

    public record InsumoDto
    {
        public int Id { get; set; }

        public string Nome { get; set; }

        public string Descricao { get; set; }

        public string ImagemUrl { get; set; }

        public string Categoria { get; set; }

        public decimal QuantidadeEstoque { get; set; }

        public decimal PrecoUnitario { get; set; }

        public DateTime DataCompra { get; set; }

        public DateTime DataFabricacao { get; set; }

        public DateTime DataVencimento { get; set; }

        public int FornecedorId { get; set; }

        public InsumoDto() { }
    }

    public record CadastrarInsumoDto
    {
        public string Nome { get; set; }

        public string Descricao { get; set; }

        public string Categoria { get; set; }

        public string ImagemUrl { get; set; }

        public decimal QuantidadeEstoque { get; set; }

        public decimal PrecoUnitario { get; set; }

        public DateTime DataCompra { get; set; }

        public DateTime DataFabricacao { get; set; }

        public DateTime DataVencimento { get; set; }

        public int FornecedorId { get; set; }

        public CadastrarInsumoDto() { }
    }

    public record EquipamentoDto
    {
        public int Id { get; set; }

        public string Nome { get; set; }

        public string Descricao { get; set; }

        public string ImagemUrl { get; set; }

        public TipoEquipamento Tipo { get; set; }

        public string Marca { get; set; }

        public string Modelo { get; set; }

        public DateTime DataCompra { get; set; }

        public string AnoFabricacao { get; set; }

        public decimal ValorAquisicao { get; set; }

        public string LocalizacaoAtual { get; set; }

        public int FornecedorId { get; set; }

        public EquipamentoDto() { }

    }

    public record CadastrarEquipamentoDto 
    {
        public string Nome { get; set; }

        public string Descricao { get; set; }

        public string ImagemUrl { get; set; }

        public TipoEquipamento Tipo { get; set; }

        public string Marca { get; set; }

        public string Modelo { get; set; }

        public DateTime DataCompra { get; set; }

        public string AnoFabricacao { get; set; }

        public decimal ValorAquisicao { get; set; }

        public string LocalizacaoAtual { get; set; }

        public int FornecedorId { get; set; }

        public CadastrarEquipamentoDto() { }
    }
}
