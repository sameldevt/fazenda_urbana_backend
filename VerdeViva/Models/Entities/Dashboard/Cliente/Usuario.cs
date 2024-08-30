using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using _.VerdeViva.Models.DTOS.Dashboard;
using _.VerdeViva.Models.Entities.Loja;

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

    public ICollection<Pedido> Pedidos { get; set; }

    public Contato Contato { get; set; }

    public Endereco Endereco { get; set; }

    private Usuario(){

    }

    public static Usuario From(EfetuarCadastroDTO efetuarCadastroDTO)
    {
        Contato contato = new Contato
        {
            Email = efetuarCadastroDTO.Email,
            Telefone = efetuarCadastroDTO.Telefone
        };

        Usuario usuario = new Usuario{
            Nome = efetuarCadastroDTO.NomeCompleto,
            Senha = efetuarCadastroDTO.Senha,
            Contato = contato,
        };

        return usuario;
    }
}