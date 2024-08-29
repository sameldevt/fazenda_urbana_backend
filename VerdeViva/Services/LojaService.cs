using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using _.VerdeViva.Data.Repositories.ClienteRepository;
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

    public LojaService(IProdutoRepository produtoRepository, IUsuarioRepository usuarioRepository)
    {
        _produtoRepository = produtoRepository;
        _usuarioRepository = usuarioRepository;
    }

    public async Task<List<Produto>> BuscarTodos()
    {
        return await _produtoRepository.BuscarTodos();
    }

    public async Task<Produto> Buscar(string nomeProduto)
    {
        return await _produtoRepository.Buscar(nomeProduto);
    }

    public async Task<Pedido> FazerPedido(FazerPedidoDTO dto)
    {
        var usuario =  await _usuarioRepository.Buscar(dto.UsuarioId);

        var pedido = new Pedido
        {
            UsuarioId = dto.UsuarioId,
            Data = DateTime.Now,
            PedidoProdutos = dto.PedidoProdutos.Select(p => new PedidoProduto
            {
                ProdutoId = p.ProdutoId,
                Quantidade = p.Quantidade
            }).ToList()
        };

        _pedidoRepository.Registrar(pedido);
       
        return pedido;
    }
}
