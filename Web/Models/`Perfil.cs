using _.Desktop.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace _.Web.Models
{
    public class Perfil
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public int ClienteId { get; set; }

        public virtual Cliente Cliente { get; set; }

        public string DataNascimento { get; set; }

        public string DocumentoIdentidade { get; set; }

        public string InformacoesAdicionais { get; set; }
    }
}
