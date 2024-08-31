using _.Data;
using _.Desktop.Models;
using Microsoft.EntityFrameworkCore;

namespace _.Desktop.Repositories
{
    public interface IFornecedorRepository
    {
        Task<IEnumerable<Fornecedor>> ListarTodosAsync();
        Task<Fornecedor> BuscarPorIdAsync(int id);
        Task AdicionarAsync(Fornecedor fornecedor);
        Task AtualizarAsync(Fornecedor fornecedor);
        Task RemoverAsync(int id);
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

        public async Task AdicionarAsync(Fornecedor fornecedor)
        {
            _context.Fornecedores.Add(fornecedor);
            await _context.SaveChangesAsync();
        }

        public async Task AtualizarAsync(Fornecedor fornecedor)
        {
            _context.Fornecedores.Update(fornecedor);
            await _context.SaveChangesAsync();
        }

        public async Task RemoverAsync(int id)
        {
            var fornecedor = await _context.Fornecedores.FindAsync(id);
            if (fornecedor != null)
            {
                _context.Fornecedores.Remove(fornecedor);
                await _context.SaveChangesAsync();
            }
        }
    }

}
