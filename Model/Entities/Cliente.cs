using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Model.Dtos;

namespace Model.Entities
{
    public class Cliente : Usuario
    {
        [Required]
        public string Senha { get; set; }

        public virtual ICollection<Pedido> Pedidos { get; set; } = new List<Pedido>();

        public Cliente() { }
    }

}