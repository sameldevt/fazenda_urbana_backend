using _.Desktop.Models;
using _.Web.Repositories;

namespace _.Web.Services
{
    public interface IProdutoService
    {
        Task<List<Produto>> ListarTodosAsync();
        Task<Produto> BuscarPorNomeAsync(string nome);
        Task<List<Categoria>> ListarCategoriasAsync();
    }

    public class ProdutoService : IProdutoService
    {
        private readonly IProdutoRepository _repository;

        public ProdutoService(IProdutoRepository repository)
        {
            _repository = repository;
        }

        public Task<List<Produto>> ListarTodosAsync() =>
            _repository.ListarTodosAsync();

        public Task<Produto> BuscarPorNomeAsync(string nome) =>
            _repository.BuscarPorNomeAsync(nome);

        public Task<List<Categoria>> ListarCategoriasAsync() =>
            _repository.ListarCategoriasAsync();
    }

}
