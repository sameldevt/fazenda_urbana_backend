using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using _.VerdeViva.Models.Entities.Producao;
using Microsoft.EntityFrameworkCore;

namespace _.VerdeViva.Data.Repositories.ProdutoRepository;

public class ProdutoRepository : IProdutoRepository
{
    private readonly ApplicationDbContext _context;

    public ProdutoRepository(ApplicationDbContext context)
    {
        _context = context;
    }
    
    public async Task<List<Produto>> BuscarTodos()
    {
        return await _context.Produto.ToListAsync();
    }

    public async Task<Produto> Buscar(string nomeProduto)
    {
    var produto = await _context.Produto.FirstOrDefaultAsync(p => p.Nome == nomeProduto);

    return produto;
    }


    public bool Cadastrar(Produto produto)
    {
        var produtoCastrado = _context.Produto.Add(produto);
    
        if(produtoCastrado == null)
        {
            return false;
        }

        _context.SaveChanges();
        return true;
    }
}
