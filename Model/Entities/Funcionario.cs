using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Model.Entities
{
    public class Funcionario : Usuario
    {
        [Required]
        public string Senha { get; set; }
        public string Cargo { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public string NumeroRegistro { get; set; }

        [Required]
        public int FazendaId { get; set; }
        public Fazenda Fazenda { get; set; }

        public Funcionario() { }
    }
}