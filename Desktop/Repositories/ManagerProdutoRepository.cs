using _.Data;
using _.Desktop.Models;
using Microsoft.EntityFrameworkCore;

namespace _.Desktop.Repositories
{
    public interface IManagerProdutoRepository
    {
        Task<IEnumerable<Produto>> ListarTodosAsync();
        Task<Produto> BuscarPorIdAsync(int id);
        Task AdicionarNovoAsync(Produto produto);
        Task AtualizarAsync(Produto produto);
        Task RemoverAsync(int id);
    }

    public class ManagerProdutoRepository : IManagerProdutoRepository
    {
        private readonly ApplicationDbContext _context;

        public ManagerProdutoRepository(ApplicationDbContext context)
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

        public async Task AdicionarNovoAsync(Produto produto)
        {
            _context.Produtos.Add(produto);
            await _context.SaveChangesAsync();
        }

        public async Task AtualizarAsync(Produto produto)
        {
            _context.Produtos.Update(produto);
            await _context.SaveChangesAsync();
        }

        public async Task RemoverAsync(int id)
        {
            var produto = await _context.Produtos.FindAsync(id);
            if (produto != null)
            {
                _context.Produtos.Remove(produto);
                await _context.SaveChangesAsync();
            }
        }
    }

}
