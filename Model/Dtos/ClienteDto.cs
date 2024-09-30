using Model.Entities;

namespace Model.Dtos
{
    public record ClienteDto
    (
        string Nome,
        string Senha,
        Contato Contato,
        Endereco Endereco,
        ICollection<Pedido> Pedidos
    );
}
