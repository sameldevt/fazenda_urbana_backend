using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace _.VerdeViva.Models.Entities.Dashboard.Cliente;

public class Usuario
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    [Required]
    public string Nome { get; set; }

    [Required]
    public string Senha { get; set; }

    [Required]
    public Contato Contato { get; set; }
    
    [Required]
    public Endereco Endereco { get; set; }
}
