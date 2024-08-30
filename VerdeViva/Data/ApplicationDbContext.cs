using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using _.VerdeViva.Models.Entities.Dashboard;
using _.VerdeViva.Models.Entities.Dashboard.Cliente;
using _.VerdeViva.Models.Entities.Loja;
using _.VerdeViva.Models.Entities.Producao;
using Microsoft.EntityFrameworkCore;

namespace _.VerdeViva.Data;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) 
        : base(options)
    {
    }

    public DbSet<Produto> Produto { get; set; } 

    public DbSet<Nutriente> Nutriente {get; set;}
    public DbSet<ContatoMensagem> Mensagem { get; set; } 
    public DbSet<Usuario> Usuario { get; set; } 
    public DbSet<Categoria> Categoria { get; set; }
    public DbSet<Pedido> Pedido { get; set; }
    public DbSet<PedidoProduto> PedidoProduto { get; set; }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Contato>().ToTable("tb_contato");
        modelBuilder.Entity<Endereco>().ToTable("tb_endereco");
        modelBuilder.Entity<Produto>().ToTable("tb_produto");
        modelBuilder.Entity<ContatoMensagem>().ToTable("tb_contato_mensagem");
        modelBuilder.Entity<Usuario>().ToTable("tb_usuario");
        modelBuilder.Entity<Categoria>().ToTable("tb_categoria");
        modelBuilder.Entity<Pedido>().ToTable("tb_pedido");
        modelBuilder.Entity<PedidoProduto>().ToTable("tb_pedido_produto");
        modelBuilder.Entity<Nutriente>().ToTable("tb_nutriente");

        modelBuilder.Entity<Usuario>()
            .HasOne(u => u.Contato)
            .WithOne(c => c.Usuario)
            .HasForeignKey<Contato>(c => c.FkUsuario)
            .OnDelete(DeleteBehavior.Cascade); 

        modelBuilder.Entity<Usuario>()
            .HasOne(u => u.Endereco)
            .WithOne(e => e.Usuario)
            .HasForeignKey<Endereco>(e => e.FkUsuario)
            .OnDelete(DeleteBehavior.Cascade); 

        modelBuilder.Entity<PedidoProduto>()
            .HasKey(pp => new { pp.FkPedido, pp.FkProduto });

        modelBuilder.Entity<PedidoProduto>()
            .HasOne(pp => pp.Pedido)
            .WithMany(p => p.PedidoProdutos)
            .HasForeignKey(pp => pp.FkPedido)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<PedidoProduto>()
            .HasOne(pp => pp.Produto)
            .WithMany(p => p.PedidoProdutos)
            .HasForeignKey(pp => pp.FkProduto)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<Pedido>()
            .HasOne(p => p.Usuario)
            .WithMany(u => u.Pedidos)
            .HasForeignKey(p => p.FkUsuario)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<Produto>()
            .HasOne(p => p.Nutriente)
            .WithOne(n => n.Produto)
            .HasForeignKey<Produto>(p => p.FkNutriente)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<Produto>()
            .HasOne(p => p.Categoria)
            .WithMany(c => c.Produtos)
            .HasForeignKey(p => p.FkCategoria)
            .OnDelete(DeleteBehavior.Cascade);
    }
}
