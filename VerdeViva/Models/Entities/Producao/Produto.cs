using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

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
        public decimal PrecoUnitario { get; set; }       
        
        public int CategoriaId { get; set; }

        [Required]
        [ForeignKey("CategoriaId")]
        public Categoria Categoria { get; set; }
    }
}