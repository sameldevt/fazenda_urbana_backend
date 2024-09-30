using Model.Entities;
using Repositories;

namespace Services
{
    public interface IClienteService
    {
        Task<IEnumerable<Cliente>> ListarTodosAsync();
        Task<Cliente> BuscarPorIdAsync(int id);
        Task AdicionarAsync(Cliente cliente);
        Task AtualizarAsync(int id, Cliente cliente);
        Task RemoverAsync(int id);
    }

    public class ClienteService : IClienteService
    {
        private readonly IClienteRepository _clienteRepository;

        public ClienteService(IClienteRepository clienteRepository)
        {
            _clienteRepository = clienteRepository;
        }

        public async Task<IEnumerable<Cliente>> ListarTodosAsync()
        {
            return await _clienteRepository.ListarTodosAsync();
        }

        public async Task<Cliente> BuscarPorIdAsync(int id)
        {
            return await _clienteRepository.BuscarPorIdAsync(id);
        }

        public async Task AdicionarAsync(Cliente cliente)
        {
            await _clienteRepository.AdicionarAsync(cliente);
        }

        public async Task AtualizarAsync(int id, Cliente cliente)
        {
            var clienteExistente = await _clienteRepository.BuscarPorIdAsync(id);
            if (clienteExistente != null)
            {
                clienteExistente.Nome = cliente.Nome;
                clienteExistente.Contato = cliente.Contato;
                clienteExistente.Endereco = cliente.Endereco;
                await _clienteRepository.AtualizarAsync(clienteExistente);
            }
        }

        public async Task RemoverAsync(int id)
        {
            await _clienteRepository.RemoverAsync(id);
        }
    }


}
