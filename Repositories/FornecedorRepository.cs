using Data;
using Model.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Exceptions;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace Repositories
{
    public interface IFornecedorRepository
    {
        Task<List<Fornecedor>> BuscarTodosAsync();
        Task<Fornecedor> BuscarPorIdAsync(int id);
        Task<Fornecedor> CadastrarAsync(Fornecedor fornecedor);
        Task<Fornecedor> AtualizarAsync(Fornecedor fornecedor);
        Task<Fornecedor> RemoverAsync(int id);
    }

    public class FornecedorRepository : IFornecedorRepository
    {
        private readonly ApplicationDbContext _context;

        public FornecedorRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<Fornecedor>> BuscarTodosAsync()
        {
            var fornecedores = await _context.Fornecedores.AsNoTracking().ToListAsync();

            if (fornecedores.IsNullOrEmpty())
            {
                throw new ResourceNotFoundException("Nenhum fornecedor encontrado.");
            }

            return fornecedores;
        }

        public async Task<Fornecedor> BuscarPorIdAsync(int id)
        {
            var fornecedor = await _context.Fornecedores.AsNoTracking().FirstOrDefaultAsync(f => f.Id == id);

            if (fornecedor == null)
            {
                throw new ResourceNotFoundException($"Fornecedor com id {id} não encontrado.");
            }

            return fornecedor;
        }

        public async Task<Fornecedor> CadastrarAsync(Fornecedor fornecedor)
        {
            try
            {
                _context.Fornecedores.Add(fornecedor);
                await _context.SaveChangesAsync();
                return fornecedor;
            }
            catch (Exception ex)
            {
                throw new DatabaseManipulationException($"Erro ao cadastrar fornecedor. Causa: {ex}.");
            }
        }

        public async Task<Fornecedor> AtualizarAsync(Fornecedor fornecedor)
        {
            try
            {
                _context.Fornecedores.Update(fornecedor);
                await _context.SaveChangesAsync();
                return fornecedor;
            }
            catch (Exception ex)
            {
                throw new DatabaseManipulationException($"Erro ao atualizar fornecedor. Causa: {ex}.");
            }
        }

        public async Task<Fornecedor> RemoverAsync(int id)
        {
            var fornecedor = await BuscarPorIdAsync(id);

            if (fornecedor == null)
            {
                throw new ResourceNotFoundException($"Fornecedor com id {id} não encontrado.");
            }
            
            try
            {
                _context.Fornecedores.Remove(fornecedor);
                await _context.SaveChangesAsync();
                return fornecedor;
            }   
            catch (Exception ex)
            {
                throw new DatabaseManipulationException($"Erro ao remover fornecedor. Causa: {ex}.");
            }
        }
    }
}
