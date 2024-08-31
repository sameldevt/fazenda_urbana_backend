using _.Data;
using _.Desktop.Models;
using Microsoft.EntityFrameworkCore;

namespace _.Web.Repositories
{
    public interface IProdutoRepository
    {
        Task<List<Produto>> ListarTodosAsync();
        Task<Produto> BuscarPorNomeAsync(string nome);
        Task<List<Categoria>> ListarCategoriasAsync();
    }

    public class ProdutoRepository : IProdutoRepository
    {
        private readonly ApplicationDbContext _context;

        public ProdutoRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<Produto>> ListarTodosAsync() =>
            await _context.Produtos.ToListAsync();

        public async Task<Produto> BuscarPorNomeAsync(string nome) =>
            await _context.Produtos.FirstOrDefaultAsync(p => p.Nome == nome);

        public async Task<List<Categoria>> ListarCategoriasAsync() =>
            await _context.Categorias.ToListAsync();
    }

}
