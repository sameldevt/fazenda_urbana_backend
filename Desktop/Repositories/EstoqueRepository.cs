using _.Data;
using _.Desktop.Models;
using Microsoft.EntityFrameworkCore;

namespace _.Desktop.Repositories
{
    public interface IEstoqueRepository
    {
        Task<IEnumerable<Produto>> ListarTodosAsync();
        Task<Produto> BuscarPorIdAsync(int id);
        Task AtualizarAsync(Produto produto);
    }

    public class EstoqueRepository : IEstoqueRepository
    {
        private readonly ApplicationDbContext _context;

        public EstoqueRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Produto>> ListarTodosAsync()
        {
            return await _context.Produtos.ToListAsync();
        }

        public async Task<Produto> BuscarPorIdAsync(int id)
        {
            return await _context.Produtos.FindAsync(id);
        }

        public async Task AtualizarAsync(Produto produto)
        {
            _context.Produtos.Update(produto);
            await _context.SaveChangesAsync();
        }
    }


}
