using AutoMapper;
using Microsoft.Identity.Client.TelemetryCore.TelemetryClient;
using Model.Dtos;
using Model.Entities;
using Repositories;

namespace Services
{
    public interface IClienteService
    {
        Task<IEnumerable<VisualizarClienteDto>> BuscarTodosAsync();
        Task<VisualizarClienteDto> BuscarPorIdAsync(int id);
        Task<VisualizarClienteDto> BuscarPorEmailAsync(string email);   
        Task<VisualizarClienteDto> CadastrarAsync(CadastrarClienteDto cliente);
        Task<VisualizarClienteDto> AtualizarAsync(AtualizarClienteDto cliente);
        Task<VisualizarClienteDto> RemoverAsync(int id);
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

        public async Task<IEnumerable<VisualizarClienteDto>> BuscarTodosAsync()
        {
            var clientes = await _clienteRepository.BuscarTodosAsync();

            return _mapper.Map<List<VisualizarClienteDto>>(clientes);
        }

        public async Task<VisualizarClienteDto> BuscarPorIdAsync(int id)
        {
            var cliente = await _clienteRepository.BuscarPorIdAsync(id);

            return _mapper.Map<VisualizarClienteDto>(cliente);
        }

        public async Task<VisualizarClienteDto> BuscarPorEmailAsync(string email)
        {
            var cliente = await _clienteRepository.BuscarPorEmailAsync(email);

            return _mapper.Map<VisualizarClienteDto>(cliente);
        }

        public async Task<VisualizarClienteDto> CadastrarAsync(CadastrarClienteDto cadastrarClienteDto)
        {
            var clienteCadastrado = await _clienteRepository.CadastrarAsync(_mapper.Map<Cliente>(cadastrarClienteDto));

            return _mapper.Map<VisualizarClienteDto>(clienteCadastrado);
        }

        public async Task<VisualizarClienteDto> AtualizarAsync(AtualizarClienteDto atualizarClienteDto)
        {
            var clienteExistente = await _clienteRepository.BuscarPorIdAsync(atualizarClienteDto.Id);

            clienteExistente = _mapper.Map<Cliente>(atualizarClienteDto);

            var clienteAtualizado = await _clienteRepository.AtualizarAsync(clienteExistente);

            return _mapper.Map<VisualizarClienteDto>(clienteAtualizado); 
        }

        public async Task<VisualizarClienteDto> RemoverAsync(int id)
        {
            var clienteRemovido = await _clienteRepository.RemoverAsync(id);
            return _mapper.Map<VisualizarClienteDto>(clienteRemovido);
        }
    }

}
