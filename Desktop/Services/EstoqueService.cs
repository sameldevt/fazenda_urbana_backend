using _.Desktop.Models;
using _.Desktop.Repositories;

namespace _.Desktop.Services
{
    public interface IEstoqueService
    {
        Task<IEnumerable<Produto>> ListarTodosAsync();
        Task AtualizarQuantidadeAsync(int id, int novaQuantidade);
    }

    public class EstoqueService : IEstoqueService
    {
        private readonly IEstoqueRepository _estoqueRepository;

        public EstoqueService(IEstoqueRepository estoqueRepository)
        {
            _estoqueRepository = estoqueRepository;
        }

        public async Task<IEnumerable<Produto>> ListarTodosAsync()
        {
            return await _estoqueRepository.ListarTodosAsync();
        }

        public async Task AtualizarQuantidadeAsync(int id, int novaQuantidade)
        {
            var produto = await _estoqueRepository.BuscarPorIdAsync(id);
            if (produto != null)
            {
                produto.QuantidadeEstoque = novaQuantidade;
                await _estoqueRepository.AtualizarAsync(produto);
            }
        }
    }


}
