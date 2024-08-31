using _.Desktop.Models;
using _.Desktop.Repositories;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace _.Desktop.Services
{
    public interface IManagerProdutoService
    {
        Task<IEnumerable<Produto>> ListarTodosAsync();
        Task<Produto> BuscarPorIdAsync(int id);
        Task AdicionarNovoAsync(Produto produto);
        Task AtualizarAsync(int id, Produto produto);
        Task RemoverAsync(int id);
    }

    public class ManagerProdutoService : IManagerProdutoService
    {
        private readonly IManagerProdutoRepository _produtoRepository;

        public ManagerProdutoService(IManagerProdutoRepository produtoRepository)
        {
            _produtoRepository = produtoRepository;
        }

        public async Task<IEnumerable<Produto>> ListarTodosAsync()
        {
            return await _produtoRepository.ListarTodosAsync();
        }

        public async Task<Produto> BuscarPorIdAsync(int id)
        {
            return await _produtoRepository.BuscarPorIdAsync(id);
        }

        public async Task AdicionarNovoAsync(Produto produto)
        {
            await _produtoRepository.AdicionarNovoAsync(produto);
        }

        public async Task AtualizarAsync(int id, Produto produto)
        {
            var produtoExistente = await _produtoRepository.BuscarPorIdAsync(id);
            if (produtoExistente != null)
            {
                produtoExistente.Nome = produto.Nome;
                produtoExistente.Descricao = produto.Descricao;
                produtoExistente.PrecoUnitario = produto.PrecoUnitario;
                produtoExistente.PrecoQuilo = produto.PrecoQuilo;
               await _produtoRepository.AtualizarAsync(produtoExistente);
            }
        }

        public async Task RemoverAsync(int id)
        {
            await _produtoRepository.RemoverAsync(id);
        }
    }


}
