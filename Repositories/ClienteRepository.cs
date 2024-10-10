
using Data;
using Exceptions;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Model.Entities;
using System;

namespace Repositories
{
    public interface IClienteRepository
    {
        Task<IEnumerable<Cliente>> BuscarTodosAsync();
        Task<Cliente> BuscarPorIdAsync(int id);
        Task<Cliente> BuscarPorEmailAsync(string email);
        Task<Cliente> CadastrarAsync(Cliente cliente);
        Task<Cliente> AtualizarAsync(Cliente cliente);
        Task<Cliente> AtualizarSenhaAsync(Cliente cliente);
        Task<Cliente> RemoverAsync(int id);
        Task<List<Pedido>> BuscarPedidosPorIdAsync(int id);
    }

    public class ClienteRepository : IClienteRepository
    {
        private readonly ApplicationDbContext _context;

        public ClienteRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Cliente>> BuscarTodosAsync()
        {
            var clientes = await _context.Clientes
                .AsNoTracking()
                .Include(c => c.Contato)
                .Include(c => c.Enderecos)
                .Include(c => c.Pedidos)
                .ToListAsync();

            if (clientes.IsNullOrEmpty()) 
            {
                throw new ResourceNotFoundException("Nenhum cliente encontrado.");
            }

            return clientes;
        }

        public async Task<Cliente> BuscarPorIdAsync(int id)
        {
            var cliente = await _context.Clientes
             .Include(c => c.Contato)
             .Include(c => c.Enderecos)
             .Include(c => c.Pedidos)
             .AsNoTracking()
             .FirstOrDefaultAsync(c => c.Id == id);

            if (cliente == null)
            {
                throw new ResourceNotFoundException($"Cliente com id {id} não encontrado.");
            }

            return cliente;
        }

        public async Task<Cliente> CadastrarAsync(Cliente cliente)
        {
            try
            {
                _context.Clientes.Add(cliente);
                await _context.SaveChangesAsync();
                return cliente;
            }
            catch (Exception ex)
            {
                throw new DatabaseManipulationException($"Erro ao cadastrar cliente. Causa: ${ex}.");
            }
        }

        public async Task<Cliente> AtualizarAsync(Cliente cliente)
        {
            try
            {
                _context.Clientes.Update(cliente);
                await _context.SaveChangesAsync();
                return cliente;
            }
            catch (Exception ex) 
            {
                throw new DatabaseManipulationException($"Erro ao atualizar cliente. Causa: ${ex}.");
            }
        }

        public async Task<Cliente> RemoverAsync(int id)
        {
            var cliente = await _context.Clientes
                .Include(c => c.Contato)
                .Include(c => c.Enderecos)
                .Include(c => c.Pedidos)
                .FirstOrDefaultAsync(c => c.Id == id);

            if (cliente == null)
            {
                throw new ResourceNotFoundException($"Cliente com id {id} não encontrado.");
            }

            try
            {
                _context.Clientes.Remove(cliente);
                await _context.SaveChangesAsync();
                return cliente;
            }
            catch (Exception ex) 
            {
                throw new DatabaseManipulationException($"Erro ao remover cliente. Causa: ${ex}.");
            }
        }

        public async Task<Cliente> BuscarPorEmailAsync(string email)
        {
            var cliente = await _context.Clientes
              .Include(c => c.Contato)
              .Include(c => c.Enderecos)
              .Include(c => c.Pedidos)
              .FirstOrDefaultAsync(c => c.Contato.Email == email);

            return cliente;
        }

        public async Task<Cliente> AtualizarSenhaAsync(Cliente cliente)
        {
            var clienteBanco = await _context.Clientes
                .Include(c => c.Contato)
                .Include(c => c.Enderecos)
                .Include(c => c.Pedidos)
                .FirstOrDefaultAsync(c => c.Id == cliente.Id);

            try
            {
                _context.Clientes.Update(clienteBanco);
                await _context.SaveChangesAsync();
                return clienteBanco;
            }
            catch (Exception ex)
            {
                throw new DatabaseManipulationException($"Erro ao atualizar a senha do cliente. Causa: ${ex}.");
            }
        }

        public async Task<List<Pedido>> BuscarPedidosPorIdAsync(int id)
        {
            var pedidos = await _context.Pedidos
                .AsNoTracking()
                .Include(p => p.Itens)
                .Where(p => p.ClienteId == id)
                .ToListAsync();

            if (pedidos.IsNullOrEmpty())
            {
                throw new ResourceNotFoundException($"Nenhum pedido encontrado para cliente com id {id}.");
            }

            return pedidos;
        }
    }

}
