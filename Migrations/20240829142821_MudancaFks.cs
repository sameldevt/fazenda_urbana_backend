using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace _.Migrations
{
    /// <inheritdoc />
    public partial class MudancaFks : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tb_endereco_tb_usuario_fk_usuario",
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
                name: "FK_tb_produto_tb_categoria_fk_categoria",
                table: "tb_produto");

            migrationBuilder.DropIndex(
                name: "IX_tb_endereco_fk_usuario",
                table: "tb_endereco");

            migrationBuilder.DropColumn(
                name: "fk_usuario",
                table: "tb_pedido");

            migrationBuilder.DropColumn(
                name: "fk_usuario",
                table: "tb_endereco");

            migrationBuilder.DropColumn(
                name: "fk_usuario",
                table: "tb_contato");

            migrationBuilder.RenameColumn(
                name: "fk_categoria",
                table: "tb_produto",
                newName: "CategoriaId");

            migrationBuilder.RenameIndex(
                name: "IX_tb_produto_fk_categoria",
                table: "tb_produto",
                newName: "IX_tb_produto_CategoriaId");

            migrationBuilder.CreateIndex(
                name: "IX_tb_endereco_FkUsuario",
                table: "tb_endereco",
                column: "FkUsuario",
                unique: true);

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
                name: "FK_tb_produto_tb_categoria_CategoriaId",
                table: "tb_produto",
                column: "CategoriaId",
                principalTable: "tb_categoria",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
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
                name: "FK_tb_produto_tb_categoria_CategoriaId",
                table: "tb_produto");

            migrationBuilder.DropIndex(
                name: "IX_tb_endereco_FkUsuario",
                table: "tb_endereco");

            migrationBuilder.RenameColumn(
                name: "CategoriaId",
                table: "tb_produto",
                newName: "fk_categoria");

            migrationBuilder.RenameIndex(
                name: "IX_tb_produto_CategoriaId",
                table: "tb_produto",
                newName: "IX_tb_produto_fk_categoria");

            migrationBuilder.AddColumn<int>(
                name: "fk_usuario",
                table: "tb_pedido",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "fk_usuario",
                table: "tb_endereco",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "fk_usuario",
                table: "tb_contato",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_tb_endereco_fk_usuario",
                table: "tb_endereco",
                column: "fk_usuario",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_tb_endereco_tb_usuario_fk_usuario",
                table: "tb_endereco",
                column: "fk_usuario",
                principalTable: "tb_usuario",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_tb_pedido_tb_usuario_FkUsuario",
                table: "tb_pedido",
                column: "FkUsuario",
                principalTable: "tb_usuario",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_tb_pedido_produto_tb_pedido_FkPedido",
                table: "tb_pedido_produto",
                column: "FkPedido",
                principalTable: "tb_pedido",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_tb_pedido_produto_tb_produto_FkProduto",
                table: "tb_pedido_produto",
                column: "FkProduto",
                principalTable: "tb_produto",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_tb_produto_tb_categoria_fk_categoria",
                table: "tb_produto",
                column: "fk_categoria",
                principalTable: "tb_categoria",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
