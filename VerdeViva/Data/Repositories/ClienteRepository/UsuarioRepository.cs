using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using _.VerdeViva.Models.Entities.Dashboard.Cliente;
using Microsoft.EntityFrameworkCore;

namespace _.VerdeViva.Data.Repositories.ClienteRepository;

public class UsuarioRepository : IUsuarioRepository
{
    private readonly ApplicationDbContext _context;

    public UsuarioRepository(ApplicationDbContext context)
    {
        _context = context;
    }
    
    public async Task<Usuario> BuscarPorEmail(string email)
    {
        var usuario = await _context.Usuario.FirstOrDefaultAsync(u => u.Contato.Email == email);

        if (usuario == null)
        {
            // Lidar com o caso em que nenhum usuário foi encontrado
            Console.WriteLine("Usuário não encontrado.");
        }

        return usuario;

    }

    public async Task<Usuario>Buscar(int usuarioId)
    {
        var usuario = await _context.Usuario.FindAsync(usuarioId);

        if (usuario == null)
        {
            // Lidar com o caso em que nenhum usuário foi encontrado
            Console.WriteLine("Usuário não encontrado.");
        }

        return usuario;
    }

    public void Cadastrar(Usuario usuario)
    {
        _context.Add(usuario);
        _context.SaveChanges();
    }
}
