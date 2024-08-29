using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using _.VerdeViva.Services;
using _.VerdeViva.Models.DTOS.Producao;

namespace _.VerdeViva.Controllers;

[ApiController]
[Route("verdeviva/producao")]
public class ProducaoController : ControllerBase
{   
    private readonly ProducaoService _producaoService;

    public ProducaoController(ProducaoService producaoCService)
    {
        _producaoService = producaoCService;
    }

    [HttpPost("cadastrar-produto")]
    public IActionResult CadastrarProduto(CadastrarProdutoDTO cadastrarProdutoDTO){
        var message = _producaoService.CadastrarProduto(cadastrarProdutoDTO);
    
        return CreatedAtAction(
            actionName: nameof(CadastrarProduto),
            value: message
        );
    }

    [HttpPost("cadastrar-categoria")]
    public IActionResult CadastrarCategoria(CadastrarCategoriaProdutoDTO cadastrarCategoriaProdutoDTO){
        var message = _producaoService.CadastrarCategoria(cadastrarCategoriaProdutoDTO);
    
        return CreatedAtAction(
            actionName: nameof(CadastrarCategoria),
            value: message
        );
    }
}
