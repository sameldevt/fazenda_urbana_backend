using Microsoft.AspNetCore.Mvc;
using Model.Dtos;
using Services;

namespace Controllers
{
    [ApiController]
    [Route("colheita")]
    public class ColheitaController : Controller
    {
        private readonly IColheitaService _colheitaService;

        public ColheitaController(IColheitaService colheitaService)
        {
            _colheitaService = colheitaService;
        }

        [HttpGet("buscar-todos")]
        public async Task<ActionResult<IEnumerable<ColheitaDto>>> BuscarTodos()
        {
            var colheitas = await _colheitaService.BuscarTodosAsync();
            return Ok(colheitas);
        }

        [HttpGet("buscar/{id}")]
        public async Task<ActionResult<ColheitaDto>> Buscar(int id)
        {
            var colheita = await _colheitaService.BuscarPorIdAsync(id);

            return Ok(colheita);
        }

        [HttpPost("cadastrar")]
        public async Task<ActionResult<ColheitaDto>> Cadastrar([FromBody] CadastrarColheitaDto cadastrarColheitaDto)
        {
            var colheitaCadastrada = await _colheitaService.CadastrarAsync(cadastrarColheitaDto);
            return Created(nameof(Cadastrar), colheitaCadastrada);
        }

        [HttpPut("atualizar")]
        public async Task<ActionResult<ColheitaDto>> Atualizar([FromBody] ColheitaDto atualizarColheitaDto)
        {
            var colheitaAtualizada = await _colheitaService.AtualizarAsync(atualizarColheitaDto);
            return Ok(colheitaAtualizada);
        }

        [HttpDelete("remover/{id}")]
        public async Task<ActionResult<ColheitaDto>> Remover(int id)
        {
            var colheitaRemovida = await _colheitaService.RemoverAsync(id);
            return Ok(colheitaRemovida);
        }
    }
}
