using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using _.VerdeViva.Models.Entities.Dashboard;
using _.VerdeViva.Models.Entities.Dashboard.Cliente;
using _.VerdeViva.Models.Entities.Producao;
using Microsoft.EntityFrameworkCore;

namespace _.VerdeViva.Data;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) 
        : base(options)
    {

    }

    public DbSet<Produto> Produtos {get; set;} 
    public DbSet<ContatoMensagem> Mensagens {get; set;} 
    public DbSet<Usuario> Usuarios {get; set;}
}
