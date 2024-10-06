using AutoMapper;
using Model.Dtos;
using Model.Entities;
using Model.Enum;
using Repositories;

namespace Services
{
    public interface IPedidoService
    {
        Task<List<PedidoDto>> BuscarTodosAsync();
        Task<PedidoDto> BuscarPorIdAsync(int id);
        Task<PedidoDto> CadastrarAsync(CadastrarPedidoDto cadastrarPedidoDto);
        Task<PedidoDto> AlterarStatusAsync(int idPedido, StatusPedido status);
        Task<PedidoDto> RemoverAsync(int id);
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

        public async Task<List<PedidoDto>> BuscarTodosAsync()
        {
            var pedidos = await _pedidoRepository.BuscarTodosAsync();

            return _mapper.Map<List<PedidoDto>>(pedidos);
        }

        public async Task<PedidoDto> BuscarPorIdAsync(int id)
        {
            var pedido = await _pedidoRepository.BuscarPorIdAsync(id);
            
            return _mapper.Map<PedidoDto>(pedido); 
        }

        public async Task<PedidoDto> CadastrarAsync(CadastrarPedidoDto cadastrarPedidoDto)
        {
            var pedido = await _pedidoRepository.CadastrarAsync(_mapper.Map<Pedido>(cadastrarPedidoDto));

            return _mapper.Map<PedidoDto>(pedido);
        }

        public async Task<PedidoDto> AlterarStatusAsync(int idPedido, StatusPedido status)
        {
            var pedido = await _pedidoRepository.BuscarPorIdAsync(idPedido);

            pedido.Status = status;

            var pedidoAtualizado =  await _pedidoRepository.AlterarStatusAsync(pedido);

            return _mapper.Map<PedidoDto>(pedidoAtualizado);

        }

        public async Task<PedidoDto> RemoverAsync(int id)
        {
            var pedidoRemovido =  await _pedidoRepository.RemoverAsync(id);

            return _mapper.Map<PedidoDto>(pedidoRemovido);

        }
    }


}
