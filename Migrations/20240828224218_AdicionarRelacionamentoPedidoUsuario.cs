using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace _.Migrations
{
    /// <inheritdoc />
    public partial class AdicionarRelacionamentoPedidoUsuario : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "UsuarioId",
                table: "tb_pedido",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_tb_pedido_UsuarioId",
                table: "tb_pedido",
                column: "UsuarioId");

            migrationBuilder.AddForeignKey(
                name: "FK_tb_pedido_tb_usuario_UsuarioId",
                table: "tb_pedido",
                column: "UsuarioId",
                principalTable: "tb_usuario",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tb_pedido_tb_usuario_UsuarioId",
                table: "tb_pedido");

            migrationBuilder.DropIndex(
                name: "IX_tb_pedido_UsuarioId",
                table: "tb_pedido");

            migrationBuilder.DropColumn(
                name: "UsuarioId",
                table: "tb_pedido");
        }
    }
}
