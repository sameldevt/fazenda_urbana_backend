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

        [HttpGet("buscar-todos")]
        public async Task<ActionResult<List<VisualizarProdutoDto>>> BuscarTodos()
        {
            var produtos = await _produtoService.BuscarTodosAsync();
            return Ok(produtos);
        }

        [HttpGet("buscar/{id}")]
        public async Task<ActionResult<VisualizarProdutoDto>> Buscar(int id)
        {
            var produto = await _produtoService.BuscarPorIdAsync(id);
            return Ok(produto);
        }

        [HttpPost("cadastrar")]
        public async Task<ActionResult<VisualizarProdutoDto>> Cadastrar([FromBody] CadastrarProdutoDto cadastrarProdutoDto)
        {
            var produto = await _produtoService.CadastrarAsync(cadastrarProdutoDto);
            return Created(nameof(Cadastrar), produto);
        }

        [HttpPost("cadastrar-varios")]
        public async Task<ActionResult<IEnumerable<VisualizarProdutoDto>>> CadastrarVarios([FromBody] List<CadastrarProdutoDto> cadastrarProdutoDtos)
        {
            var produtos = await _produtoService.CadastrarVariosAsync(cadastrarProdutoDtos);

            return Created(nameof(Cadastrar), produtos);
        }


        [HttpPut("atualizar")]
        public async Task<ActionResult<VisualizarProdutoDto>> Atualizar([FromBody] AtualizarProdutoDto atualizarProdutoDto)
        {
            var produtoAtualizado = await _produtoService.AtualizarAsync(atualizarProdutoDto);
            return Ok(produtoAtualizado);
        }

        [HttpDelete("remover/{id}")]
        public async Task<ActionResult<VisualizarProdutoDto>> Remover(int id)
        {
            var produtoRemovido = await _produtoService.RemoverAsync(id);
            return Ok(produtoRemovido);
        }
    }

}
