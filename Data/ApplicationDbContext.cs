using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Model.Entities;
using Microsoft.EntityFrameworkCore;
using Services;

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
    public DbSet<Funcionario> Funcionarios { get; set; }
    public DbSet<Colheita> Colheitas { get; set; }
    public DbSet<Cultura> Culturas { get; set; }
    public DbSet<Equipamento> Equipamentos { get; set; }
    public DbSet<Fazenda> Fazendas { get; set; }
    public DbSet<Insumo> Insumos { get; set; }

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

        modelBuilder.Entity<Funcionario>()
            .ToTable("Funcionarios")
            .HasBaseType<Usuario>();

        modelBuilder.Entity<Colheita>()
            .ToTable("Colheitas");

        modelBuilder.Entity<Fazenda>()
            .ToTable("Fazendas");

        modelBuilder.Entity<Insumo>()
            .ToTable("Insumos");

        modelBuilder.Entity<Cultura>()
            .ToTable("Culturas");

        modelBuilder.Entity<Equipamento>()
            .ToTable("Equipamentos");

        modelBuilder.Entity<Produto>()
            .HasOne(p => p.Categoria)
            .WithMany(c => c.Produtos)
            .HasForeignKey(p => p.CategoriaId)
            .OnDelete(DeleteBehavior.NoAction);

        modelBuilder.Entity<Produto>()
            .HasOne(p => p.Nutrientes)
            .WithOne(n => n.Produto)
            .HasForeignKey<Produto>(p => p.NutrientesId)
            .OnDelete(DeleteBehavior.NoAction);

        modelBuilder.Entity<Colheita>()
             .HasOne(c => c.Produto)
             .WithMany()
             .HasForeignKey(c => c.ProdutoId)
             .OnDelete(DeleteBehavior.SetNull);

        modelBuilder.Entity<Pedido>()
            .HasOne(p => p.Cliente)
            .WithMany(c => c.Pedidos)
            .HasForeignKey(p => p.ClienteId)
            .OnDelete(DeleteBehavior.NoAction);

        modelBuilder.Entity<ItemPedido>()
            .HasOne(i => i.Pedido)
            .WithMany(p => p.Itens)
            .HasForeignKey(i => i.PedidoId)
            .OnDelete(DeleteBehavior.NoAction);

        modelBuilder.Entity<ItemPedido>()
            .HasOne(i => i.Produto)
            .WithMany() 
            .HasForeignKey(i => i.ProdutoId)
            .OnDelete(DeleteBehavior.NoAction);

        modelBuilder.Entity<Fornecedor>()
            .HasMany(f => f.Insumos)
            .WithOne(i => i.Fornecedor)
            .HasForeignKey(p => p.FornecedorId)
            .OnDelete(DeleteBehavior.NoAction);

        modelBuilder.Entity<Fornecedor>()
           .HasMany(f => f.Equipamentos)
           .WithOne(e => e.Fornecedor)
           .HasForeignKey(p => p.FornecedorId)
           .OnDelete(DeleteBehavior.NoAction);

        modelBuilder.Entity<Cliente>()
            .HasMany(c => c.Pedidos)
            .WithOne(p => p.Cliente)
            .HasForeignKey(p => p.ClienteId)
            .OnDelete(DeleteBehavior.NoAction);

        modelBuilder.Entity<Fazenda>()
            .HasMany(f => f.Funcionarios)
            .WithOne(f => f.Fazenda)
            .HasForeignKey(f => f.FazendaId)
            .OnDelete(DeleteBehavior.NoAction);

        modelBuilder.Entity<Fazenda>()
            .HasMany(f => f.Equipamentos)
            .WithOne(e => e.Fazenda)
            .HasForeignKey(f => f.FazendaId)
            .OnDelete(DeleteBehavior.NoAction);

        modelBuilder.Entity<Fazenda>()
            .HasMany(f => f.Culturas)
            .WithOne(c => c.Fazenda)
            .HasForeignKey(f => f.FazendaId)
            .OnDelete(DeleteBehavior.NoAction);

        modelBuilder.Entity<Colheita>()
            .HasOne(c => c.Cultura)
            .WithMany(c => c.Colheitas)
            .HasForeignKey(c => c.CulturaId)
            .OnDelete(DeleteBehavior.NoAction);

        modelBuilder.Entity<Colheita>()
            .HasOne(c => c.Cultura)
            .WithMany(c => c.Colheitas)
            .HasForeignKey(c => c.CulturaId)
            .OnDelete(DeleteBehavior.NoAction);

        modelBuilder.Entity<Cultura>()
            .HasOne(c => c.Produto)
            .WithMany()
            .HasForeignKey(i => i.ProdutoId)
            .OnDelete(DeleteBehavior.NoAction);

        modelBuilder.Entity<Cultura>()
            .HasMany(c => c.Colheitas)
            .WithOne(c => c.Cultura)
            .HasForeignKey(c => c.CulturaId)
            .OnDelete(DeleteBehavior.NoAction);

        modelBuilder.Entity<Insumo>()
            .HasOne(i => i.Fornecedor)
            .WithMany(i => i.Insumos)
            .HasForeignKey(i => i.FornecedorId)
            .OnDelete(DeleteBehavior.NoAction);

        modelBuilder.Entity<Equipamento>()
            .HasOne(e => e.Fazenda)
            .WithMany(f => f.Equipamentos)
            .HasForeignKey(e => e.FazendaId)
            .OnDelete(DeleteBehavior.NoAction);

        modelBuilder.Entity<Equipamento>()
            .HasOne(e => e.Fornecedor)
            .WithMany(f => f.Equipamentos)
            .HasForeignKey(e => e.FornecedorId)
            .OnDelete(DeleteBehavior.NoAction);

        modelBuilder.Entity<CulturaInsumo>()
            .HasKey(ci => new { ci.CulturaId, ci.InsumoId });

        modelBuilder.Entity<CulturaInsumo>()
            .HasOne(ci => ci.Cultura)
            .WithMany(c => c.CulturaInsumos)
            .HasForeignKey(ci => ci.CulturaId);

        modelBuilder.Entity<CulturaInsumo>()
            .HasOne(ci => ci.Insumo)
            .WithMany(i => i.CulturaInsumos)
            .HasForeignKey(ci => ci.InsumoId);
    }
}
