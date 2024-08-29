using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using _.VerdeViva.Data;
using _.VerdeViva.Data.Repositories.CategoriaRepository;
using _.VerdeViva.Data.Repositories.ProdutoRepository;
using _.VerdeViva.Models.DTOS.Producao;
using _.VerdeViva.Models.Entities.Producao;
using Microsoft.AspNetCore.Http.HttpResults;

namespace _.VerdeViva.Services;

public class ProducaoService
{
    private readonly IProdutoRepository _produtoRepository;
    private readonly ICategoriaRepository _categoriaRepository;

    public ProducaoService(IProdutoRepository produtoRepository, ICategoriaRepository categoriaRepository)
    {
        _produtoRepository = produtoRepository;
        _categoriaRepository = categoriaRepository;
    }   

    public string CadastrarProduto(CadastrarProdutoDTO cadastrarProdutoDTO)
    {
        var categoria = _categoriaRepository.Buscar(cadastrarProdutoDTO.CategoriaId);

        if(categoria == null)
        {
            return "Categoria inválida.";
        }

        var produto = Produto.From(cadastrarProdutoDTO, categoria);

        if(!_produtoRepository.Cadastrar(produto))
        {
            return "Produto já cadastrado.";
        };
        
        return "Cadastro bem sucedido.";
    }

    public string CadastrarCategoria(CadastrarCategoriaProdutoDTO cadastrarCategoriaProdutoDTO)
    {
        var categoria = Categoria.From(cadastrarCategoriaProdutoDTO);

        _categoriaRepository.Cadastrar(categoria);

        return "Cadastro bem sucedido.";
    }
}
