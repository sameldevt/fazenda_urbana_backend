﻿using Microsoft.AspNetCore.Mvc;
using Model.Entities;
using Services;

namespace Controllers
{
    [ApiController]
    [Route("verdeviva/pedidos")]
    public class PedidoController : ControllerBase
    {
        private readonly IPedidoService _pedidoService;

        public PedidoController(IPedidoService pedidoService)
        {
            _pedidoService = pedidoService;
        }

        [HttpGet("listar-todos")]
        public async Task<ActionResult<IEnumerable<Pedido>>> ListarTodos()
        {
            var pedidos = await _pedidoService.ListarTodosAsync();
            return Ok(pedidos);
        }

        [HttpGet("buscar/{id}")]
        public async Task<ActionResult<Pedido>> Buscar(int id)
        {
            var pedido = await _pedidoService.BuscarPorIdAsync(id);
            if (pedido == null)
                return NotFound();

            return Ok(pedido);
        }

        [HttpPost("criar-novo")]
        public async Task<ActionResult> CriarNovo([FromBody] Pedido pedido)
        {
            await _pedidoService.CriarNovoAsync(pedido);
            return CreatedAtAction(nameof(Buscar), new { id = pedido.Id }, pedido);
        }

        [HttpPut("atualizar-status/{id}")]
        public async Task<ActionResult> AtualizarStatus(int id, [FromBody] string novoStatus)
        {
            await _pedidoService.AtualizarStatusAsync(id, novoStatus);
            return NoContent();
        }

        [HttpDelete("remover/{id}")]
        public async Task<ActionResult> Remover(int id)
        {
            await _pedidoService.RemoverAsync(id);
            return NoContent();
        }

        [HttpGet("ver-detalhes/{id}")]
        public async Task<IActionResult> VerDetalhes(int id)
        {
            var pedido = await _pedidoService.VerDetalhesAsync(id);
            if (pedido == null)
            {
                return NotFound();
            }
            return Ok(pedido);
        }

        [HttpDelete("cancelar/{id}")]
        public async Task<IActionResult> Cancelar(int id)
        {
            await _pedidoService.RemoverAsync(id);
            return Ok();
        }
    }

}