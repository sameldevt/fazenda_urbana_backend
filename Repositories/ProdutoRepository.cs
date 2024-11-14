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
        Task<List<Categoria>> ListarCategoriasAsync();
        Task<Produto> BuscarPorIdAsync(int id);
        Task<List<Produto>> BuscarPorIdsAsync(IEnumerable<int> ids);
        Task<Categoria> CadastrarCategoriaAsync(Categoria categoria);
        Task<Produto> CadastrarAsync(Produto produto);
        Task<List<Produto>> CadastrarVariosAsync(List<Produto> produtos);
        Task<Produto> AtualizarAsync(Produto produto);
        Task<Produto> RemoverAsync(int id);
        Task<Categoria> BuscarCategoriaPorIdAsync(int id);
        Task<Fornecedor> BuscarFornecedorPorIdAsync(int id);
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
            var produtos = await _context.Produtos
                .Include(p => p.Categoria)
                .Include(p => p.Nutrientes)
                .Include(p => p.Fornecedor)
                .Where(p => p.QuantidadeEstoque > 5)
                .AsNoTracking().ToListAsync();
            
            if(!produtos.Any())
            {
                throw new ResourceNotFoundException("Nenhum produto encontrado.");
            }
            
            return produtos;
        }

        public async Task<Produto> BuscarPorNomeAsync(string nome)
        {
            var produto = await _context.Produtos
                .Include(p => p.Categoria)
                .Include(p => p.Nutrientes)
                .Include(p => p.Fornecedor)
                .Where(p => p.QuantidadeEstoque > 5)
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

        public async Task<List<Produto>> BuscarPorIdsAsync(IEnumerable<int> ids)
        {
            var produtos = await _context.Produtos
                .Include(p => p.Categoria)
                .Include(p => p.Nutrientes)
                .Include(p => p.Fornecedor)
                .AsNoTracking()
                .Where(p => ids.Contains(p.Id))
                .Where(p => p.QuantidadeEstoque > 5)
                .ToListAsync();

            if (!produtos.Any())
            {
                throw new ResourceNotFoundException("Nenhum produto encontrado para os IDs fornecidos.");
            }

            return produtos;
        }

        public async Task<Produto> BuscarPorIdAsync(int id)
        {
            var produto =  await _context.Produtos
                .Include(p => p.Categoria)
                .Include(p => p.Nutrientes)
                .Include(p => p.Fornecedor)
                .Where(p => p.QuantidadeEstoque > 5)
                .AsNoTracking()
                .FirstOrDefaultAsync(p => p.Id == id);
            
            if(produto == null)
            {
                throw new ResourceNotFoundException($"Produto com id {id} não encontrado.");
            }
            return produto;
        }

        public async Task<Categoria> CadastrarCategoriaAsync(Categoria categoria)
        {
            try
            {
                _context.Categorias.Add(categoria);
                await _context.SaveChangesAsync();
                return categoria;
            }
            catch (Exception ex)
            {
                throw new DatabaseManipulationException($"Erro ao cadastrar categoria. Causa: ${ex}.");
            }
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

        public async Task<List<Produto>> CadastrarVariosAsync(List<Produto> produtos)
        {
            try
            {
                _context.Produtos.AddRange(produtos);
                await _context.SaveChangesAsync();
                return produtos;
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
                var produtoExistente = await _context.Produtos
                    .AsNoTracking()
                    .FirstOrDefaultAsync(p => p.Id == produto.Id);

                if (produtoExistente == null)
                {
                    throw new ResourceNotFoundException($"Produto com ID {produto.Id} não encontrado.");
                }

                produtoExistente.Nome = produto.Nome;
                produtoExistente.Descricao = produto.Descricao;
                produtoExistente.PrecoQuilo = produto.PrecoQuilo;
                produtoExistente.QuantidadeEstoque = produto.QuantidadeEstoque;
                produtoExistente.ImagemUrl = produto.ImagemUrl;
                produtoExistente.CategoriaId = produto.CategoriaId;

                if (produto.Nutrientes != null)
                {
                    produtoExistente.Nutrientes.Calorias = produto.Nutrientes.Calorias;
                    produtoExistente.Nutrientes.Proteinas = produto.Nutrientes.Proteinas;
                    produtoExistente.Nutrientes.Carboidratos = produto.Nutrientes.Carboidratos;
                    produtoExistente.Nutrientes.Fibras = produto.Nutrientes.Fibras;
                    produtoExistente.Nutrientes.Gorduras = produto.Nutrientes.Gorduras;
                }

                await _context.SaveChangesAsync();

                return produtoExistente;
            }
            catch (Exception ex)
            {
                throw new DatabaseManipulationException($"Erro ao atualizar produto. Causa: {ex.Message}");
            }
        }



        public async Task<Produto> RemoverAsync(int id)
        {
            var produto = await _context.Produtos.AsNoTracking().FirstOrDefaultAsync(p => p.Id == id);

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
            var categoria = await _context.Categorias.AsNoTracking().SingleOrDefaultAsync(p => p.Nome == nome);

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

        public async Task<Categoria> BuscarCategoriaPorIdAsync(int id)
        {
            var categoria = await _context.Categorias.AsNoTracking().SingleOrDefaultAsync(p => p.Id == id);

            if(categoria == null)
            {
                throw new ResourceNotFoundException($"Categoria com id {id} não encontrada.");

            }

            return categoria;
        }

        public async Task<Fornecedor> BuscarFornecedorPorIdAsync(int id)
        {
            var fornecedor = await _context.Fornecedores
                .AsNoTracking()
                .Include(f => f.Contato)          
                .Include(f => f.Enderecos)
                .SingleOrDefaultAsync(f => f.Id == id);

            if (fornecedor == null)
            {
                throw new ResourceNotFoundException($"Fornecedor com id {id} não encontrado.");

            }

            return fornecedor;
        }
    }
}
