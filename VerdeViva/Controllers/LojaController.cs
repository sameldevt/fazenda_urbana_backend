using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using _.VerdeViva.Models.Entities.Producao;
using _.VerdeViva.Services;
using Microsoft.AspNetCore.Mvc;

namespace _.VerdeViva.Controllers;

[ApiController]
[Route("verdeviva/loja")]
public class LojaController : ControllerBase
{
    private readonly LojaService _lojaService;

    public LojaController(LojaService lojaService)
    {
        _lojaService = lojaService;
    }

    [HttpGet("buscar/{nome}")]
    public async Task<IActionResult> Buscar([FromRoute] string nome)
    {
        var produto = await _lojaService.Buscar(nome);

        if(produto == null)
        {
            return NotFound();
        }

        return Ok(produto);
    }

    [HttpGet("buscar-todos")]
    public async Task<IActionResult> BuscarTodos()
    {
        var produtos = await _lojaService.BuscarTodos();

        return Ok(produtos);
    }
}
