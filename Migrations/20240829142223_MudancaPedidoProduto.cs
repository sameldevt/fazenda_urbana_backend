using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace _.Migrations
{
    /// <inheritdoc />
    public partial class MudancaPedidoProduto : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_usuario",
                table: "tb_contato");

            migrationBuilder.DropColumn(
                name: "fk_pedido",
                table: "tb_pedido_produto");

            migrationBuilder.DropColumn(
                name: "fk_produto",
                table: "tb_pedido_produto");

            migrationBuilder.AddForeignKey(
                name: "FK_tb_contato_tb_usuario_FkUsuario",
                table: "tb_contato",
                column: "FkUsuario",
                principalTable: "tb_usuario",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tb_contato_tb_usuario_FkUsuario",
                table: "tb_contato");

            migrationBuilder.AddColumn<int>(
                name: "fk_pedido",
                table: "tb_pedido_produto",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "fk_produto",
                table: "tb_pedido_produto",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "fk_usuario",
                table: "tb_contato",
                column: "FkUsuario",
                principalTable: "tb_usuario",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
