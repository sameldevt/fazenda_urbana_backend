using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace _.VerdeViva.Models.Entities.Dashboard.Cliente;

public class Endereco
{
    [Key, ForeignKey("Usuario")]
    public int UsuarioId { get; set; }

    [Required]
    public string Logradouro {get; set;}
    
    [Required]
    public string Numero {get; set;}
    
    [Required]
    public string Cidade {get; set;}
    
    [Required]
    public string CEP {get; set;}
    public string Complemento {get; set;}
    
    [Required]
    public string Estado {get; set;}
    public string InformacoesAdicionais {get; set;}
    public Usuario Usuario {get; set;}
}
