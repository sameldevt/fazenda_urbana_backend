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

    public DbSet<Produto> Produto { get; set; } // Corrigido: nome consistente
    public DbSet<ContatoMensagem> Mensagem { get; set; } // Corrigido: nome consistente
    public DbSet<Usuario> Usuario { get; set; } // Corrigido: nome consistente
    public DbSet<Categoria> Categoria { get; set; }
    public DbSet<Pedido> Pedido { get; set; }
    public DbSet<PedidoProduto> PedidoProduto { get; set; }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // Configuração das tabelas
        modelBuilder.Entity<Contato>().ToTable("tb_contato");
        modelBuilder.Entity<Endereco>().ToTable("tb_endereco");
        modelBuilder.Entity<Produto>().ToTable("tb_produto");
        modelBuilder.Entity<ContatoMensagem>().ToTable("tb_contato_mensagem");
        modelBuilder.Entity<Usuario>().ToTable("tb_usuario");
        modelBuilder.Entity<Categoria>().ToTable("tb_categoria");
        modelBuilder.Entity<Pedido>().ToTable("tb_pedido");
        modelBuilder.Entity<PedidoProduto>().ToTable("tb_pedido_produto");

        // Configuração de relacionamento um-para-um entre Usuario e Contato
        modelBuilder.Entity<Usuario>()
            .HasOne(u => u.Contato)
            .WithOne(c => c.Usuario)
            .HasForeignKey<Contato>(c => c.UsuarioId)
            .OnDelete(DeleteBehavior.Cascade); // Configura a exclusão em cascata

        // Configuração de relacionamento um-para-um entre Usuario e Endereco
        modelBuilder.Entity<Usuario>()
            .HasOne(u => u.Endereco)
            .WithOne(e => e.Usuario)
            .OnDelete(DeleteBehavior.Cascade); // Configura a exclusão em cascata

        // Configuração do relacionamento muitos-para-muitos usando a entidade de junção
        modelBuilder.Entity<PedidoProduto>()
            .HasKey(pp => new { pp.PedidoId, pp.ProdutoId });

        modelBuilder.Entity<PedidoProduto>()
            .HasOne(pp => pp.Pedido)
            .WithMany(p => p.PedidoProdutos)
            .HasForeignKey(pp => pp.PedidoId)
            .IsRequired(false); // Torna opcional

        modelBuilder.Entity<PedidoProduto>()
            .HasOne(pp => pp.Produto)
            .WithMany(p => p.PedidoProdutos)
            .HasForeignKey(pp => pp.ProdutoId)
            .IsRequired(false); // Torna opcional

        // Configuração do relacionamento um-para-muitos entre Usuario e Pedido
        modelBuilder.Entity<Pedido>()
            .HasOne(p => p.Usuario)
            .WithMany(u => u.Pedidos)
            .HasForeignKey(p => p.UsuarioId)
            .IsRequired(false); // Torna opcional
    }
}
