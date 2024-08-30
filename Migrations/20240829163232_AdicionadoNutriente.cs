using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace _.Migrations
{
    /// <inheritdoc />
    public partial class AdicionadoNutriente : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_usuario",
                table: "tb_contato");

            migrationBuilder.DropForeignKey(
                name: "fk_usuario",
                table: "tb_endereco");

            migrationBuilder.DropForeignKey(
                name: "fk_usuario",
                table: "tb_pedido");

            migrationBuilder.DropForeignKey(
                name: "fk_pedido",
                table: "tb_pedido_produto");

            migrationBuilder.DropForeignKey(
                name: "fk_produto",
                table: "tb_pedido_produto");

            migrationBuilder.DropForeignKey(
                name: "fk_categoria",
                table: "tb_produto");

            migrationBuilder.AddColumn<int>(
                name: "FkNutriente",
                table: "tb_produto",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "tb_nutriente",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Caloria = table.Column<decimal>(type: "numeric", nullable: false),
                    Proteina = table.Column<decimal>(type: "numeric", nullable: false),
                    carboidrato = table.Column<decimal>(type: "numeric", nullable: false),
                    Fibra = table.Column<decimal>(type: "numeric", nullable: false),
                    Gordura = table.Column<decimal>(type: "numeric", nullable: false),
                    FkProduto = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_nutriente", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_tb_produto_FkNutriente",
                table: "tb_produto",
                column: "FkNutriente",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_tb_contato_tb_usuario_FkUsuario",
                table: "tb_contato",
                column: "FkUsuario",
                principalTable: "tb_usuario",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_tb_endereco_tb_usuario_FkUsuario",
                table: "tb_endereco",
                column: "FkUsuario",
                principalTable: "tb_usuario",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_tb_pedido_tb_usuario_FkUsuario",
                table: "tb_pedido",
                column: "FkUsuario",
                principalTable: "tb_usuario",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_tb_pedido_produto_tb_pedido_FkPedido",
                table: "tb_pedido_produto",
                column: "FkPedido",
                principalTable: "tb_pedido",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_tb_pedido_produto_tb_produto_FkProduto",
                table: "tb_pedido_produto",
                column: "FkProduto",
                principalTable: "tb_produto",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_tb_produto_tb_categoria_FkCategoria",
                table: "tb_produto",
                column: "FkCategoria",
                principalTable: "tb_categoria",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_tb_produto_tb_nutriente_FkNutriente",
                table: "tb_produto",
                column: "FkNutriente",
                principalTable: "tb_nutriente",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tb_contato_tb_usuario_FkUsuario",
                table: "tb_contato");

            migrationBuilder.DropForeignKey(
                name: "FK_tb_endereco_tb_usuario_FkUsuario",
                table: "tb_endereco");

            migrationBuilder.DropForeignKey(
                name: "FK_tb_pedido_tb_usuario_FkUsuario",
                table: "tb_pedido");

            migrationBuilder.DropForeignKey(
                name: "FK_tb_pedido_produto_tb_pedido_FkPedido",
                table: "tb_pedido_produto");

            migrationBuilder.DropForeignKey(
                name: "FK_tb_pedido_produto_tb_produto_FkProduto",
                table: "tb_pedido_produto");

            migrationBuilder.DropForeignKey(
                name: "FK_tb_produto_tb_categoria_FkCategoria",
                table: "tb_produto");

            migrationBuilder.DropForeignKey(
                name: "FK_tb_produto_tb_nutriente_FkNutriente",
                table: "tb_produto");

            migrationBuilder.DropTable(
                name: "tb_nutriente");

            migrationBuilder.DropIndex(
                name: "IX_tb_produto_FkNutriente",
                table: "tb_produto");

            migrationBuilder.DropColumn(
                name: "FkNutriente",
                table: "tb_produto");

            migrationBuilder.AddForeignKey(
                name: "fk_usuario",
                table: "tb_contato",
                column: "FkUsuario",
                principalTable: "tb_usuario",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_usuario",
                table: "tb_endereco",
                column: "FkUsuario",
                principalTable: "tb_usuario",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_usuario",
                table: "tb_pedido",
                column: "FkUsuario",
                principalTable: "tb_usuario",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "fk_pedido",
                table: "tb_pedido_produto",
                column: "FkPedido",
                principalTable: "tb_pedido",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "fk_produto",
                table: "tb_pedido_produto",
                column: "FkProduto",
                principalTable: "tb_produto",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "fk_categoria",
                table: "tb_produto",
                column: "FkCategoria",
                principalTable: "tb_categoria",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
