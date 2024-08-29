using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using _.VerdeViva.Models.DTOS.Producao;

namespace _.VerdeViva.Models.Entities.Producao
{
    public class Categoria
    {
        [Key] 
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)] 
        public int Id { get; set; }

        [Required]
        public string Nome { get; set; }

        [Required]
        public string Descricao { get; set; }

        [Required]
        public DateTime DataCriacao { get; set; } = DateTime.UtcNow;

        private Categoria()
        {

        }

        public static Categoria From(CadastrarCategoriaProdutoDTO cadastrarCategoriaProdutoDTO)
        {
            Categoria categoria = new Categoria
            {
                Nome = cadastrarCategoriaProdutoDTO.Nome,
                Descricao = cadastrarCategoriaProdutoDTO.Descricao    
            };

            return categoria;
        }
    }
}