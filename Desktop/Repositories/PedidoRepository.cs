using _.Data;
using _.Desktop.Models;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata.Ecma335;

namespace _.Desktop.Repositories
{
    public interface IPedidoRepository
    {
        Task<IEnumerable<Pedido>> ListarTodosAsync();
        Task<Pedido> BuscarPorIdAsync(int id);
        Task CriarNovoAsync(Pedido pedido);
        Task AtualizarAsync(Pedido pedido);
        Task<Pedido> VerDetalhesAsync(int id);
        Task RemoverAsync(int id);
    }

    public class PedidoRepository : IPedidoRepository
    {
        private readonly ApplicationDbContext _context;

        public PedidoRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Pedido>> ListarTodosAsync()
        {
            return await _context.Pedidos.ToListAsync();
        }

        public async Task<Pedido> BuscarPorIdAsync(int id)
        {
            return await _context.Pedidos.FindAsync(id);
        }

        public async Task CriarNovoAsync(Pedido pedido)
        {
            _context.Pedidos.Add(pedido);
            await _context.SaveChangesAsync();
        }

        public async Task AtualizarAsync(Pedido pedido)
        {
            _context.Pedidos.Update(pedido);
            await _context.SaveChangesAsync();
        }

        public async Task RemoverAsync(int id)
        {
            var pedido = await _context.Pedidos.FindAsync(id);
            if (pedido != null)
            {
                _context.Pedidos.Remove(pedido);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<Pedido> VerDetalhesAsync(int id) => await _context.Pedidos.FindAsync(id);
    }

}
