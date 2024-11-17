using Microsoft.AspNetCore.Mvc;
using Model.Dtos;
using Services;

namespace Controllers
{
    [ApiController]
    [Route("fazenda")]
    public class FazendaController : Controller
    {
        private readonly IFazendaService _fazendaService;

        public FazendaController(IFazendaService fazendaService)
        {
            _fazendaService = fazendaService;
        }

        [HttpGet("buscar-todos")]
        public async Task<ActionResult<IEnumerable<FazendaDto>>> BuscarTodos()
        {
            var fazendas = await _fazendaService.BuscarTodosAsync();
            return Ok(fazendas);
        }

        [HttpGet("buscar/{id}")]
        public async Task<ActionResult<FazendaDto>> Buscar(int id)
        {
            var fazenda = await _fazendaService.BuscarPorIdAsync(id);

            return Ok(fazenda);
        }

        [HttpPost("cadastrar")]
        public async Task<ActionResult<FazendaDto>> Cadastrar([FromBody] CadastrarFazendaDto cadastrarFazendaDto)
        {
            var fazendaCadastrada = await _fazendaService.CadastrarAsync(cadastrarFazendaDto);
            return Created(nameof(Cadastrar), fazendaCadastrada);
        }

        [HttpPut("atualizar")]
        public async Task<ActionResult<FazendaDto>> Atualizar([FromBody] FazendaDto atualzarFazendaDto)
        {
            var fazendaAtualizada = await _fazendaService.AtualizarAsync(atualzarFazendaDto);
            return Ok(fazendaAtualizada);
        }

        [HttpDelete("remover/{id}")]
        public async Task<ActionResult<FazendaDto>> Remover(int id)
        {
            var fazendaRemovida = await _fazendaService.RemoverAsync(id);
            return Ok(fazendaRemovida);
        }
    }
}
