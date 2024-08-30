using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace _.VerdeViva.Models.Entities.Dashboard.Cliente;

public class Contato
{
    [Key]
    public int Id { get; set; }

    [Required]
    public int FkUsuario { get; set; } 

    [Required]
    public string Telefone { get; set; }
    
    [Required]
    public string Email { get; set; }

    public Usuario Usuario { get; set; }
}
