﻿using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Model.Dtos;

namespace Model.Entities
{
    public class Produto
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public string Nome { get; set; }

        public string Descricao { get; set; }

        [Required]
        [Column(TypeName = "decimal(18,2)")]
        public decimal PrecoUnitario { get; set; }

        [Required]
        [Column(TypeName = "decimal(18,2)")]
        public decimal PrecoQuilo { get; set; }

        [Required]
        public int QuantidadeEstoque { get; set; }

        [Required]
        public int CategoriaId { get; set; }

        public virtual Categoria Categoria { get; set; }

        public string ImagemUrl { get; set; }

        public virtual Nutrientes Nutrientes { get; set; }
        
        public Produto()
        {

        }

        public Produto(VisualizarProdutoDto visualizarProdutoDto)
        {
            Id = visualizarProdutoDto.Id;
            Nome = visualizarProdutoDto.Nome;
            Descricao = visualizarProdutoDto.Descricao;
            PrecoUnitario = visualizarProdutoDto.PrecoUnitario;
            PrecoQuilo = visualizarProdutoDto.PrecoQuilo;
            QuantidadeEstoque = visualizarProdutoDto.QuantidadeEstoque;
            Categoria = new Categoria(visualizarProdutoDto);
            ImagemUrl = visualizarProdutoDto.ImagemUrl;
            Nutrientes = new Nutrientes(visualizarProdutoDto);
        }

        public Produto(CadastrarProdutoDto cadastrarProdutoDto)
        {
            Nome = cadastrarProdutoDto.Nome;
            Descricao = cadastrarProdutoDto.Descricao;
            PrecoUnitario = cadastrarProdutoDto.PrecoUnitario;
            PrecoQuilo = cadastrarProdutoDto.PrecoQuilo;
            QuantidadeEstoque = cadastrarProdutoDto.QuantidadeEstoque;
            Categoria = new Categoria(cadastrarProdutoDto);
            ImagemUrl = cadastrarProdutoDto.ImagemUrl;
            Nutrientes = new Nutrientes(cadastrarProdutoDto);
        }
    }

    public class Categoria
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public DateTime DataCriacao { get; set; } = DateTime.UtcNow;
        public ICollection<Produto> Produtos { get; set; }

        public Categoria()
        {

        }

        public Categoria(VisualizarProdutoDto visualizarProdutoDto)
        {
            Nome = visualizarProdutoDto.NomeCategoria;
            Descricao = visualizarProdutoDto.DescricaoCategoria;
        }
    }

    public class Nutrientes
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public int ProdutoId { get; set; }

        public virtual Produto Produto { get; set; }

        public decimal Calorias { get; set; }
        public decimal Proteinas { get; set; }
        public decimal Carboidratos { get; set; }
        public decimal Fibras { get; set; }
        public decimal Gorduras { get; set; }

        public Nutrientes()
        {

        }

        public Nutrientes(VisualizarProdutoDto visualizarProdutoDto)
        {
            Calorias = visualizarProdutoDto.Calorias;
            Proteinas = visualizarProdutoDto.Proteinas;
            Carboidratos = visualizarProdutoDto.Carboidratos;
            Fibras = visualizarProdutoDto.Fibras;
            Gorduras = visualizarProdutoDto.Gorduras;
        }
    }
}
