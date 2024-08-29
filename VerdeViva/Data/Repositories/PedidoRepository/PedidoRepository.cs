using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using _.VerdeViva.Models.Entities.Loja;

namespace _.VerdeViva.Data.Repositories.PedidoRepository;

public class PedidoRepository : IPedidoRepository
{
    private readonly ApplicationDbContext _context;

    public PedidoRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async void Registrar(Pedido pedido)
    {
         _context.Pedido.Add(pedido);
        await _context.SaveChangesAsync();
    }
}
