using _.Web.Models;
using _.Web.Services;
using Microsoft.AspNetCore.Mvc;

namespace _.Web.Controllers
{
    [ApiController]
    [Route("verdeviva/clientes/carrinho")]
    public class CarrinhoController : ControllerBase
    {
        private readonly ICarrinhoService _carrinhoService;

        public CarrinhoController(ICarrinhoService carrinhoService)
        {
            _carrinhoService = carrinhoService;
        }

        [HttpGet("listar")]
        public async Task<IActionResult> ListarItens()
        {
            var itens = await _carrinhoService.ListarItensAsync();
            return Ok(itens);
        }

        [HttpPost("adicionar")]
        public async Task<IActionResult> AdicionarItem([FromBody] ItemCarrinho item)
        {
            await _carrinhoService.AdicionarItemAsync(item);
            return Ok();
        }

        [HttpPut("atualizar/{id}")]
        public async Task<IActionResult> AtualizarItem(int id, [FromBody] ItemCarrinho item)
        {
            await _carrinhoService.AtualizarItemAsync(id, item);
            return Ok();
        }

        [HttpDelete("remover/{id}")]
        public async Task<IActionResult> RemoverItem(int id)
        {
            await _carrinhoService.RemoverItemAsync(id);
            return Ok();
        }
    }
}
