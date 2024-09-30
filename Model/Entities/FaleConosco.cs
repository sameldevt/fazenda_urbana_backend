using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Model.Entities
{
    public class FaleConosco
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public string Nome { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        public string Mensagem { get; set; }

        public DateTime DataEnvio { get; set; } = DateTime.UtcNow;

        public bool Respondido { get; set; } = false;
    }
}
