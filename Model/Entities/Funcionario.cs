using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Model.Entities
{
    public class Funcionario : Usuario
    {
        [Required]
        public string Senha { get; set; }
        public string Cargo { get; set; };

        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public string NumeroRegistro { get; set; }

        public Funcionario() { }
    }
}