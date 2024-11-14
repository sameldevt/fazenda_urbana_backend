using AutoMapper;
using Model.Dtos;
using Model.Entities;
using Model.Enum;
using Repositories;
using Logging;
using Exceptions;

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
        private readonly IProdutoRepository _produtoRepository;
        private readonly IClienteRepository _clienteRepository;
        private readonly IMapper _mapper;

        public PedidoService(IClienteRepository clienteRepository, IProdutoRepository produtoRepository, IPedidoRepository pedidoRepository, IMapper mapper)
        {
            _clienteRepository = clienteRepository;
            _produtoRepository = produtoRepository;
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
            var cliente = await _clienteRepository.BuscarPorIdAsync(cadastrarPedidoDto.ClienteId);
            var itensPedido = _mapper.Map<List<ItemPedido>>(cadastrarPedidoDto.Itens);

            await AtualizarEstoqueAsync(itensPedido);

            var pedido = CriarPedido(cadastrarPedidoDto, cliente.Id, itensPedido);

            pedido = await _pedidoRepository.CadastrarAsync(pedido);

            return _mapper.Map<PedidoDto>(pedido);
        }

        private Pedido CriarPedido(CadastrarPedidoDto cadastrarPedidoDto, int clienteId, List<ItemPedido> itensPedido)
        {
            return new Pedido
            {
                ClienteId = clienteId,
                DataPedido = DateTime.Now,
                Status = StatusPedido.AGUARDANDO_PAGAMENTO,
                Total = cadastrarPedidoDto.Total,
                EnderecoEntrega = cadastrarPedidoDto.EnderecoEntrega,
                FormaPagamento = cadastrarPedidoDto.FormaPagamento,
                Itens = itensPedido
            };
        }

        private async Task AtualizarEstoqueAsync(List<ItemPedido> itensPedido)
        {
            foreach (var item in itensPedido)
            {
                var produto = await _produtoRepository.BuscarPorIdAsync(item.ProdutoId);

                if (produto != null)
                {
                    if(item.Quantidade > 5)
                    {
                        produto.QuantidadeEstoque -= (item.Quantidade / 1000);
                    }
                    else
                    {
                        produto.QuantidadeEstoque -= item.Quantidade;
                    }

                    await _produtoRepository.AtualizarAsync(produto);
                    continue; 
                }
            }
        }

        public async Task<PedidoDto> AlterarStatusAsync(int idPedido, StatusPedido status)
        {
            var pedido = await _pedidoRepository.BuscarPorIdAsync(idPedido);
            pedido.Status = status;
            var pedidoAtualizado = await _pedidoRepository.AlterarStatusAsync(pedido);
            return _mapper.Map<PedidoDto>(pedidoAtualizado);
        }

        public async Task<PedidoDto> RemoverAsync(int id)
        {
            var pedidoRemovido = await _pedidoRepository.RemoverAsync(id);
            return _mapper.Map<PedidoDto>(pedidoRemovido);
        }
    }
}
