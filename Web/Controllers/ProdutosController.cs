using _.Web.Services;
using Microsoft.AspNetCore.Mvc;

namespace _.Web.Controllers
{
    [ApiController]
    [Route("verdeviva/clientes/produtos")]
    public class ProdutosController : ControllerBase
    {
        private readonly IProdutoService _produtoService;

        public ProdutosController(IProdutoService produtoService)
        {
            _produtoService = produtoService;
        }

        [HttpGet("listar-todos")]
        public async Task<IActionResult> ListarTodos()
        {
            var produtos = await _produtoService.ListarTodosAsync();
            return Ok(produtos);
        }

        [HttpGet("buscar/{nome}")]
        public async Task<IActionResult> Buscar(string nome)
        {
            var produto = await _produtoService.BuscarPorNomeAsync(nome);
            if (produto == null)
            {
                return NotFound();
            }
            return Ok(produto);
        }

        [HttpGet("listar-categorias")]
        public async Task<IActionResult> ListarCategorias()
        {
            var categorias = await _produtoService.ListarCategoriasAsync();
            return Ok(categorias);
        }
    }

}
