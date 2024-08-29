using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace _.Migrations
{
    /// <inheritdoc />
    public partial class AdicionarPedidoProduto : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "tb_pedido",
                columns: table => new
                {
                    PedidoId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Data = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_pedido", x => x.PedidoId);
                });

            migrationBuilder.CreateTable(
                name: "tb_pedido_produto",
                columns: table => new
                {
                    PedidoId = table.Column<int>(type: "integer", nullable: false),
                    ProdutoId = table.Column<int>(type: "integer", nullable: false),
                    Quantidade = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_pedido_produto", x => new { x.PedidoId, x.ProdutoId });
                    table.ForeignKey(
                        name: "FK_tb_pedido_produto_tb_pedido_PedidoId",
                        column: x => x.PedidoId,
                        principalTable: "tb_pedido",
                        principalColumn: "PedidoId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tb_pedido_produto_tb_produto_ProdutoId",
                        column: x => x.ProdutoId,
                        principalTable: "tb_produto",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_tb_pedido_produto_ProdutoId",
                table: "tb_pedido_produto",
                column: "ProdutoId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tb_pedido_produto");

            migrationBuilder.DropTable(
                name: "tb_pedido");
        }
    }
}
