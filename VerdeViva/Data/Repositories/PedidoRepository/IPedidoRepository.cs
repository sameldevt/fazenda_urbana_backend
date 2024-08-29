using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using _.VerdeViva.Models.Entities.Loja;

namespace _.VerdeViva.Data.Repositories.PedidoRepository;

public interface IPedidoRepository
{
    void Registrar(Pedido pedido);
}
