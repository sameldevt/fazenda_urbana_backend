using Microsoft.AspNetCore.Mvc;
using Model.Dtos;
using Model.Entities;
using Services;

namespace Controllers
{
    [ApiController]
    [Route("funcionario")]
    public class FuncionarioController : ControllerBase
    {
        private readonly IFuncionarioService _funcionarioService;

        public FuncionarioController(IFuncionarioService funcionarioService)
        {
            _funcionarioService = funcionarioService;
        }

        [HttpGet("buscar-todos")]
        public async Task<ActionResult<IEnumerable<FuncionarioDto>>> BuscarTodos()
        {
            var funcionarios = await _funcionarioService.BuscarTodosAsync();
            return Ok(funcionarios);
        }

        [HttpGet("buscar/{id}")]
        public async Task<ActionResult<FuncionarioDto>> Buscar(int id)
        {
            var funcionario = await _funcionarioService.BuscarPorIdAsync(id);

            return Ok(funcionario);
        }

        [HttpPost("cadastrar")]
        public async Task<ActionResult<FuncionarioDto>> Cadastrar([FromBody] CadastrarFuncionarioDto cadastrarFuncionarioDto)
        {
            var funcionario = await _funcionarioService.CadastrarAsync(cadastrarFuncionarioDto);
            return Created(nameof(Cadastrar), funcionario);
        }

        [HttpPut("atualizar")]
        public async Task<ActionResult<FuncionarioDto>> Atualizar([FromBody] FuncionarioDto atualizarFuncionarioDto)
        {
            var funcionario = await _funcionarioService.AtualizarAsync(atualizarFuncionarioDto);
            return Ok(funcionario);
        }

        [HttpDelete("remover/{id}")]
        public async Task<ActionResult<FuncionarioDto>> Remover(int id)
        {
            var funcionario = await _funcionarioService.RemoverAsync(id);
            return Ok(funcionario);
        }
    }
}
