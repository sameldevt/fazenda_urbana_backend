using Microsoft.AspNetCore.Mvc;
using Model.Dtos;
using Services;

namespace Controllers
{
    [ApiController]
    [Route("equipamento")]
    public class EquipamentoController : Controller
    {
        private readonly IEquipamentoService _equipamentoService;

        public EquipamentoController(IEquipamentoService equipamentoService)
        {
            _equipamentoService = equipamentoService;
        }

        [HttpGet("buscar-todos")]
        public async Task<ActionResult<IEnumerable<EquipamentoDto>>> BuscarTodos()
        {
            var equipamentos = await _equipamentoService.BuscarTodosAsync();
            return Ok(equipamentos);
        }

        [HttpGet("buscar/{id}")]
        public async Task<ActionResult<EquipamentoDto>> Buscar(int id)
        {
            var equipamento = await _equipamentoService.BuscarPorIdAsync(id);

            return Ok(equipamento);
        }

        [HttpPost("cadastrar")]
        public async Task<ActionResult<EquipamentoDto>> Cadastrar([FromBody] CadastrarEquipamentoDto cadastrarEquipamentoDto)
        {
            var equipamentoCadastrado = await _equipamentoService.CadastrarAsync(cadastrarEquipamentoDto);
            return Created(nameof(Cadastrar), equipamentoCadastrado);
        }

        [HttpPut("atualizar")]
        public async Task<ActionResult<EquipamentoDto>> Atualizar([FromBody] EquipamentoDto atualizarEquipamentoDto)
        {
            var equipamentoAtualizado = await _equipamentoService.AtualizarAsync(atualizarEquipamentoDto);
            return Ok(equipamentoAtualizado);
        }

        [HttpDelete("remover/{id}")]
        public async Task<ActionResult<EquipamentoDto>> Remover(int id)
        {
            var equipamentoRemovido = await _equipamentoService.RemoverAsync(id);
            return Ok(equipamentoRemovido);
        }

    }
}
