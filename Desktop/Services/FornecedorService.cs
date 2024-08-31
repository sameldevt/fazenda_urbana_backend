using _.Desktop.Models;
using _.Desktop.Repositories;

namespace _.Desktop.Services
{
    public interface IFornecedorService
    {
        Task<IEnumerable<Fornecedor>> ListarTodosAsync();
        Task<Fornecedor> BuscarPorIdAsync(int id);
        Task AdicionarAsync(Fornecedor fornecedor);
        Task AtualizarAsync(int id, Fornecedor fornecedor);
        Task RemoverAsync(int id);
    }

    public class FornecedorService : IFornecedorService
    {
        private readonly IFornecedorRepository _fornecedorRepository;

        public FornecedorService(IFornecedorRepository fornecedorRepository)
        {
            _fornecedorRepository = fornecedorRepository;
        }

        public async Task<IEnumerable<Fornecedor>> ListarTodosAsync()
        {
            return await _fornecedorRepository.ListarTodosAsync();
        }

        public async Task<Fornecedor> BuscarPorIdAsync(int id)
        {
            return await _fornecedorRepository.BuscarPorIdAsync(id);
        }

        public async Task AdicionarAsync(Fornecedor fornecedor)
        {
            await _fornecedorRepository.AdicionarAsync(fornecedor);
        }

        public async Task AtualizarAsync(int id, Fornecedor fornecedor)
        {
            var fornecedorExistente = await _fornecedorRepository.BuscarPorIdAsync(id);
            if (fornecedorExistente != null)
            {
                fornecedorExistente.Nome = fornecedor.Nome;
                fornecedorExistente.Email = fornecedor.Email;
                await _fornecedorRepository.AtualizarAsync(fornecedorExistente);
            }
        }

        public async Task RemoverAsync(int id)
        {
            await _fornecedorRepository.RemoverAsync(id);
        }
    }


}
