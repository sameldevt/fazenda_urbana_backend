using Microsoft.Identity.Client.TelemetryCore.TelemetryClient;
using Model.Dtos;
using Model.Entities;
using Repositories;

namespace Services
{
    public interface IClienteService
    {
        Task<IEnumerable<VisualizarClienteDto>> ListarTodosAsync();
        Task<VisualizarClienteDto> BuscarPorIdAsync(int id);
        Task<VisualizarClienteDto> CadastrarAsync(CadastrarClienteDto cliente);
        Task<VisualizarClienteDto> AtualizarAsync(AtualizarClienteDto cliente);
        Task<VisualizarClienteDto> RemoverAsync(int id);
    }

    public class ClienteService : IClienteService
    {
        private readonly IClienteRepository _clienteRepository;

        public ClienteService(IClienteRepository clienteRepository)
        {
            _clienteRepository = clienteRepository;
        }

        public async Task<IEnumerable<VisualizarClienteDto>> ListarTodosAsync()
        {
            var clientes = await _clienteRepository.BuscarTodosAsync();

            var listaClientesDto = new List<VisualizarClienteDto>();

            foreach (var cliente in clientes)
            {
                var clienteDto = VisualizarClienteDto.ConverterCliente(cliente);
                listaClientesDto.Add(clienteDto);
            }

            return listaClientesDto;
        }

        public async Task<VisualizarClienteDto> BuscarPorIdAsync(int id)
        {
            var cliente = await _clienteRepository.BuscarPorIdAsync(id);

            if(cliente == null)
            {
                return null;
            }

            return VisualizarClienteDto.ConverterCliente(cliente);
        }

        public async Task<VisualizarClienteDto> CadastrarAsync(CadastrarClienteDto cadastrarClienteDto)
        {

            Cliente cliente = new Cliente
            { 
                Nome = cadastrarClienteDto.Nome,
                Senha = cadastrarClienteDto.Senha,
                Contato = new Contato 
                {
                    Telefone = cadastrarClienteDto.Telefone,
                    Email = cadastrarClienteDto.Email,
                },
                Endereco = new Endereco
                {
                    Logradouro = cadastrarClienteDto.Logradouro,
                    Numero = cadastrarClienteDto.Numero,
                    Cidade = cadastrarClienteDto.Cidade,
                    CEP = cadastrarClienteDto.CEP,
                    Complemento = cadastrarClienteDto.Complemento,
                    Estado = cadastrarClienteDto.Estado,
                    InformacoesAdicionais = cadastrarClienteDto.InformacoesAdicionais
                }
            };
            
            var clienteCadastrado = await _clienteRepository.CadastrarAsync(cliente);

            if(clienteCadastrado == null)
            {
                return null;
            }

            return VisualizarClienteDto.ConverterCliente(cliente);
        }

        public async Task<VisualizarClienteDto> AtualizarAsync(AtualizarClienteDto atualizarClienteDto)
        {
            var clienteExistente = await _clienteRepository.BuscarPorIdAsync(atualizarClienteDto.Id);
            if (clienteExistente != null)
            {
                clienteExistente.Nome = atualizarClienteDto.Nome;
                clienteExistente.Contato = new Contato
                {
                    Telefone = atualizarClienteDto.Telefone,
                    Email = atualizarClienteDto.Email,
                };
                clienteExistente.Endereco = new Endereco
                {
                    Logradouro = atualizarClienteDto.Logradouro,
                    Numero = atualizarClienteDto.Numero,
                    Cidade = atualizarClienteDto.Cidade,
                    CEP = atualizarClienteDto.CEP,
                    Complemento = atualizarClienteDto.Complemento,
                    Estado = atualizarClienteDto.Estado,
                    InformacoesAdicionais = atualizarClienteDto.InformacoesAdicionais
                };

                await _clienteRepository.AtualizarAsync(clienteExistente);
            }

            return VisualizarClienteDto.ConverterCliente(clienteExistente);
        }

        public async Task<VisualizarClienteDto> RemoverAsync(int id)
        {
            var clienteRemovido = await _clienteRepository.RemoverAsync(id);
            return VisualizarClienteDto.ConverterCliente(clienteRemovido);
        }
    }

}
