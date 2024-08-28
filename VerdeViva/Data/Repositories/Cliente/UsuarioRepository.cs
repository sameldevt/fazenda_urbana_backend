using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using _.VerdeViva.Models.Entities.Dashboard.Cliente;
using Microsoft.EntityFrameworkCore;

namespace _.VerdeViva.Data.Repositories.Cliente;

public class UsuarioRepository : IUsuarioRepository
{
    private readonly ApplicationDbContext _context;

    public UsuarioRepository(ApplicationDbContext context)
    {
        _context = context;
    }
    
    public async Task<Usuario> BuscarPorEmail(string email)
    {
        return await _context.Usuarios
                            .AsNoTracking() 
                            .FirstAsync(u => u.Contato!.Email == email);
    }
}
