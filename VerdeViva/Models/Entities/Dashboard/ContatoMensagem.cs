using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using _.VerdeViva.Models.DTOS.Dashboard;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace _.VerdeViva.Models.Entities.Dashboard;

public class ContatoMensagem
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id {get; set;}
    public string Nome {get; set;}
    public string Sobrenome {get; set;}
    public string Email {get; set;}
    public string Mensagem {get; set;}

    private ContatoMensagem()
    {

    }

    public static ContatoMensagem From(ContatoMensagemDTO contatoMensagemDTO)
    {
        ContatoMensagem contatoMensagem = new ContatoMensagem
        {
            Nome = contatoMensagemDTO.Nome,
            Sobrenome = contatoMensagemDTO.Sobrenome,
            Email = contatoMensagemDTO.Email,
            Mensagem = contatoMensagemDTO.Mensagem
        };

        return contatoMensagem;
    }
}
