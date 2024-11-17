using Microsoft.AspNetCore.Mvc;
using Model.Dtos;
using Services;

namespace Controllers
{
    [ApiController]
    [Route("cultura")]
    public class CulturaController : Controller
    {
        private readonly ICulturaService _culturaService;

        public CulturaController(ICulturaService culturaService )
        {
            _culturaService = culturaService;
        }

        [HttpGet("buscar-todos")]
        public async Task<ActionResult<IEnumerable<CulturaDto>>> BuscarTodos()
        {
            var culturas = await _culturaService.BuscarTodosAsync();
            return Ok(culturas);
        }

        [HttpGet("buscar/{id}")]
        public async Task<ActionResult<CulturaDto>> Buscar(int id)
        {
            var cultura = await _culturaService.BuscarPorIdAsync(id);

            return Ok(cultura);
        }

        [HttpPost("cadastrar")]
        public async Task<ActionResult<CulturaDto>> Cadastrar([FromBody] CadastrarCulturaDto cadastraCulturaDto)
        {
            var culturaCadastrada = await _culturaService.CadastrarAsync(cadastraCulturaDto);
            return Created(nameof(Cadastrar), culturaCadastrada);
        }

        [HttpPut("atualizar")]
        public async Task<ActionResult<CulturaDto>> Atualizar([FromBody] CulturaDto atualizarCulturaDto)
        {
            var culturaAtualizada = await _culturaService.AtualizarAsync(atualizarCulturaDto);
            return Ok(culturaAtualizada);
        }

        [HttpDelete("remover/{id}")]
        public async Task<ActionResult<FazendaDto>> Remover(int id)
        {
            var culturaRemovida = await _culturaService.RemoverAsync(id);
            return Ok(culturaRemovida);
        }
    }
}
