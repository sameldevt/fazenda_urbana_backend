﻿using Model.Entities;
using Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Model.Dtos;

namespace Controllers
{
    [ApiController]
    [Route("produto")]
    public class ProdutoController : ControllerBase
    {
        private readonly IProdutoService _produtoService;

        public ProdutoController(IProdutoService produtoService)
        {
            _produtoService = produtoService;
        }

        [HttpGet("buscar-todos")]
        public async Task<ActionResult<List<ProdutoDto>>> BuscarTodos()
        {
            var produtos = await _produtoService.BuscarTodosAsync();
            return Ok(produtos);
        }

        [HttpGet("buscar/{id}")]
        public async Task<ActionResult<ProdutoDto>> Buscar(int id)
        {
            var produto = await _produtoService.BuscarPorIdAsync(id);
            return Ok(produto);
        }


        [HttpPost("cadastrar-categoria")]
        public async Task<ActionResult<CategoriaDto>> CadastrarCategoria([FromBody] CadastrarCategoriaDto cadastrarCategoriaDto)
        {
            var produto = await _produtoService.CadastrarCategoriaAsync(cadastrarCategoriaDto);
            return Created(nameof(Cadastrar), produto);
        }

        [HttpPost("cadastrar")]
        public async Task<ActionResult<ProdutoDto>> Cadastrar([FromBody] CadastrarProdutoDto cadastrarProdutoDto)
        {
            var produto = await _produtoService.CadastrarAsync(cadastrarProdutoDto);
            return Created(nameof(Cadastrar), produto);
        }

        [HttpPost("cadastrar-varios")]
        public async Task<ActionResult<IEnumerable<ProdutoDto>>> CadastrarVarios([FromBody] List<CadastrarProdutoDto> cadastrarProdutoDtos)
        {
            var produtos = await _produtoService.CadastrarVariosAsync(cadastrarProdutoDtos);

            return Created(nameof(Cadastrar), produtos);
        }


        [HttpPut("atualizar")]
        public async Task<ActionResult<ProdutoDto>> Atualizar([FromBody] AtualizarProdutoDto atualizarProdutoDto)
        {
            var produtoAtualizado = await _produtoService.AtualizarAsync(atualizarProdutoDto);
            return Ok(produtoAtualizado);
        }

        [HttpDelete("remover/{id}")]
        public async Task<ActionResult<ProdutoDto>> Remover(int id)
        {
            var produtoRemovido = await _produtoService.RemoverAsync(id);
            return Ok(produtoRemovido);
        }

        [HttpGet("buscar-categorias")]
        public async Task<ActionResult<CategoriaDto>> BuscarCategorias()
        {
            var categorias = await _produtoService.BuscarCategoriasAsync();
            return Ok(categorias);
        }
    }

}
