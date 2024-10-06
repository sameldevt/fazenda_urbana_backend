using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Model.Entities
{
    public class MensagemContato
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public string NomeUsuario { get; set; }

        [Required]
        [EmailAddress]
        public string EmailUsuario { get; set; }

        [Required]
        public string Conteudo { get; set; }

        
        public DateTime DataEnvio { get; set; } = DateTime.UtcNow;


        public bool Respondido { get; set; } = false;
    }
}
