using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Model.Entities
{
    public class Funcionario : Usuario
    {
        [Required]
        public string Senha { get; set; }
        public string Cargo { get; set; }

        public string NumeroRegistro { get; set; } = new Random().Next(100000, 999999).ToString();

        [Required]
        public int FazendaId { get; set; }

        public Fazenda Fazenda { get; set; }

        public Funcionario() { }
    }
}