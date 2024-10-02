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
        public async Task<ActionResult<List<IFornecedorDto>>> BuscarTodos()
        {
            var fornecedores = await _fornecedorService.BuscarTodosAsync();
            return Ok(fornecedores);
        }

        [HttpGet("buscar/{id}")]
        public async Task<ActionResult<IFornecedorDto>> Buscar(int id)
        {
            var fornecedor = await _fornecedorService.BuscarPorIdAsync(id);
            return Ok(fornecedor);
        }

        [HttpPost("cadastrar")]
        public async Task<ActionResult<IFornecedorDto>> Cadastrar([FromBody] CadastrarFornecedorDto cadastrarFornecedorDto)
        {
            var fornecedorCadastrado = await _fornecedorService.CadastrarAsync(cadastrarFornecedorDto);
            return Created(nameof(Cadastrar), fornecedorCadastrado);
        }

        [HttpPut("atualizar")]
        public async Task<ActionResult<IFornecedorDto>> Atualizar([FromBody] AtualizarFornecedorDto atualizarFornecedorDto)
        {
            var fornecedorAtualizado = await _fornecedorService.AtualizarAsync(atualizarFornecedorDto);
            return Ok(fornecedorAtualizado);
        }

        [HttpDelete("remover/{id}")]
        public async Task<ActionResult<IFornecedorDto>> Remover(int id)
        {
            var fornecedorRemovido = await _fornecedorService.RemoverAsync(id);
            return Ok(fornecedorRemovido);
        }
    }

}
