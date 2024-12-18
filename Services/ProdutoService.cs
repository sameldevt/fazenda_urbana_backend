﻿using AutoMapper;
using Model.Dtos;
using Model.Entities;
using Repositories;
using Logging;

namespace Services
{
    public interface IProdutoService
    {
        Task<ProdutoDto> BuscarPorIdAsync(int id);
        Task<ProdutoDto> BuscarPorNomeAsync(string nome);
        Task<List<ProdutoDto>> BuscarTodosAsync();
        Task<CategoriaDto> CadastrarCategoriaAsync(CadastrarCategoriaDto cadastrarCategoriaDto);
        Task<ProdutoDto> CadastrarAsync(CadastrarProdutoDto produtoDto);
        Task<List<ProdutoDto>> CadastrarVariosAsync(List<CadastrarProdutoDto> cadastrarProdutoDtos);
        Task<ProdutoDto> AtualizarAsync(AtualizarProdutoDto produtoDto);
        Task<ProdutoDto> RemoverAsync(int id);
        Task<List<CategoriaDto>> BuscarCategoriasAsync();
    }

    public class ProdutoService : IProdutoService
    {
        private readonly IColheitaService _colheitaService;
        private readonly IProdutoRepository _produtoRepository;
        private readonly IMapper _mapper;

        public ProdutoService(IColheitaService colheitaService, IProdutoRepository produtoRepository, IMapper mapper)
        {
            _colheitaService = colheitaService;
            _produtoRepository = produtoRepository;
            _mapper = mapper;
        }

        public async Task<List<ProdutoDto>> BuscarTodosAsync()
        {
            var produtos = await _produtoRepository.BuscarTodosAsync();

            return _mapper.Map<List<ProdutoDto>>(produtos);
        }

        public async Task<ProdutoDto> BuscarPorNomeAsync(string nome)
        {
            var produto = await _produtoRepository.BuscarPorNomeAsync(nome);

            return _mapper.Map<ProdutoDto>(produto);
        }

        public async Task<ProdutoDto> BuscarPorIdAsync(int id)
        {
            var produto = await _produtoRepository.BuscarPorIdAsync(id);

            return _mapper.Map<ProdutoDto>(produto);
        }


        public async Task<CategoriaDto> CadastrarCategoriaAsync(CadastrarCategoriaDto cadastrarCategoriaDto)
        {
            var categoria = await _produtoRepository.CadastrarCategoriaAsync(_mapper.Map<Categoria>(cadastrarCategoriaDto));

            return _mapper.Map<CategoriaDto>(categoria);
        }

        public async Task<ProdutoDto> CadastrarAsync(CadastrarProdutoDto cadastrarProdutoDto)
        {
            await VerificarCategoria(cadastrarProdutoDto.CategoriaId);

            var produtoParaInserir = _mapper.Map<Produto>(cadastrarProdutoDto);

            var produto = await _produtoRepository.CadastrarAsync(produtoParaInserir);

            return _mapper.Map<ProdutoDto>(produto);
        }

        public async Task<List<ProdutoDto>> CadastrarVariosAsync(List<CadastrarProdutoDto> cadastrarProdutoDtos)
        {
            var produtos = _mapper.Map<List<Produto>>(cadastrarProdutoDtos);
            var produtosParaInserir = new List<Produto>();


            foreach(Produto p in produtos)
            {
                try
                {
                    var categoria = await VerificarCategoria(p.CategoriaId);

                    p.Categoria = categoria;
                    
                    produtosParaInserir.Add(p);
                }
                catch (Exception ex)
                {
                    Logger.LogWarning($"alguem é nulo: {ex}");
                    produtos.Remove(p);
                    continue;
                }
            }
           

            var produtosCadastrados = await _produtoRepository.CadastrarVariosAsync(produtosParaInserir);

            return _mapper.Map<List<ProdutoDto>>(produtosCadastrados);
        }
        public async Task<ProdutoDto> AtualizarAsync(AtualizarProdutoDto atualizarProdutoDto)
        {
            var produto = await _produtoRepository.BuscarPorIdAsync(atualizarProdutoDto.Id);

            produto = _mapper.Map<Produto>(atualizarProdutoDto);

            var produtoAtualizado  =await _produtoRepository.AtualizarAsync(produto);

            return _mapper.Map<ProdutoDto>(produtoAtualizado);
        }

        public async Task<ProdutoDto> RemoverAsync(int id)
        {
            var produto = await _produtoRepository.RemoverAsync(id);

            return _mapper.Map<ProdutoDto>(produto);
        }

        private async Task<Categoria> VerificarCategoria(int id)
        {
            return await _produtoRepository.BuscarCategoriaPorIdAsync(id);
        }

        private async Task<Fornecedor> VerfificarFornecedor(int id)
        {
            return await _produtoRepository.BuscarFornecedorPorIdAsync(id);
        }

        public async Task<List<CategoriaDto>> BuscarCategoriasAsync()
        {
            var categorias = await _produtoRepository.ListarCategoriasAsync();
            
            return _mapper.Map<List<CategoriaDto>>(categorias);
        }
    }
}
