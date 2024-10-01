
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
        Task<Cliente> CadastrarAsync(Cliente cliente);
        Task<Cliente> AtualizarAsync(Cliente cliente);
        Task<Cliente> RemoverAsync(int id);
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

        public async Task<Cliente> CadastrarAsync(Cliente cliente)
        {
            _context.Clientes.Add(cliente);
            await _context.SaveChangesAsync();

            return cliente;
        }

        public async Task<Cliente> AtualizarAsync(Cliente cliente)
        {
            _context.Clientes.Update(cliente);
            await _context.SaveChangesAsync();

            return cliente;
        }

        public async Task<Cliente> RemoverAsync(int id)
        {
            var cliente = await _context.Clientes.FindAsync(id);
            if (cliente != null)
            {
                _context.Clientes.Remove(cliente);
                await _context.SaveChangesAsync();
                return cliente;
            }

            return null;
        }
    }

}
