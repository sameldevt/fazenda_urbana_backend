using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace _.Migrations
{
    /// <inheritdoc />
    public partial class MudancaNomesFks : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_usuario",
                table: "tb_contato");

            migrationBuilder.DropForeignKey(
                name: "FK_tb_endereco_tb_usuario_PkUsuario",
                table: "tb_endereco");

            migrationBuilder.DropForeignKey(
                name: "FK_tb_pedido_tb_usuario_PkUsuario",
                table: "tb_pedido");

            migrationBuilder.DropForeignKey(
                name: "FK_tb_pedido_produto_tb_pedido_PkPedido",
                table: "tb_pedido_produto");

            migrationBuilder.DropForeignKey(
                name: "FK_tb_pedido_produto_tb_produto_PkProduto",
                table: "tb_pedido_produto");

            migrationBuilder.DropForeignKey(
                name: "FK_tb_produto_tb_categoria_PkCategoria",
                table: "tb_produto");

            migrationBuilder.DropPrimaryKey(
                name: "PK_tb_pedido_produto",
                table: "tb_pedido_produto");

            migrationBuilder.DropIndex(
                name: "IX_tb_pedido_produto_PkProduto",
                table: "tb_pedido_produto");

            migrationBuilder.DropIndex(
                name: "IX_tb_pedido_PkUsuario",
                table: "tb_pedido");

            migrationBuilder.DropIndex(
                name: "IX_tb_contato_PkUsuario",
                table: "tb_contato");

            migrationBuilder.RenameColumn(
                name: "PkCategoria",
                table: "tb_produto",
                newName: "fk_categoria");

            migrationBuilder.RenameIndex(
                name: "IX_tb_produto_PkCategoria",
                table: "tb_produto",
                newName: "IX_tb_produto_fk_categoria");

            migrationBuilder.RenameColumn(
                name: "PkProduto",
                table: "tb_pedido_produto",
                newName: "fk_produto");

            migrationBuilder.RenameColumn(
                name: "PkPedido",
                table: "tb_pedido_produto",
                newName: "fk_pedido");

            migrationBuilder.RenameColumn(
                name: "PkUsuario",
                table: "tb_pedido",
                newName: "fk_usuario");

            migrationBuilder.RenameColumn(
                name: "PkUsuario",
                table: "tb_endereco",
                newName: "fk_usuario");

            migrationBuilder.RenameIndex(
                name: "IX_tb_endereco_PkUsuario",
                table: "tb_endereco",
                newName: "IX_tb_endereco_fk_usuario");

            migrationBuilder.RenameColumn(
                name: "PkUsuario",
                table: "tb_contato",
                newName: "fk_usuario");

            migrationBuilder.AddColumn<int>(
                name: "FkCategoria",
                table: "tb_produto",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "FkPedido",
                table: "tb_pedido_produto",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "FkProduto",
                table: "tb_pedido_produto",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "FkUsuario",
                table: "tb_pedido",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "FkUsuario",
                table: "tb_endereco",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "FkUsuario",
                table: "tb_contato",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_tb_pedido_produto",
                table: "tb_pedido_produto",
                columns: new[] { "FkPedido", "FkProduto" });

            migrationBuilder.CreateIndex(
                name: "IX_tb_pedido_produto_FkProduto",
                table: "tb_pedido_produto",
                column: "FkProduto");

            migrationBuilder.CreateIndex(
                name: "IX_tb_pedido_FkUsuario",
                table: "tb_pedido",
                column: "FkUsuario");

            migrationBuilder.CreateIndex(
                name: "IX_tb_contato_FkUsuario",
                table: "tb_contato",
                column: "FkUsuario",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "fk_usuario",
                table: "tb_contato",
                column: "FkUsuario",
                principalTable: "tb_usuario",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_usuario",
                table: "tb_contato");

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

            migrationBuilder.DropPrimaryKey(
                name: "PK_tb_pedido_produto",
                table: "tb_pedido_produto");

            migrationBuilder.DropIndex(
                name: "IX_tb_pedido_produto_FkProduto",
                table: "tb_pedido_produto");

            migrationBuilder.DropIndex(
                name: "IX_tb_pedido_FkUsuario",
                table: "tb_pedido");

            migrationBuilder.DropIndex(
                name: "IX_tb_contato_FkUsuario",
                table: "tb_contato");

            migrationBuilder.DropColumn(
                name: "FkCategoria",
                table: "tb_produto");

            migrationBuilder.DropColumn(
                name: "FkPedido",
                table: "tb_pedido_produto");

            migrationBuilder.DropColumn(
                name: "FkProduto",
                table: "tb_pedido_produto");

            migrationBuilder.DropColumn(
                name: "FkUsuario",
                table: "tb_pedido");

            migrationBuilder.DropColumn(
                name: "FkUsuario",
                table: "tb_endereco");

            migrationBuilder.DropColumn(
                name: "FkUsuario",
                table: "tb_contato");

            migrationBuilder.RenameColumn(
                name: "fk_categoria",
                table: "tb_produto",
                newName: "PkCategoria");

            migrationBuilder.RenameIndex(
                name: "IX_tb_produto_fk_categoria",
                table: "tb_produto",
                newName: "IX_tb_produto_PkCategoria");

            migrationBuilder.RenameColumn(
                name: "fk_produto",
                table: "tb_pedido_produto",
                newName: "PkProduto");

            migrationBuilder.RenameColumn(
                name: "fk_pedido",
                table: "tb_pedido_produto",
                newName: "PkPedido");

            migrationBuilder.RenameColumn(
                name: "fk_usuario",
                table: "tb_pedido",
                newName: "PkUsuario");

            migrationBuilder.RenameColumn(
                name: "fk_usuario",
                table: "tb_endereco",
                newName: "PkUsuario");

            migrationBuilder.RenameIndex(
                name: "IX_tb_endereco_fk_usuario",
                table: "tb_endereco",
                newName: "IX_tb_endereco_PkUsuario");

            migrationBuilder.RenameColumn(
                name: "fk_usuario",
                table: "tb_contato",
                newName: "PkUsuario");

            migrationBuilder.AddPrimaryKey(
                name: "PK_tb_pedido_produto",
                table: "tb_pedido_produto",
                columns: new[] { "PkPedido", "PkProduto" });

            migrationBuilder.CreateIndex(
                name: "IX_tb_pedido_produto_PkProduto",
                table: "tb_pedido_produto",
                column: "PkProduto");

            migrationBuilder.CreateIndex(
                name: "IX_tb_pedido_PkUsuario",
                table: "tb_pedido",
                column: "PkUsuario");

            migrationBuilder.CreateIndex(
                name: "IX_tb_contato_PkUsuario",
                table: "tb_contato",
                column: "PkUsuario",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "fk_usuario",
                table: "tb_contato",
                column: "PkUsuario",
                principalTable: "tb_usuario",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_tb_endereco_tb_usuario_PkUsuario",
                table: "tb_endereco",
                column: "PkUsuario",
                principalTable: "tb_usuario",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

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

            migrationBuilder.AddForeignKey(
                name: "FK_tb_produto_tb_categoria_PkCategoria",
                table: "tb_produto",
                column: "PkCategoria",
                principalTable: "tb_categoria",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
