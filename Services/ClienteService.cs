using AutoMapper;
using Microsoft.Identity.Client.TelemetryCore.TelemetryClient;
using Model.Dtos;
using Model.Entities;
using Repositories;

namespace Services
{
    public interface IClienteService
    {
        Task<IEnumerable<ClienteDto>> BuscarTodosAsync();
        Task<ClienteDto> BuscarPorIdAsync(int id);
        Task<ClienteDto> BuscarPorEmailAsync(string email);   
        Task<ClienteDto> CadastrarAsync(CadastrarClienteDto cliente);
        Task<ClienteDto> AtualizarAsync(ClienteDto cliente);
        Task<ClienteDto> RemoverAsync(int id);
    }

    public class ClienteService : IClienteService
    {
        private readonly IClienteRepository _clienteRepository;
        private readonly IMapper _mapper;

        public ClienteService(IClienteRepository clienteRepository, IMapper mapper)
        {
            _clienteRepository = clienteRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<ClienteDto>> BuscarTodosAsync()
        {
            var clientes = await _clienteRepository.BuscarTodosAsync();

            return _mapper.Map<List<ClienteDto>>(clientes);
        }

        public async Task<ClienteDto> BuscarPorIdAsync(int id)
        {
            var cliente = await _clienteRepository.BuscarPorIdAsync(id);

            return _mapper.Map<ClienteDto>(cliente);
        }

        public async Task<ClienteDto> BuscarPorEmailAsync(string email)
        {
            var cliente = await _clienteRepository.BuscarPorEmailAsync(email);

            return _mapper.Map<ClienteDto>(cliente);
        }

        public async Task<ClienteDto> CadastrarAsync(CadastrarClienteDto cadastrarClienteDto)
        {
            var clienteCadastrado = await _clienteRepository.CadastrarAsync(_mapper.Map<Cliente>(cadastrarClienteDto));

            return _mapper.Map<ClienteDto>(clienteCadastrado);
        }

        public async Task<ClienteDto> AtualizarAsync(ClienteDto atualizarClienteDto)
        {
            var clienteExistente = await _clienteRepository.BuscarPorIdAsync(atualizarClienteDto.Id);

            clienteExistente = _mapper.Map<Cliente>(atualizarClienteDto);

            var clienteAtualizado = await _clienteRepository.AtualizarAsync(clienteExistente);

            return _mapper.Map<ClienteDto>(clienteAtualizado); 
        }

        public async Task<ClienteDto> RemoverAsync(int id)
        {
            var clienteRemovido = await _clienteRepository.RemoverAsync(id);
            return _mapper.Map<ClienteDto>(clienteRemovido);
        }
    }

}
