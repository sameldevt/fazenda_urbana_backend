using Model.Dtos;
using Model.Entities;
using Repositories;

namespace Services
{
    public interface IClienteService
    {
        Task<IEnumerable<ClienteDto>> ListarTodosAsync();
        Task<ClienteDto> BuscarPorIdAsync(int id);
        Task<ClienteDto> AdicionarAsync(ClienteDto cliente);
        Task<ClienteDto> AtualizarAsync(ClienteDto cliente);
        Task<ClienteDto> RemoverAsync(int id);
    }

    public class ClienteService : IClienteService
    {
        private readonly IClienteRepository _clienteRepository;

        public ClienteService(IClienteRepository clienteRepository)
        {
            _clienteRepository = clienteRepository;
        }

        public async Task<IEnumerable<ClienteDto>> ListarTodosAsync()
        {
            var clientes = await _clienteRepository.ListarTodosAsync();

            var clientesDto = new List<ClienteDto>();

            foreach (var cliente in clientes)
            {
                var clienteDto = ClienteDto.FromCliente(cliente);
            }
        }

        public async Task<ClienteDto> BuscarPorIdAsync(int id)
        {
            return await _clienteRepository.BuscarPorIdAsync(id);
        }

        public async Task<ClienteDto> AdicionarAsync(ClienteDto cliente)
        {
            await _clienteRepository.AdicionarAsync(cliente);
        }

        public async Task<ClienteDto> AtualizarAsync(ClienteDto cliente)
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

        public async Task<ClienteDto> RemoverAsync(int id)
        {
            await _clienteRepository.RemoverAsync(id);
        }
    }


}
