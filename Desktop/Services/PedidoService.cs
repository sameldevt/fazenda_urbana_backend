using _.Desktop.Repositories;
using _.Desktop.Models;

namespace _.Desktop.Services
{
    public interface IPedidoService
    {
        Task<IEnumerable<Pedido>> ListarTodosAsync();
        Task<Pedido> BuscarPorIdAsync(int id);
        Task CriarNovoAsync(Pedido pedido);
        Task AtualizarStatusAsync(int id, string novoStatus);
        Task<Pedido> VerDetalhesAsync(int id);
        Task RemoverAsync(int id);
    }

    public class PedidoService : IPedidoService
    {
        private readonly IPedidoRepository _pedidoRepository;

        public PedidoService(IPedidoRepository pedidoRepository)
        {
            _pedidoRepository = pedidoRepository;
        }

        public async Task<IEnumerable<Pedido>> ListarTodosAsync()
        {
            return await _pedidoRepository.ListarTodosAsync();
        }

        public async Task<Pedido> BuscarPorIdAsync(int id)
        {
            return await _pedidoRepository.BuscarPorIdAsync(id);
        }

        public async Task CriarNovoAsync(Pedido pedido)
        {
            await _pedidoRepository.CriarNovoAsync(pedido);
        }

        public async Task<Pedido> VerDetalhesAsync(int id) => await _pedidoRepository.VerDetalhesAsync(id);

        public async Task AtualizarStatusAsync(int id, string novoStatus)
        {
            var pedido = await _pedidoRepository.BuscarPorIdAsync(id);
            if (pedido != null)
            {
                pedido.Status = novoStatus;
                await _pedidoRepository.AtualizarAsync(pedido);
            }
        }

        public async Task RemoverAsync(int id)
        {
            await _pedidoRepository.RemoverAsync(id);
        }
    }


}
