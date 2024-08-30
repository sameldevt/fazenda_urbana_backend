﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using _.VerdeViva.Data;

#nullable disable

namespace _.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20240829163348_AdicionadoNutriente1")]
    partial class AdicionadoNutriente1
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("_.VerdeViva.Models.Entities.Dashboard.Cliente.Contato", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("FkUsuario")
                        .HasColumnType("integer");

                    b.Property<string>("Telefone")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("FkUsuario")
                        .IsUnique();

                    b.ToTable("tb_contato", (string)null);
                });

            modelBuilder.Entity("_.VerdeViva.Models.Entities.Dashboard.Cliente.Endereco", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("CEP")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Cidade")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Complemento")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Estado")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("FkUsuario")
                        .HasColumnType("integer");

                    b.Property<string>("InformacoesAdicionais")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Logradouro")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Numero")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("FkUsuario")
                        .IsUnique();

                    b.ToTable("tb_endereco", (string)null);
                });

            modelBuilder.Entity("_.VerdeViva.Models.Entities.Dashboard.Cliente.Usuario", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Senha")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("tb_usuario", (string)null);
                });

            modelBuilder.Entity("_.VerdeViva.Models.Entities.Dashboard.ContatoMensagem", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Mensagem")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Sobrenome")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("tb_contato_mensagem", (string)null);
                });

            modelBuilder.Entity("_.VerdeViva.Models.Entities.Loja.Pedido", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("Data")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int>("FkUsuario")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("FkUsuario");

                    b.ToTable("tb_pedido", (string)null);
                });

            modelBuilder.Entity("_.VerdeViva.Models.Entities.Loja.PedidoProduto", b =>
                {
                    b.Property<int>("FkPedido")
                        .HasColumnType("integer");

                    b.Property<int>("FkProduto")
                        .HasColumnType("integer");

                    b.Property<int>("Quantidade")
                        .HasColumnType("integer");

                    b.HasKey("FkPedido", "FkProduto");

                    b.HasIndex("FkProduto");

                    b.ToTable("tb_pedido_produto", (string)null);
                });

            modelBuilder.Entity("_.VerdeViva.Models.Entities.Producao.Categoria", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("DataCriacao")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("tb_categoria", (string)null);
                });

            modelBuilder.Entity("_.VerdeViva.Models.Entities.Producao.Nutriente", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<decimal>("Caloria")
                        .HasColumnType("numeric");

                    b.Property<decimal>("Fibra")
                        .HasColumnType("numeric");

                    b.Property<decimal>("Gordura")
                        .HasColumnType("numeric");

                    b.Property<decimal>("Proteina")
                        .HasColumnType("numeric");

                    b.Property<decimal>("carboidrato")
                        .HasColumnType("numeric");

                    b.HasKey("Id");

                    b.ToTable("tb_nutriente", (string)null);
                });

            modelBuilder.Entity("_.VerdeViva.Models.Entities.Producao.Produto", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("FkCategoria")
                        .HasColumnType("integer");

                    b.Property<int>("FkNutriente")
                        .HasColumnType("integer");

                    b.Property<string>("ImagemUrl")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<decimal>("PrecoQuilo")
                        .HasColumnType("numeric");

                    b.Property<decimal>("PrecoUnitario")
                        .HasColumnType("numeric");

                    b.Property<int>("QuantidadeEstoque")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("FkCategoria");

                    b.HasIndex("FkNutriente")
                        .IsUnique();

                    b.ToTable("tb_produto", (string)null);
                });

            modelBuilder.Entity("_.VerdeViva.Models.Entities.Dashboard.Cliente.Contato", b =>
                {
                    b.HasOne("_.VerdeViva.Models.Entities.Dashboard.Cliente.Usuario", "Usuario")
                        .WithOne("Contato")
                        .HasForeignKey("_.VerdeViva.Models.Entities.Dashboard.Cliente.Contato", "FkUsuario")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Usuario");
                });

            modelBuilder.Entity("_.VerdeViva.Models.Entities.Dashboard.Cliente.Endereco", b =>
                {
                    b.HasOne("_.VerdeViva.Models.Entities.Dashboard.Cliente.Usuario", "Usuario")
                        .WithOne("Endereco")
                        .HasForeignKey("_.VerdeViva.Models.Entities.Dashboard.Cliente.Endereco", "FkUsuario")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Usuario");
                });

            modelBuilder.Entity("_.VerdeViva.Models.Entities.Loja.Pedido", b =>
                {
                    b.HasOne("_.VerdeViva.Models.Entities.Dashboard.Cliente.Usuario", "Usuario")
                        .WithMany("Pedidos")
                        .HasForeignKey("FkUsuario")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Usuario");
                });

            modelBuilder.Entity("_.VerdeViva.Models.Entities.Loja.PedidoProduto", b =>
                {
                    b.HasOne("_.VerdeViva.Models.Entities.Loja.Pedido", "Pedido")
                        .WithMany("PedidoProdutos")
                        .HasForeignKey("FkPedido")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("_.VerdeViva.Models.Entities.Producao.Produto", "Produto")
                        .WithMany("PedidoProdutos")
                        .HasForeignKey("FkProduto")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Pedido");

                    b.Navigation("Produto");
                });

            modelBuilder.Entity("_.VerdeViva.Models.Entities.Producao.Produto", b =>
                {
                    b.HasOne("_.VerdeViva.Models.Entities.Producao.Categoria", "Categoria")
                        .WithMany("Produtos")
                        .HasForeignKey("FkCategoria")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("_.VerdeViva.Models.Entities.Producao.Nutriente", "Nutriente")
                        .WithOne("Produto")
                        .HasForeignKey("_.VerdeViva.Models.Entities.Producao.Produto", "FkNutriente")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Categoria");

                    b.Navigation("Nutriente");
                });

            modelBuilder.Entity("_.VerdeViva.Models.Entities.Dashboard.Cliente.Usuario", b =>
                {
                    b.Navigation("Contato")
                        .IsRequired();

                    b.Navigation("Endereco")
                        .IsRequired();

                    b.Navigation("Pedidos");
                });

            modelBuilder.Entity("_.VerdeViva.Models.Entities.Loja.Pedido", b =>
                {
                    b.Navigation("PedidoProdutos");
                });

            modelBuilder.Entity("_.VerdeViva.Models.Entities.Producao.Categoria", b =>
                {
                    b.Navigation("Produtos");
                });

            modelBuilder.Entity("_.VerdeViva.Models.Entities.Producao.Nutriente", b =>
                {
                    b.Navigation("Produto")
                        .IsRequired();
                });

            modelBuilder.Entity("_.VerdeViva.Models.Entities.Producao.Produto", b =>
                {
                    b.Navigation("PedidoProdutos");
                });
#pragma warning restore 612, 618
        }
    }
}
