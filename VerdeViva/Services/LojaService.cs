using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using _.VerdeViva.Data.Repositories.CategoriaRepository;
using _.VerdeViva.Data.Repositories.ClienteRepository;
using _.VerdeViva.Data.Repositories.NutrienteRepository;
using _.VerdeViva.Data.Repositories.PedidoRepository;
using _.VerdeViva.Data.Repositories.ProdutoRepository;
using _.VerdeViva.Models.DTOS.Loja;
using _.VerdeViva.Models.Entities.Loja;
using _.VerdeViva.Models.Entities.Producao;

namespace _.VerdeViva.Services;

public class LojaService
{
    private readonly IProdutoRepository _produtoRepository;
    private readonly IUsuarioRepository _usuarioRepository;
    private readonly IPedidoRepository _pedidoRepository;
    private readonly INutrienteRepository _nutrienteRepository;
    private readonly ICategoriaRepository _categoriaRepository;

    public LojaService(IProdutoRepository produtoRepository, IUsuarioRepository usuarioRepository, INutrienteRepository nutrienteRepository, ICategoriaRepository categoriaRepository)
    {
        _produtoRepository = produtoRepository;
        _usuarioRepository = usuarioRepository;
    }

    public List<BuscarProdutoDTO> BuscarTodos()
    {
        var listaProdutos = new List<BuscarProdutoDTO>();

        var produtos = _produtoRepository.BuscarTodos();
    
        foreach(Produto p in produtos)
        {
            Nutriente nutriente = _nutrienteRepository.Buscar(p.FkNutriente);
            Categoria categoria = _categoriaRepository.Buscar(p.FkCategoria);

            BuscarProdutoDTO produtoDTO = new
            (
                Id: p.Id,
                Nome: p.Nome,
                Descricao: p.Descricao,
                PrecoUnitario: p.PrecoUnitario,
                PrecoQuilo: p.PrecoQuilo,
                QuantidadeEstoque: p.QuantidadeEstoque,
                Nutriente: nutriente,
                Categoria: categoria
            );

            listaProdutos.Add(produtoDTO);
        }

        return listaProdutos;
    }

    public Produto Buscar(string nomeProduto)
    {
        var produto = _produtoRepository.Buscar(nomeProduto);
        
        //Nutriente nutriente = _nutrienteRepository.Buscar(produto.FkNutriente);
        //Categoria categoria = _categoriaRepository.Buscar(produto.FkCategoria);

        return produto;
        // return new BuscarProdutoDTO
        // (
        //     Id: produto.Id,
        //     Nome: produto.Nome,
        //     Descricao: produto.Descricao,
        //     PrecoUnitario: produto.PrecoUnitario,
        //     PrecoQuilo: produto.PrecoQuilo,
        //     QuantidadeEstoque: produto.QuantidadeEstoque,
        //     Nutriente: nutriente,
        //     Categoria: categoria
        // );
    }

    public async Task<Pedido> FazerPedido(FazerPedidoDTO dto)
    {
        var usuario =  await _usuarioRepository.Buscar(dto.UsuarioId);

        var pedido = new Pedido
        {
            FkUsuario = dto.UsuarioId,
            Data = DateTime.Now,
            PedidoProdutos = dto.PedidoProdutos.Select(p => new PedidoProduto
            {
                FkProduto = p.ProdutoId,
                Quantidade = p.Quantidade
            }).ToList()
        };

        _pedidoRepository.Registrar(pedido);
       
        return pedido;
    }
}
