using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Model.Dtos;

namespace Model.Entities
{
    public class Cliente
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public string Nome { get; set; }

        [Required]
        public string Senha { get; set; }

        public virtual Contato Contato { get; set; }
        public virtual Endereco Endereco { get; set; }

        public virtual ICollection<Pedido> Pedidos { get; set; } = new HashSet<Pedido>();

        public Cliente() { }

        public Cliente(CadastrarClienteDto cadastrarClienteDto)
        {
            Nome = cadastrarClienteDto.Nome;
            Senha = cadastrarClienteDto.Senha;
            Contato = new Contato
            {
                Telefone = cadastrarClienteDto.Telefone,
                Email = cadastrarClienteDto.Email,
            };
            Endereco = new Endereco
            {
                Logradouro = cadastrarClienteDto.Logradouro,
                Numero = cadastrarClienteDto.Numero,
                Cidade = cadastrarClienteDto.Cidade,
                CEP = cadastrarClienteDto.CEP,
                Complemento = cadastrarClienteDto.Complemento,
                Estado = cadastrarClienteDto.Estado,
                InformacoesAdicionais = cadastrarClienteDto.InformacoesAdicionais
            };
        }

        public Cliente(AtualizarClienteDto atualizarClienteDto)
        {
            Nome = atualizarClienteDto.Nome;
            Contato = new Contato
            {
                Telefone = atualizarClienteDto.Telefone,
                Email = atualizarClienteDto.Email,
            };
            Endereco = new Endereco
            {
                Logradouro = atualizarClienteDto.Logradouro,
                Numero = atualizarClienteDto.Numero,
                Cidade = atualizarClienteDto.Cidade,
                CEP = atualizarClienteDto.CEP,
                Complemento = atualizarClienteDto.Complemento,
                Estado = atualizarClienteDto.Estado,
                InformacoesAdicionais = atualizarClienteDto.InformacoesAdicionais
            };
        }
    }

    public class Contato
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public string Telefone { get; set; }
        public string Email { get; set; }

        public int ClienteId { get; set; }
        public virtual Cliente Cliente { get; set; }
    }

    public class Endereco
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public string Logradouro { get; set; }
        public string Numero { get; set; }
        public string Cidade { get; set; }
        public string CEP { get; set; }
        public string Complemento { get; set; }
        public string Estado { get; set; }
        public string InformacoesAdicionais { get; set; }

        public int ClienteId { get; set; }
        public virtual Cliente Cliente { get; set; }
    }
}