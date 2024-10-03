using AutoMapper;
using Model.Dtos;
using Model.Entities;
using Repositories;

namespace Services
{
    public interface IPedidoService
    {
        Task<List<VisualizarPedidoDto>> BuscarTodosAsync();
        Task<VisualizarPedidoDto> BuscarPorIdAsync(int id);
        Task<VisualizarPedidoDto> CadastrarAsync(CadastrarPedidoDto cadastrarPedidoDto);
        Task<VisualizarPedidoDto> AlterarStatusAsync(AlterarStatusPedidoDto alterarStatusPedidoDto);
        Task<VisualizarPedidoDto> RemoverAsync(int id);
    }

    public class PedidoService : IPedidoService
    {
        private readonly IPedidoRepository _pedidoRepository;
        private readonly IMapper _mapper;

        public PedidoService(IPedidoRepository pedidoRepository, IMapper mapper)
        {
            _pedidoRepository = pedidoRepository;
            _mapper = mapper;
        }

        public async Task<List<VisualizarPedidoDto>> BuscarTodosAsync()
        {
            var pedidos = await _pedidoRepository.BuscarTodosAsync();

            return _mapper.Map<List<VisualizarPedidoDto>>(pedidos);
        }

        public async Task<VisualizarPedidoDto> BuscarPorIdAsync(int id)
        {
            var pedido = await _pedidoRepository.BuscarPorIdAsync(id);
            
            return _mapper.Map<VisualizarPedidoDto>(pedido); 
        }

        public async Task<VisualizarPedidoDto> CadastrarAsync(CadastrarPedidoDto cadastrarPedidoDto)
        {
            var pedido = await _pedidoRepository.CadastrarAsync(_mapper.Map<Pedido>(cadastrarPedidoDto));

            return _mapper.Map<VisualizarPedidoDto>(pedido);
        }

        public async Task<VisualizarPedidoDto> AlterarStatusAsync(AlterarStatusPedidoDto alterarStatusPedidoDto)
        {
            var pedido = await _pedidoRepository.BuscarPorIdAsync(alterarStatusPedidoDto.Id);

            pedido = _mapper.Map<Pedido>(alterarStatusPedidoDto); 

            var pedidoAtualizado =  await _pedidoRepository.AlterarStatusAsync(pedido);

            return _mapper.Map<VisualizarPedidoDto>(pedidoAtualizado);

        }

        public async Task<VisualizarPedidoDto> RemoverAsync(int id)
        {
            var pedidoRemovido =  await _pedidoRepository.RemoverAsync(id);

            return _mapper.Map<VisualizarPedidoDto>(pedidoRemovido);

        }
    }


}
