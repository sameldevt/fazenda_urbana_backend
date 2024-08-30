using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using _.VerdeViva.Models.DTOS.Producao;
using _.VerdeViva.Models.Entities.Loja;
using Npgsql.Replication;

namespace _.VerdeViva.Models.Entities.Producao
{
    public class Produto
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public string Nome { get; set; }

        [Required]
        public string Descricao {get; set;}
        
        [Required]
        public decimal PrecoUnitario { get; set; }

        [Required]
        public decimal PrecoQuilo {get; set;}

        [Required]
        public int QuantidadeEstoque { get; set; }

        public string ImagemUrl {get; set;}

        [Required]
        public int FkNutriente {get; set;}

        public Nutriente Nutriente {get; set;}

        [Required]
        public int FkCategoria {get; set;}

        [Required]     
        public Categoria Categoria { get; set; }

        public ICollection<PedidoProduto> PedidoProdutos { get; set; }

        private Produto(){

        }

        public static Produto From(CadastrarProdutoDTO cadastrarProdutoDTO, Categoria categoria)
        {
            Produto produto = new Produto{
                Nome = cadastrarProdutoDTO.Nome,
                Descricao = cadastrarProdutoDTO.Descricao,
                PrecoUnitario = cadastrarProdutoDTO.PrecoUnitario,
                PrecoQuilo = cadastrarProdutoDTO.PrecoQuilo,
                QuantidadeEstoque = cadastrarProdutoDTO.QuantidadeEstoque,
                ImagemUrl = cadastrarProdutoDTO.ImagemUrl,
                Categoria = categoria,
                Nutriente = cadastrarProdutoDTO.Nutriente
            };

            return produto;
        } 
    }
}