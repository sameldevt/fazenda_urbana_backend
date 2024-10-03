using Data;
using Model.Entities;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata.Ecma335;
using Microsoft.IdentityModel.Tokens;
using Exceptions;

namespace Repositories
{
    public interface IPedidoRepository
    {
        Task<List<Pedido>> BuscarTodosAsync();
        Task<Pedido> BuscarPorIdAsync(int id);
        Task<Pedido> CadastrarAsync(Pedido pedido);
        Task<Pedido> AlterarStatusAsync(Pedido pedido);
        Task<Pedido> RemoverAsync(int id);
    }

    public class PedidoRepository : IPedidoRepository
    {
        private readonly ApplicationDbContext _context;

        public PedidoRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<Pedido>> BuscarTodosAsync()
        {
            var pedidos = await _context.Pedidos.AsNoTracking().ToListAsync();

            if (pedidos.IsNullOrEmpty())
            {
                throw new ResourceNotFoundException("Nenhum pedido encontrado.");
            }

            return pedidos;
        }

        public async Task<Pedido> BuscarPorIdAsync(int id)
        {
            var pedido = await _context.Pedidos.AsNoTracking().FirstOrDefaultAsync(p => p.Id == id);

            if (pedido == null)
            {
                throw new ResourceNotFoundException($"Pedido com id {id} não encontrado.");
            }

            return pedido;
        }

        public async Task<Pedido> CadastrarAsync(Pedido pedido)
        {
            try
            {
                _context.Pedidos.Add(pedido);
                await _context.SaveChangesAsync();
                return pedido;
            }
            catch (Exception ex)
            {
                throw new DatabaseManipulationException($"Erro ao cadastrar pedido. Causa: {ex}");
            }
        }

        public async Task<Pedido> AlterarStatusAsync(Pedido pedido)
        {
            try
            {
                _context.Pedidos.Update(pedido);
                await _context.SaveChangesAsync();
                return pedido;
            }
            catch (Exception ex)
            {
                throw new DatabaseManipulationException($"Erro ao alterar status do pedido. Causa: {ex}");
            }
        }

        public async Task<Pedido> RemoverAsync(int id)
        {
            var pedido = await _context.Pedidos.FindAsync(id);

            if(pedido == null)
            {
                throw new ResourceNotFoundException($"Pedido com id {id} não encontrado.");
            }

            try
            {
                _context.Pedidos.Remove(pedido);
                await _context.SaveChangesAsync();
                return pedido;
            }
            catch (Exception ex)
            {
                throw new DatabaseManipulationException($"Erro ao remover pedido. Causa: {ex}.");
            }
        }
    }
}
