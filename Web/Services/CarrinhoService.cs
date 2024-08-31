using _.Web.Models;
using _.Web.Repositories;

namespace _.Web.Services
{
    public interface ICarrinhoService
    {
        Task<IEnumerable<ItemCarrinho>> ListarItensAsync();
        Task AdicionarItemAsync(ItemCarrinho item);
        Task AtualizarItemAsync(int id, ItemCarrinho item);
        Task RemoverItemAsync(int id);
    }

    public class CarrinhoService : ICarrinhoService
    {
        private readonly ICarrinhoRepository _repository;

        public CarrinhoService(ICarrinhoRepository repository)
        {
            _repository = repository;
        }

        public Task<IEnumerable<ItemCarrinho>> ListarItensAsync() =>
            _repository.ListarItensAsync();

        public Task AdicionarItemAsync(ItemCarrinho item) =>
            _repository.AdicionarItemAsync(item);

        public Task AtualizarItemAsync(int id, ItemCarrinho item) =>
            _repository.AtualizarItemAsync(id, item);

        public Task RemoverItemAsync(int id) =>
            _repository.RemoverItemAsync(id);
    }

}
