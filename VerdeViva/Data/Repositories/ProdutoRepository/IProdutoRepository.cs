using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using _.VerdeViva.Models.Entities.Producao;

namespace _.VerdeViva.Data.Repositories.ProdutoRepository;

public interface IProdutoRepository
{
    Task<List<Produto>> BuscarTodos();
    Task<Produto> Buscar(string nomeProduto); 
    bool Cadastrar(Produto produto);  
}
