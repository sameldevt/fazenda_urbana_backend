using Data;
using Model.Entities;
using Microsoft.EntityFrameworkCore;
using Model.Dtos;

namespace Repositories
{
    public interface IProdutoRepository
    {
        Task<List<Produto>> ListarTodosAsync();
        Task<Produto> BuscarPorNomeAsync(string nome);
        Task<List<Categoria>> ListarCategoriasAsync();
        Task<Produto> BuscarPorIdAsync(int id);
        Task<Produto> AdicionarNovoAsync(Produto produto);
        Task<Produto> AtualizarAsync(Produto produto);
        Task<Produto> RemoverAsync(int id);
        Task<Categoria> BuscarCategoriaPorNome(string nome);
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


        public async Task<Produto> BuscarPorIdAsync(int id) => 
            await _context.Produtos.FindAsync(id);
      

        public async Task<Produto> AdicionarNovoAsync(Produto produto)
        {
            _context.Produtos.Add(produto);
            await _context.SaveChangesAsync();

            return produto;
        }

        public async Task<Produto> AtualizarAsync(Produto produto)
        {
            _context.Produtos.Update(produto);
            await _context.SaveChangesAsync();

            return produto;
        }

        public async Task<Produto> RemoverAsync(int id)
        {
            var produto = await _context.Produtos.FindAsync(id);
            if (produto != null)
            {
                _context.Produtos.Remove(produto);
                await _context.SaveChangesAsync();
            }

            return produto;
        }

        public async Task<Categoria> BuscarCategoriaPorNome(string nome)
        {
            var categoria = await _context.Categorias.SingleOrDefaultAsync(p => p.Nome == nome);

            if (categoria == null)
            {
                categoria = new Categoria
                {
                    Nome = nome,
                    Descricao = "Categoria sem descrição",
                    DataCriacao = DateTime.Now
                };

                _context.Categorias.Add(categoria);
                await _context.SaveChangesAsync();
            }

            return categoria;
        }
    }

}
