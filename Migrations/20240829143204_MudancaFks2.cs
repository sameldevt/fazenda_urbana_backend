using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace _.Migrations
{
    /// <inheritdoc />
    public partial class MudancaFks2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DropColumn(
                name: "FkCategoria",
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
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AddColumn<int>(
                name: "FkCategoria",
                table: "tb_produto",
                type: "integer",
                nullable: false,
                defaultValue: 0);

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
        }
    }
}
