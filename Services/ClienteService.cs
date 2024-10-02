using Microsoft.Identity.Client.TelemetryCore.TelemetryClient;
using Model.Dtos;
using Model.Entities;
using Repositories;

namespace Services
{
    public interface IClienteService
    {
        Task<IEnumerable<IClienteDto>> BuscarTodosAsync();
        Task<IClienteDto> BuscarPorIdAsync(int id);
        Task<IClienteDto> CadastrarAsync(CadastrarClienteDto cliente);
        Task<IClienteDto> AtualizarAsync(AtualizarClienteDto cliente);
        Task<IClienteDto> RemoverAsync(int id);
    }

    public class ClienteService : IClienteService
    {
        private readonly IClienteRepository _clienteRepository;

        public ClienteService(IClienteRepository clienteRepository)
        {
            _clienteRepository = clienteRepository;
        }

        public async Task<IEnumerable<IClienteDto>> BuscarTodosAsync()
        {
            var clientes = await _clienteRepository.BuscarTodosAsync();

            return clientes.Select(c => ClienteDtoFactory.Criar(TipoDto.Visualizar, c)).ToList();
        }

        public async Task<IClienteDto> BuscarPorIdAsync(int id)
        {
            var cliente = await _clienteRepository.BuscarPorIdAsync(id);

            return ClienteDtoFactory.Criar(TipoDto.Visualizar, cliente);
        }

        public async Task<IClienteDto> CadastrarAsync(CadastrarClienteDto cadastrarClienteDto)
        {
            var clienteCadastrado = await _clienteRepository.CadastrarAsync(new Cliente(cadastrarClienteDto));

            return ClienteDtoFactory.Criar(TipoDto.Visualizar, clienteCadastrado);
        }

        public async Task<IClienteDto> AtualizarAsync(AtualizarClienteDto atualizarClienteDto)
        {
            var clienteExistente = await _clienteRepository.BuscarPorIdAsync(atualizarClienteDto.Id);

            var clienteAtualizado = new Cliente(atualizarClienteDto);

            await _clienteRepository.AtualizarAsync(clienteExistente);

            return ClienteDtoFactory.Criar(TipoDto.Visualizar, clienteAtualizado);
        }

        public async Task<IClienteDto> RemoverAsync(int id)
        {
            var clienteRemovido = await _clienteRepository.RemoverAsync(id);
            return ClienteDtoFactory.Criar(TipoDto.Visualizar, clienteRemovido);
        }
    }

}
