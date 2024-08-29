using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using _.VerdeViva.Models.Entities.Producao;

namespace _.VerdeViva.Data.Repositories.CategoriaRepository;

public class CategoriaRepository : ICategoriaRepository
{
    private readonly ApplicationDbContext _context;

    public CategoriaRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public Categoria? Buscar(int categoriaId)
    {
        return _context.Categoria.Find(categoriaId);    
    }

    public void Cadastrar(Categoria categoria)
    {
        _context.Categoria.Add(categoria);
        _context.SaveChanges();
    }
}
