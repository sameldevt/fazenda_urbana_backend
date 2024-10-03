using Data;
using Model.Entities;
using Microsoft.EntityFrameworkCore;
using Model.Dtos;
using Exceptions;

namespace Repositories
{
    public interface IProdutoRepository
    {
        Task<List<Produto>> BuscarTodosAsync();
        Task<Produto> BuscarPorNomeAsync(string nome);
        Task<Produto> BuscarPorIdAsync(int id);
        Task<Produto> CadastrarAsync(Produto produto);
        Task<Produto> AtualizarAsync(Produto produto);
        Task<Produto> RemoverAsync(int id);
    }

    public class ProdutoRepository : IProdutoRepository
    {
        private readonly ApplicationDbContext _context;

        public ProdutoRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<Produto>> BuscarTodosAsync()
        { 
            var produto = await _context.Produtos.AsNoTracking().ToListAsync();
            
            if(produto == null)
            {
                throw new ResourceNotFoundException("Nenhum produto encontrado.");
            }

            return produto;
        }

        public async Task<Produto> BuscarPorNomeAsync(string nome)
        {
            var produto = await _context.Produtos
                .Include(p => p.Categoria)
                .Include(p => p.Nutrientes)
                .AsNoTracking()
                .FirstOrDefaultAsync(p => p.Nome == nome);
            
            if(produto == null)
            {
                throw new ResourceNotFoundException($"Produto {nome} não encontrado.");
            }

            return produto;
        }

        public async Task<List<Categoria>> ListarCategoriasAsync()
        {
            var categoria = await _context.Categorias.ToListAsync();
                
            if(categoria == null)
            {
                throw new ResourceNotFoundException("Nenhuma categoria encontrada.");
            }

            return categoria;
        }

        public async Task<Produto> BuscarPorIdAsync(int id)
        {
            var produto =  await _context.Produtos
                .Include(p => p.Categoria)
                .Include(p => p.Nutrientes)
                .AsNoTracking()
                .FirstOrDefaultAsync(p => p.Id == id);
            
            if(produto == null)
            {
                throw new ResourceNotFoundException($"Produto com id {id} não encontrado.");
            }
            return produto;
        }
      
        public async Task<Produto> CadastrarAsync(Produto produto)
        {
            try
            {
                _context.Produtos.Add(produto);
                await _context.SaveChangesAsync();
                return produto;
            }
            catch (Exception ex)
            {
                throw new DatabaseManipulationException($"Erro ao cadastrar produto. Causa: ${ex}.");
            }
        }

        public async Task<Produto> AtualizarAsync(Produto produto)
        {
            try
            {
                _context.Produtos.Update(produto);
                await _context.SaveChangesAsync();
                return produto;
            }
            catch (Exception ex) 
            {
                throw new DatabaseManipulationException($"Erro ao atualizar produto. Causa: ${ex}.");
            }

        }

        public async Task<Produto> RemoverAsync(int id)
        {
            var produto = await _context.Produtos.FindAsync(id);
            if (produto == null)
            {
                throw new ResourceNotFoundException($"Produto com id {id} não encontrado.");
            }
            try
            {
                _context.Produtos.Remove(produto);
                await _context.SaveChangesAsync();
                return produto;
            }
            catch (Exception ex) 
            {
                throw new DatabaseManipulationException($"Erro ao remover produto. Causa: ${ex}.");
            }

        }

        public async Task<Categoria> BuscarCategoriaPorNome(string nome)
        {
            var categoria = await _context.Categorias.SingleOrDefaultAsync(p => p.Nome == nome);

            if (categoria == null)
            {
                return categoria;
            }

            try
            {
                categoria = new Categoria
                {
                    Nome = nome,
                    Descricao = "Categoria sem descrição",
                    DataCriacao = DateTime.Now
                };

                _context.Categorias.Add(categoria);
                await _context.SaveChangesAsync();
                return categoria;
            }
            catch (Exception ex)
            {
                throw new DatabaseManipulationException($"Erro cadastrar categoria. Causa: ${ex}.");
            }
        }
    }

}
