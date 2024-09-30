using Model.Entities;
using Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Model.Dtos;

namespace Controllers
{
    [ApiController]
    [Route("verdeviva/produtos")]
    public class ProdutoController : ControllerBase
    {
        private readonly IProdutoService _produtoService;

        public ProdutoController(IProdutoService produtoService)
        {
            _produtoService = produtoService;
        }

        [HttpGet("listar-todos")]
        public async Task<ActionResult<IEnumerable<VisualizarProdutoDto>>> BuscarTodos()
        {
            var produtos = await _produtoService.BuscarTodosAsync();
            if (produtos.IsNullOrEmpty())
            {
                return NotFound("Nenhum produto encontrado.");
            }

            return Ok(produtos);
        }

        [HttpGet("buscar/{id}")]
        public async Task<ActionResult<VisualizarProdutoDto>> Buscar(int id)
        {
            var produto = await _produtoService.BuscarPorIdAsync(id);
            if (produto == null)
            {
                return NotFound("Produto com ID " + id + " não encontrado.");
            }

            return Ok(produto);
        }

        [HttpPost("cadastrar")]
        public async Task<ActionResult<VisualizarProdutoDto>> Cadastrar([FromBody] CadastrarProdutoDto cadastrarProdutoDto)
        {
            VisualizarProdutoDto produto = await _produtoService.CadastrarAsync(cadastrarProdutoDto);
            if (produto == null)
            {
                return NotFound("Cadastro mal-sucedido.");
            }
            return Created(nameof(Cadastrar), produto);
        }

        [HttpPut("atualizar")]
        public async Task<ActionResult<VisualizarProdutoDto>> Atualizar([FromBody] AtualizarProdutoDto atualizarProdutoDto)
        {
            var produtoAtualizado = await _produtoService.AtualizarAsync(atualizarProdutoDto);
            if (produtoAtualizado == null)
            {
                return NotFound("Atualização mal-sucedida.");
            }
            return Ok(produtoAtualizado);
        }

        [HttpDelete("remover/{id}")]
        public async Task<ActionResult<VisualizarProdutoDto>> Remover(int id)
        {
            var produtoRemovido = await _produtoService.RemoverAsync(id);
            if (produtoRemovido == null)
            {
                return NotFound("Produto com ID " + id + " não encontrado.");
            }
            return Ok(produtoRemovido);
        }
    }

}
