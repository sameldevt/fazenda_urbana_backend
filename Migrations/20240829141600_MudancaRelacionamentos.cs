using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace _.Migrations
{
    /// <inheritdoc />
    public partial class MudancaRelacionamentos : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tb_pedido_tb_usuario_UsuarioId",
                table: "tb_pedido");

            migrationBuilder.DropForeignKey(
                name: "FK_tb_pedido_produto_tb_pedido_PedidoId",
                table: "tb_pedido_produto");

            migrationBuilder.DropForeignKey(
                name: "FK_tb_pedido_produto_tb_produto_ProdutoId",
                table: "tb_pedido_produto");

            migrationBuilder.RenameColumn(
                name: "ProdutoId",
                table: "tb_pedido_produto",
                newName: "PkProduto");

            migrationBuilder.RenameColumn(
                name: "PedidoId",
                table: "tb_pedido_produto",
                newName: "PkPedido");

            migrationBuilder.RenameIndex(
                name: "IX_tb_pedido_produto_ProdutoId",
                table: "tb_pedido_produto",
                newName: "IX_tb_pedido_produto_PkProduto");

            migrationBuilder.RenameColumn(
                name: "UsuarioId",
                table: "tb_pedido",
                newName: "PkUsuario");

            migrationBuilder.RenameColumn(
                name: "PedidoId",
                table: "tb_pedido",
                newName: "Id");

            migrationBuilder.RenameIndex(
                name: "IX_tb_pedido_UsuarioId",
                table: "tb_pedido",
                newName: "IX_tb_pedido_PkUsuario");

            migrationBuilder.AddForeignKey(
                name: "FK_tb_pedido_tb_usuario_PkUsuario",
                table: "tb_pedido",
                column: "PkUsuario",
                principalTable: "tb_usuario",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_tb_pedido_produto_tb_pedido_PkPedido",
                table: "tb_pedido_produto",
                column: "PkPedido",
                principalTable: "tb_pedido",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_tb_pedido_produto_tb_produto_PkProduto",
                table: "tb_pedido_produto",
                column: "PkProduto",
                principalTable: "tb_produto",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tb_pedido_tb_usuario_PkUsuario",
                table: "tb_pedido");

            migrationBuilder.DropForeignKey(
                name: "FK_tb_pedido_produto_tb_pedido_PkPedido",
                table: "tb_pedido_produto");

            migrationBuilder.DropForeignKey(
                name: "FK_tb_pedido_produto_tb_produto_PkProduto",
                table: "tb_pedido_produto");

            migrationBuilder.RenameColumn(
                name: "PkProduto",
                table: "tb_pedido_produto",
                newName: "ProdutoId");

            migrationBuilder.RenameColumn(
                name: "PkPedido",
                table: "tb_pedido_produto",
                newName: "PedidoId");

            migrationBuilder.RenameIndex(
                name: "IX_tb_pedido_produto_PkProduto",
                table: "tb_pedido_produto",
                newName: "IX_tb_pedido_produto_ProdutoId");

            migrationBuilder.RenameColumn(
                name: "PkUsuario",
                table: "tb_pedido",
                newName: "UsuarioId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "tb_pedido",
                newName: "PedidoId");

            migrationBuilder.RenameIndex(
                name: "IX_tb_pedido_PkUsuario",
                table: "tb_pedido",
                newName: "IX_tb_pedido_UsuarioId");

            migrationBuilder.AddForeignKey(
                name: "FK_tb_pedido_tb_usuario_UsuarioId",
                table: "tb_pedido",
                column: "UsuarioId",
                principalTable: "tb_usuario",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_tb_pedido_produto_tb_pedido_PedidoId",
                table: "tb_pedido_produto",
                column: "PedidoId",
                principalTable: "tb_pedido",
                principalColumn: "PedidoId");

            migrationBuilder.AddForeignKey(
                name: "FK_tb_pedido_produto_tb_produto_ProdutoId",
                table: "tb_pedido_produto",
                column: "ProdutoId",
                principalTable: "tb_produto",
                principalColumn: "Id");
        }
    }
}
