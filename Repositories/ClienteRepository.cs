
using Data;
using Microsoft.EntityFrameworkCore;
using Model.Entities;
using System;

namespace Repositories
{
    public interface IClienteRepository
    {
        Task<IEnumerable<Cliente>> ListarTodosAsync();
        Task<Cliente> BuscarPorIdAsync(int id);
        Task AdicionarAsync(Cliente cliente);
        Task AtualizarAsync(Cliente cliente);
        Task RemoverAsync(int id);
    }

    public class ClienteRepository : IClienteRepository
    {
        private readonly ApplicationDbContext _context;

        public ClienteRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Cliente>> ListarTodosAsync()
        {
            return await _context.Clientes.ToListAsync();
        }

        public async Task<Cliente> BuscarPorIdAsync(int id)
        {
            return await _context.Clientes.FindAsync(id);
        }

        public async Task AdicionarAsync(Cliente cliente)
        {
            _context.Clientes.Add(cliente);
            await _context.SaveChangesAsync();
        }

        public async Task AtualizarAsync(Cliente cliente)
        {
            _context.Clientes.Update(cliente);
            await _context.SaveChangesAsync();
        }

        public async Task RemoverAsync(int id)
        {
            var cliente = await _context.Clientes.FindAsync(id);
            if (cliente != null)
            {
                _context.Clientes.Remove(cliente);
                await _context.SaveChangesAsync();
            }
        }
    }

}
