using _.Desktop.Models;
using _.Desktop.Services;
using Microsoft.AspNetCore.Mvc;

namespace _.Web.Controllers
{
    [ApiController]
    [Route("verdeviva/clientes/pedidos")]
    public class PedidosController : ControllerBase
    {
        private readonly IPedidoService _pedidoService;

        public PedidosController(IPedidoService pedidoService)
        {
            _pedidoService = pedidoService;
        }

        [HttpGet("listar-todos")]
        public async Task<IActionResult> ListarTodos()
        {
            var pedidos = await _pedidoService.ListarTodosAsync();
            return Ok(pedidos);
        }

        [HttpPost("criar")]
        public async Task<IActionResult> Criar([FromBody] Pedido pedido)
        {
            await _pedidoService.CriarNovoAsync(pedido);
            return Ok();
        }

        [HttpGet("ver-detalhes/{id}")]
        public async Task<IActionResult> VerDetalhes(int id)
        {
            var pedido = await _pedidoService.VerDetalhesAsync(id);
            if (pedido == null)
            {
                return NotFound();
            }
            return Ok(pedido);
        }

        [HttpDelete("cancelar/{id}")]
        public async Task<IActionResult> Cancelar(int id)
        {
            await _pedidoService.RemoverAsync(id);
            return Ok();
        }
    }

}
