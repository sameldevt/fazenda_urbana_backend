using Model.Dtos;
using Model.Entities;
using Repositories;

namespace Services
{
    public interface IPedidoService
    {
        Task<IEnumerable<VisualizarPedidoDto>> BuscarTodosAsync();
        Task<VisualizarPedidoDto> BuscarPorIdAsync(int id);
        Task<bool> CadastrarAsync(CadastrarPedidoDto cadastrarPedidoDto);
        Task<bool> AlterarStatusAsync(AlterarStatusPedidoDto alterarStatusPedidoDto);
        Task<bool> RemoverAsync(int id);
    }

    public class PedidoService : IPedidoService
    {
        private readonly IPedidoRepository _pedidoRepository;

        public PedidoService(IPedidoRepository pedidoRepository)
        {
            _pedidoRepository = pedidoRepository;
        }

        public async Task<IEnumerable<VisualizarPedidoDto>> BuscarTodosAsync()
        {
            var pedidos = await _pedidoRepository.BuscarTodosAsync();

            var pedidosDto = new List<VisualizarPedidoDto>();

            foreach (Pedido p in pedidos)
            {
                var pedidoDto = VisualizarPedidoDto.ConverterPedido(p);
                pedidosDto.Add(pedidoDto);
            }

            return pedidosDto;
        }

        public async Task<VisualizarPedidoDto> BuscarPorIdAsync(int id)
        {
            var pedido = await _pedidoRepository.BuscarPorIdAsync(id);
       
            if(pedido != null)
            {
                return VisualizarPedidoDto.ConverterPedido(pedido);
            }

            return null;
        }

        public async Task<bool> CadastrarAsync(CadastrarPedidoDto cadastrarPedidoDto)
        {
            Pedido pedido = CadastrarPedidoDto.ConverterDto(cadastrarPedidoDto);
            return await _pedidoRepository.CadastrarAsync(pedido);
        }

        public async Task<bool> AlterarStatusAsync(AlterarStatusPedidoDto alterarStatusPedidoDto)
        {
            var pedido = await _pedidoRepository.BuscarPorIdAsync(alterarStatusPedidoDto.Id);

            if(pedido == null)
            {
                return false;
            }

            pedido.Status = alterarStatusPedidoDto.Status;

            return await _pedidoRepository.AlterarStatusAsync(pedido);
        }

        public async Task<bool> RemoverAsync(int id)
        {
            return await _pedidoRepository.RemoverAsync(id);
        }
    }


}
