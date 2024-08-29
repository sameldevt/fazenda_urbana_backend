using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace _.VerdeViva.Models.Entities.Dashboard.Cliente;

public class Endereco
{
    [Key]
    public int UsuarioId { get; set; }  // Este é tanto a chave primária quanto a estrangeira

    public string Logradouro {get; set;}

    public string Numero {get; set;}

    public string Cidade {get; set;}

    public string CEP {get; set;}
    
    public string Complemento {get; set;}

    public string Estado {get; set;}
    
    public string InformacoesAdicionais {get; set;}

    [ForeignKey("UsuarioId")]
    public Usuario Usuario {get; set;}  // Define a relação com Usuario
}