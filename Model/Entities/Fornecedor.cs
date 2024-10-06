using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Model.Dtos;

namespace Model.Entities
{
    public class Fornecedor : Usuario
    {
        [Required]
        public string CNPJ { get; set; }
        public string Website { get; set; }
        public virtual ICollection<Produto> Produtos { get; set; } = new List<Produto>();
        public Fornecedor() { }
    }
}
