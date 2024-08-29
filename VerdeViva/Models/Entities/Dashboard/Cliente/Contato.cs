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
    public int UsuarioId { get; set; }  // Este é tanto a chave primária quanto a estrangeira

    public string Telefone { get; set; }

    public string Email { get; set; }

    [ForeignKey("UsuarioId")]
    public Usuario Usuario {get; set;}  // Define a relação com Usuario
}
