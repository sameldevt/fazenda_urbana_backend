using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Model.Dtos;
using Model.Entities;
using Services;

namespace Controllers
{
    [ApiController]
    [Route("verdeviva/pedidos")]
    public class PedidoController : ControllerBase
    {
        private readonly IPedidoService _pedidoService;

        public PedidoController(IPedidoService pedidoService)
        {
            _pedidoService = pedidoService;
        }

        [HttpGet("buscar-todos")]
        public async Task<ActionResult<List<VisualizarPedidoDto>>> BuscarTodos()
        {
            var pedidos = await _pedidoService.BuscarTodosAsync();
            return Ok(pedidos);
        }

        [HttpGet("buscar/{id}")]
        public async Task<ActionResult<VisualizarPedidoDto>> Buscar(int id)
        {
            var pedido = await _pedidoService.BuscarPorIdAsync(id);
            return Ok(pedido);
        }

        [HttpPost("cadastrar")]
        public async Task<ActionResult<VisualizarPedidoDto>> Cadastrar([FromBody] CadastrarPedidoDto cadastrarPedidoDto)
        {
            await _pedidoService.CadastrarAsync(cadastrarPedidoDto);
            return Created(nameof(Cadastrar), cadastrarPedidoDto);
        }

        [HttpPut("alterar-status")]
        public async Task<ActionResult<VisualizarPedidoDto>> AlterarStatus(AlterarStatusPedidoDto alterarStatusPedidoDto)
        {
            var pedidoAlterado = await _pedidoService.AlterarStatusAsync(alterarStatusPedidoDto);
            return Ok(pedidoAlterado);
        }

        [HttpDelete("remover/{id}")]
        public async Task<ActionResult<VisualizarPedidoDto>> Remover(int id)
        {
            var pedidoRemovido = await _pedidoService.RemoverAsync(id);
            return Ok(pedidoRemovido);
        }
    }
}
