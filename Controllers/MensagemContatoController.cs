using Model.Entities;
using Services;
using Microsoft.AspNetCore.Mvc;
using Model.Dtos;
using Exceptions;

namespace Controllers
{
    [ApiController]
    [Route("contato")]
    public class MensagemContatoController : ControllerBase
    {
        private readonly IMensagemContatoService _mensagemContatoService;

        public MensagemContatoController(IMensagemContatoService mensagemContatoService)
        {
            _mensagemContatoService = mensagemContatoService;
        }

        [HttpPost("enviar-mensagem")]
        public async Task<ActionResult<CadastrarMensagemContatoDto>> CadastrarMensagemContato([FromBody] CadastrarMensagemContatoDto registrarMensagemDto)
        {
            var mensagemRegistrada = await _mensagemContatoService.CadastrarMensagemAsync(registrarMensagemDto);
            return Created(nameof(CadastrarMensagemContato), mensagemRegistrada);
        }

        [HttpGet("buscar-todas")]
        public async Task<ActionResult<List<CadastrarMensagemContatoDto>>> BuscarTodasMensagens()
        {
            var mensagens = await _mensagemContatoService.BuscarTodasMensagensAsync();

            return Ok(mensagens);
        }

        [HttpGet("buscar/{id}")]
        public async Task<ActionResult<CadastrarMensagemContatoDto>> Buscar(int id)
        {
            var mensagem = await _mensagemContatoService.BuscarMensagemPorIdAsync(id);
            return Ok(mensagem);
        }

        [HttpPut("atualizar")]
        public async Task<ActionResult<CadastrarMensagemContatoDto>> AtualizarMensagemContato([FromBody] MensagemContatoDto atualizarMensagemDto)
        {
            var mensagemAtualizada = await _mensagemContatoService.AtualizarMensagemAsync(atualizarMensagemDto);
            return Ok(mensagemAtualizada);
        }

        [HttpDelete("remover/{id}")]
        public async Task<ActionResult<CadastrarMensagemContatoDto>> RemoverMensagemContato(int id)
        { 
            var mensagemRemovida = await _mensagemContatoService.RemoverMensagemAsync(id);
            return Ok(mensagemRemovida);
        }
    }
}
