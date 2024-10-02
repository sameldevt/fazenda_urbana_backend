
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
        Task<List<Cliente>> BuscarTodosAsync();
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

        public async Task<List<Cliente>> BuscarTodosAsync()
        {
            var clientes = await _context.Clientes.ToListAsync();

            if (clientes.IsNullOrEmpty()) 
            {
                throw new ResourceNotFoundException("Nenhum cliente encontrado.");
            }

            return clientes;
        }

        public async Task<Cliente> BuscarPorIdAsync(int id)
        {
            var cliente = await _context.Clientes.FindAsync(id);

            if(cliente == null)
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
            var cliente = await _context.Clientes.FindAsync(id);
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
    }

}
