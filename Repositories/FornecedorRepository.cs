using Data;
using Model.Entities;
using Microsoft.EntityFrameworkCore;

namespace Repositories
{
    public interface IFornecedorRepository
    {
        Task<IEnumerable<Fornecedor>> ListarTodosAsync();
        Task<Fornecedor> BuscarPorIdAsync(int id);
        Task<bool> CadastrarAsync(Fornecedor fornecedor);
        Task<bool> AtualizarAsync(Fornecedor fornecedor);
        Task<bool> RemoverAsync(Fornecedor fornecedor);
    }

    public class FornecedorRepository : IFornecedorRepository
    {
        private readonly ApplicationDbContext _context;

        public FornecedorRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Fornecedor>> ListarTodosAsync()
        {
            return await _context.Fornecedores.ToListAsync();
        }

        public async Task<Fornecedor> BuscarPorIdAsync(int id)
        {
            return await _context.Fornecedores.FindAsync(id);
        }

        public async Task<bool> CadastrarAsync(Fornecedor fornecedor)
        {
            try
            {
                _context.Fornecedores.Add(fornecedor);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public async Task<bool> AtualizarAsync(Fornecedor fornecedor)
        {
            try
            {
                _context.Fornecedores.Update(fornecedor);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public async Task<bool> RemoverAsync(Fornecedor fornecedor)
        {
            try
            {
                _context.Fornecedores.Remove(fornecedor);
                await _context.SaveChangesAsync();
                return true;
            }   
            catch (Exception ex)
            {
                return false;
            }
        }
    }

}
