using Model.Entities;
using Services;
using Microsoft.AspNetCore.Mvc;
using Model.Dtos;
using Microsoft.IdentityModel.Tokens;

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
        public async Task<ActionResult<IEnumerable<ProdutoDto>>> ListarTodos()
        {
            var produtos = await _produtoService.ListarTodosAsync();
            if (produtos.IsNullOrEmpty())
            {
                return NotFound("Nenhum produto encontrado.");
            }

            return Ok(produtos);
        }

        [HttpGet("buscar/{id}")]
        public async Task<ActionResult<ProdutoDto>> Buscar(int id)
        {
            var produto = await _produtoService.BuscarPorIdAsync(id);
            if (produto == null)
            {
                return NotFound("Produto com ID " + id + " não encontrado.");
            }

            return Ok(produto);
        }

        [HttpPost("adicionar-novo")]
        public async Task<ActionResult<ProdutoDto>> AdicionarNovo([FromBody] ProdutoDto produtoDto)
        {
            ProdutoDto produto = await _produtoService.AdicionarNovoAsync(produtoDto);
            if (produto == null)
            {
                return NotFound("Cadastro mal-sucedido.");
            }
            return Created(nameof(AdicionarNovo), produtoDto);
        }

        [HttpPut("atualizar")]
        public async Task<ActionResult<ProdutoDto>> Atualizar([FromBody] ProdutoDto produtoDto)
        {
            var produtoAtualizado = await _produtoService.AtualizarAsync(produtoDto);
            if (produtoAtualizado == null)
            {
                return NotFound("Atualização mal-sucedida.");
            }
            return Ok(produtoAtualizado);
        }

        [HttpDelete("remover/{id}")]
        public async Task<ActionResult<ProdutoDto>> Remover(int id)
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
