using Microsoft.AspNetCore.Mvc;
using Model.Dtos;
using Services;

namespace Controllers
{
    [ApiController]
    [Route("insumo")]
    public class InsumoController : Controller
    {
        private readonly IInsumoService _insumoService;

        public InsumoController(IInsumoService insumoService)
        {
            _insumoService = insumoService;
        }

        [HttpGet("buscar-todos")]
        public async Task<ActionResult<IEnumerable<InsumoDto>>> BuscarTodos()
        {
            var insumos = await _insumoService.BuscarTodosAsync();
            return Ok(insumos);
        }

        [HttpGet("buscar/{id}")]
        public async Task<ActionResult<InsumoDto>> Buscar(int id)
        {
            var insumo = await _insumoService.BuscarPorIdAsync(id);

            return Ok(insumo);
        }

        [HttpPost("cadastrar")]
        public async Task<ActionResult<InsumoDto>> Cadastrar([FromBody] CadastrarInsumoDto cadastrarInsumoDto)
        {
            var insumoCadastrado = await _insumoService.CadastrarAsync(cadastrarInsumoDto);
            return Created(nameof(Cadastrar), insumoCadastrado);
        }

        [HttpPut("atualizar")]
        public async Task<ActionResult<InsumoDto>> Atualizar([FromBody] InsumoDto atualizaInsumoDto)
        {
            var insumoAtualizado = await _insumoService.AtualizarAsync(atualizaInsumoDto);
            return Ok(insumoAtualizado);
        }

        [HttpDelete("remover/{id}")]
        public async Task<ActionResult<InsumoDto>> Remover(int id)
        {
            var insumoRemovido = await _insumoService.RemoverAsync(id);
            return Ok(insumoRemovido);
        }
    }
}
