using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using _.VerdeViva.Models.Entities.Producao;

namespace _.VerdeViva.Data.Repositories.NutrienteRepository;

public class NutrienteRepository : INutrienteRepository
{
    private readonly ApplicationDbContext _context;

    public NutrienteRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public Nutriente? Buscar(int PkNutriente)
    {
        return _context.Nutriente.Find(PkNutriente);    
    }
}
