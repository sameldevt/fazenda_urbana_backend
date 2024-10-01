using Model.Entities;
using Services;
using Microsoft.AspNetCore.Mvc;
using Model.Dtos;
using Microsoft.IdentityModel.Tokens;

namespace Controllers
{
    [ApiController]
    [Route("verdeviva/fornecedores")]
    public class FornecedorController : ControllerBase
    {
        private readonly IFornecedorService _fornecedorService;

        public FornecedorController(IFornecedorService fornecedorService)
        {
            _fornecedorService = fornecedorService;
        }

        [HttpGet("listar-todos")]
        public async Task<ActionResult<IEnumerable<VisualizarFornecedorDto>>> BuscarTodos()
        {
            var fornecedores = await _fornecedorService.BuscarTodosAsync();
            if (fornecedores.IsNullOrEmpty())
            {
                return NotFound("Nenhum fornecedor cadastrado.");
            }
            return Ok(fornecedores);
        }

        [HttpGet("buscar/{id}")]
        public async Task<ActionResult<VisualizarFornecedorDto>> Buscar(int id)
        {
            var fornecedor = await _fornecedorService.BuscarPorIdAsync(id);
            if (fornecedor == null)
                return NotFound("Fornecedor com id " + id + " não encontrado.");

            return Ok(fornecedor);
        }

        [HttpPost("cadastrar")]
        public async Task<IActionResult> Cadastrar([FromBody] CadastrarFornecedorDto cadastrarFornecedorDto)
        {
            var fornecedorCadastrado = await _fornecedorService.CadastrarAsync(cadastrarFornecedorDto);
            if(fornecedorCadastrado == null)
            {
                return BadRequest("Fornecedor não cadastrado.");
            }

            return Created(nameof(Cadastrar), fornecedorCadastrado);
        }

        [HttpPut("atualizar")]
        public async Task<ActionResult> Atualizar([FromBody] AtualizarFornecedorDto atualizarFornecedorDto)
        {
            var fornecedorAtualizado = await _fornecedorService.AtualizarAsync(atualizarFornecedorDto);
            if(fornecedorAtualizado == null)
            {
                var id = atualizarFornecedorDto.Id;
                return NotFound("Fornecedor com id " + id + " não encontrado.");
            }

            return Ok(fornecedorAtualizado);
        }

        [HttpDelete("remover/{id}")]
        public async Task<ActionResult> Remover(int id)
        {
            var fornecedorRemovido = await _fornecedorService.RemoverAsync(id);
            if (fornecedorRemovido == null)
            {
                return BadRequest("Fornecedor não removido.");
            }
            return Ok(fornecedorRemovido);
        }
    }

}
