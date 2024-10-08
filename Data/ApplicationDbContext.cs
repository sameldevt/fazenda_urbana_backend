using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Model.Entities;
using Microsoft.EntityFrameworkCore;

namespace Data;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    public DbSet<Produto> Produtos { get; set; }
    public DbSet<Nutrientes> InformacoesNutricionais { get; set; }
    public DbSet<Categoria> Categorias { get; set; }
    public DbSet<Pedido> Pedidos { get; set; }
    public DbSet<Cliente> Clientes { get; set; }
    public DbSet<Fornecedor> Fornecedores { get; set; }
    public DbSet<MensagemContato> MensagensContato { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Usuario>().ToTable("Usuarios");

        modelBuilder.Entity<Cliente>()
            .ToTable("Clientes")
            .HasBaseType<Usuario>();

        modelBuilder.Entity<Fornecedor>()
            .ToTable("Fornecedores")
            .HasBaseType<Usuario>();

        modelBuilder.Entity<Produto>()
            .HasOne(p => p.Categoria)
            .WithMany(c => c.Produtos)
            .HasForeignKey(p => p.CategoriaId)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<Produto>()
            .HasOne(p => p.Nutrientes)
            .WithOne(n => n.Produto)
            .HasForeignKey<Produto>(p => p.NutrientesId)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<Produto>()
        .HasOne(p => p.Fornecedor)
        .WithMany(n => n.Produtos)
        .HasForeignKey(p => p.FornecedorId)
        .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<Pedido>()
            .HasOne(p => p.Cliente)
            .WithMany(c => c.Pedidos)
            .HasForeignKey(p => p.ClienteId)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<ItemPedido>()
            .HasOne(i => i.Pedido)
            .WithMany(p => p.Itens)
            .HasForeignKey(i => i.PedidoId)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<ItemPedido>()
            .HasOne(i => i.Produto)
            .WithMany() 
            .HasForeignKey(i => i.ProdutoId)
            .OnDelete(DeleteBehavior.Restrict); 

        modelBuilder.Entity<Fornecedor>()
            .HasMany(f => f.Produtos)
            .WithOne(p => p.Fornecedor)
            .HasForeignKey(p => p.FornecedorId)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<Cliente>()
            .HasMany(c => c.Pedidos)
            .WithOne(p => p.Cliente)
            .HasForeignKey(p => p.ClienteId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}
