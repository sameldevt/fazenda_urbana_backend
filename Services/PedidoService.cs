using Model.Dtos;
using Model.Entities;
using Repositories;

namespace Services
{
    public interface IPedidoService
    {
        Task<List<IPedidoDto>> BuscarTodosAsync();
        Task<IPedidoDto> BuscarPorIdAsync(int id);
        Task<IPedidoDto> CadastrarAsync(CadastrarPedidoDto cadastrarPedidoDto);
        Task<IPedidoDto> AlterarStatusAsync(AlterarStatusPedidoDto alterarStatusPedidoDto);
        Task<IPedidoDto> RemoverAsync(int id);
    }

    public class PedidoService : IPedidoService
    {
        private readonly IPedidoRepository _pedidoRepository;

        public PedidoService(IPedidoRepository pedidoRepository)
        {
            _pedidoRepository = pedidoRepository;
        }

        public async Task<List<IPedidoDto>> BuscarTodosAsync()
        {
            var pedidos = await _pedidoRepository.BuscarTodosAsync();

            return pedidos.Select(p => PedidoDtoFactory.Criar(TipoDto.Visualizar, p)).ToList();
        }

        public async Task<IPedidoDto> BuscarPorIdAsync(int id)
        {
            var pedido = await _pedidoRepository.BuscarPorIdAsync(id);
            
            return PedidoDtoFactory.Criar(TipoDto.Visualizar, pedido);
        }

        public async Task<IPedidoDto> CadastrarAsync(CadastrarPedidoDto cadastrarPedidoDto)
        {
            var pedido = await _pedidoRepository.CadastrarAsync(new Pedido(cadastrarPedidoDto));

            return PedidoDtoFactory.Criar(TipoDto.Visualizar, pedido);
        }

        public async Task<IPedidoDto> AlterarStatusAsync(AlterarStatusPedidoDto alterarStatusPedidoDto)
        {
            var pedido = await _pedidoRepository.BuscarPorIdAsync(alterarStatusPedidoDto.Id);

            var pedidoAtualizado =  await _pedidoRepository.AlterarStatusAsync(pedido);

            return PedidoDtoFactory.Criar(TipoDto.Visualizar, pedido);

        }

        public async Task<IPedidoDto> RemoverAsync(int id)
        {
            var pedidoRemovido =  await _pedidoRepository.RemoverAsync(id);

            return PedidoDtoFactory.Criar(TipoDto.Visualizar, pedidoRemovido);

        }
    }


}
