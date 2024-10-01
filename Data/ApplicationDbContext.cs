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
    public DbSet<InformacoesNutricionais> InformacoesNutricionais { get; set; }
    public DbSet<Categoria> Categorias { get; set; }
    public DbSet<Pedido> Pedidos { get; set; }
    public DbSet<Cliente> Clientes { get; set; }
    public DbSet<Fornecedor> Fornecedores { get; set; }
    public DbSet<FaleConosco> FaleConosco { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // Configuração da entidade Produto
        modelBuilder.Entity<Produto>(entity =>
        {
            entity.ToTable("Produtos");

            entity.HasKey(p => p.Id);

            entity.Property(p => p.Nome)
                  .IsRequired()
                  .HasMaxLength(100);

            entity.Property(p => p.Descricao)
                  .IsRequired()
                  .HasMaxLength(300);

            entity.Property(p => p.PrecoUnitario)
                  .HasColumnType("decimal(18,2)");

            entity.Property(p => p.PrecoQuilo)
                  .HasColumnType("decimal(18,2)");

            entity.Property(p => p.QuantidadeEstoque)
                  .IsRequired();

            entity.Property(p => p.ImagemUrl)
                  .HasMaxLength(200);  // Adicionei um tamanho máximo para ImagemUrl

            entity.HasOne(p => p.Categoria)
                  .WithMany(c => c.Produtos)
                  .HasForeignKey(p => p.CategoriaId);

            entity.HasOne(p => p.InformacoesNutricionais)
                  .WithOne(i => i.Produto)
                  .HasForeignKey<InformacoesNutricionais>(i => i.ProdutoId);
        });

        // Configuração da entidade InformacoesNutricionais
        modelBuilder.Entity<InformacoesNutricionais>(entity =>
        {
            entity.ToTable("InformacoesNutricionais");

            entity.HasKey(i => i.Id);

            entity.Property(i => i.Calorias)
                  .HasColumnType("decimal(18,2)");

            entity.Property(i => i.Proteinas)
                  .HasColumnType("decimal(18,2)");

            entity.Property(i => i.Carboidratos)
                  .HasColumnType("decimal(18,2)");

            entity.Property(i => i.Fibras)
                  .HasColumnType("decimal(18,2)");

            entity.Property(i => i.Gorduras)
                  .HasColumnType("decimal(18,2)");
        });

        // Configuração da entidade Categoria
        modelBuilder.Entity<Categoria>(entity =>
        {
            entity.ToTable("Categorias");

            entity.HasKey(c => c.Id);

            entity.Property(c => c.Nome)
                  .IsRequired()
                  .HasMaxLength(50);

            entity.Property(c => c.Descricao)
                  .HasMaxLength(200);  // Ajuste de tamanho da descrição

            entity.Property(c => c.DataCriacao)
                  .IsRequired();
        });

        // Configuração da entidade Pedido
        modelBuilder.Entity<Pedido>(entity =>
        {
            entity.ToTable("Pedidos");

            entity.HasKey(p => p.Id);

            entity.Property(p => p.DataPedido)
                  .IsRequired();

            entity.Property(p => p.DataEntrega);

            entity.Property(p => p.Status)
                  .IsRequired()
                  .HasMaxLength(50); // Limite adicionado ao Status

            entity.Property(p => p.Total)
                  .HasColumnType("decimal(18,2)")
                  .IsRequired();

            entity.Property(p => p.EnderecoEntrega)
                  .IsRequired()
                  .HasMaxLength(200); // Limite adicionado ao Endereço de Entrega

            entity.Property(p => p.FormaPagamento)
                  .IsRequired()
                  .HasMaxLength(50); // Limite adicionado à Forma de Pagamento

            entity.Property(p => p.Notas)
                  .HasMaxLength(500); // Limite adicionado às Notas

            entity.HasOne(p => p.Cliente)
                  .WithMany(c => c.Pedidos)
                  .HasForeignKey(p => p.ClienteId);

            entity.HasMany(p => p.Itens)
                  .WithOne(i => i.Pedido)
                  .HasForeignKey(i => i.PedidoId);
        });

        // Configuração da entidade Cliente
        modelBuilder.Entity<Cliente>(entity =>
        {
            entity.ToTable("Clientes");

            entity.HasKey(c => c.Id);

            entity.Property(c => c.Nome)
                  .IsRequired()
                  .HasMaxLength(100);

            entity.Property(c => c.Senha)
                  .IsRequired()
                  .HasMaxLength(100);

            entity.HasOne(c => c.Contato)
                  .WithOne(ct => ct.Cliente)
                  .HasForeignKey<Contato>(ct => ct.ClienteId);

            entity.HasOne(c => c.Endereco)
                  .WithOne(e => e.Cliente)
                  .HasForeignKey<Endereco>(e => e.ClienteId);
        });

        // Configuração da entidade Fornecedor
        modelBuilder.Entity<Fornecedor>(entity =>
        {
            entity.ToTable("Fornecedores");

            entity.HasKey(f => f.Id);

            entity.Property(f => f.Nome)
                  .IsRequired()
                  .HasMaxLength(100);

            entity.Property(f => f.CNPJ)
                  .IsRequired()
                  .HasMaxLength(20);

            entity.Property(f => f.Endereco) // Corrigido de "Endereço" para "Endereco"
                  .IsRequired()
                  .HasMaxLength(100);

            entity.Property(f => f.Telefone)
                  .HasMaxLength(15);

            entity.Property(f => f.Email)
                  .IsRequired()
                  .HasMaxLength(100);

            entity.Property(f => f.Website)
                  .HasMaxLength(100);

            entity.Property(f => f.ContatoPrincipal)
                  .HasMaxLength(100);

            entity.Property(f => f.DataCadastro)
                  .IsRequired();
        });

        modelBuilder.Entity<FaleConosco>(entity =>
        {
            entity.ToTable("MensagensFaleConosco");

            entity.HasKey(fc => fc.Id);

            entity.Property(fc => fc.Nome)
                  .IsRequired()
                  .HasMaxLength(200);

            entity.Property(fc => fc.Email)
                  .IsRequired()
                  .HasMaxLength(100);

            entity.Property(fc => fc.DataEnvio);

            entity.Property(fc => fc.Respondido)
                  .IsRequired();
        });
    }

}
