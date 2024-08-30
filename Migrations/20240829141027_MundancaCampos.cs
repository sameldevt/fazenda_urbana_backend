using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace _.Migrations
{
    /// <inheritdoc />
    public partial class MundancaCampos : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tb_contato_tb_usuario_UsuarioId",
                table: "tb_contato");

            migrationBuilder.DropForeignKey(
                name: "FK_tb_endereco_tb_usuario_UsuarioId",
                table: "tb_endereco");

            migrationBuilder.DropForeignKey(
                name: "FK_tb_pedido_tb_usuario_UsuarioId",
                table: "tb_pedido");

            migrationBuilder.DropForeignKey(
                name: "FK_tb_pedido_produto_tb_pedido_PedidoId",
                table: "tb_pedido_produto");

            migrationBuilder.DropForeignKey(
                name: "FK_tb_pedido_produto_tb_produto_ProdutoId",
                table: "tb_pedido_produto");

            migrationBuilder.DropForeignKey(
                name: "FK_tb_produto_tb_categoria_CategoriaId",
                table: "tb_produto");

            migrationBuilder.DropPrimaryKey(
                name: "PK_tb_endereco",
                table: "tb_endereco");

            migrationBuilder.DropPrimaryKey(
                name: "PK_tb_contato",
                table: "tb_contato");

            migrationBuilder.RenameColumn(
                name: "CategoriaId",
                table: "tb_produto",
                newName: "PkCategoria");

            migrationBuilder.RenameIndex(
                name: "IX_tb_produto_CategoriaId",
                table: "tb_produto",
                newName: "IX_tb_produto_PkCategoria");

            migrationBuilder.RenameColumn(
                name: "UsuarioId",
                table: "tb_endereco",
                newName: "PkUsuario");

            migrationBuilder.RenameColumn(
                name: "UsuarioId",
                table: "tb_contato",
                newName: "PkUsuario");

            migrationBuilder.AddColumn<string>(
                name: "Descricao",
                table: "tb_produto",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "tb_endereco",
                type: "integer",
                nullable: false,
                defaultValue: 0)
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "tb_contato",
                type: "integer",
                nullable: false,
                defaultValue: 0)
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AddPrimaryKey(
                name: "PK_tb_endereco",
                table: "tb_endereco",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_tb_contato",
                table: "tb_contato",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_tb_endereco_PkUsuario",
                table: "tb_endereco",
                column: "PkUsuario",
                unique: true);

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

            migrationBuilder.AddForeignKey(
                name: "FK_tb_produto_tb_categoria_PkCategoria",
                table: "tb_produto",
                column: "PkCategoria",
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
                name: "FK_tb_endereco_tb_usuario_PkUsuario",
                table: "tb_endereco");

            migrationBuilder.DropForeignKey(
                name: "FK_tb_pedido_tb_usuario_UsuarioId",
                table: "tb_pedido");

            migrationBuilder.DropForeignKey(
                name: "FK_tb_pedido_produto_tb_pedido_PedidoId",
                table: "tb_pedido_produto");

            migrationBuilder.DropForeignKey(
                name: "FK_tb_pedido_produto_tb_produto_ProdutoId",
                table: "tb_pedido_produto");

            migrationBuilder.DropForeignKey(
                name: "FK_tb_produto_tb_categoria_PkCategoria",
                table: "tb_produto");

            migrationBuilder.DropPrimaryKey(
                name: "PK_tb_endereco",
                table: "tb_endereco");

            migrationBuilder.DropIndex(
                name: "IX_tb_endereco_PkUsuario",
                table: "tb_endereco");

            migrationBuilder.DropPrimaryKey(
                name: "PK_tb_contato",
                table: "tb_contato");

            migrationBuilder.DropIndex(
                name: "IX_tb_contato_PkUsuario",
                table: "tb_contato");

            migrationBuilder.DropColumn(
                name: "Descricao",
                table: "tb_produto");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "tb_endereco");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "tb_contato");

            migrationBuilder.RenameColumn(
                name: "PkCategoria",
                table: "tb_produto",
                newName: "CategoriaId");

            migrationBuilder.RenameIndex(
                name: "IX_tb_produto_PkCategoria",
                table: "tb_produto",
                newName: "IX_tb_produto_CategoriaId");

            migrationBuilder.RenameColumn(
                name: "PkUsuario",
                table: "tb_endereco",
                newName: "UsuarioId");

            migrationBuilder.RenameColumn(
                name: "PkUsuario",
                table: "tb_contato",
                newName: "UsuarioId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_tb_endereco",
                table: "tb_endereco",
                column: "UsuarioId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_tb_contato",
                table: "tb_contato",
                column: "UsuarioId");

            migrationBuilder.AddForeignKey(
                name: "FK_tb_contato_tb_usuario_UsuarioId",
                table: "tb_contato",
                column: "UsuarioId",
                principalTable: "tb_usuario",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_tb_endereco_tb_usuario_UsuarioId",
                table: "tb_endereco",
                column: "UsuarioId",
                principalTable: "tb_usuario",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_tb_pedido_tb_usuario_UsuarioId",
                table: "tb_pedido",
                column: "UsuarioId",
                principalTable: "tb_usuario",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_tb_pedido_produto_tb_pedido_PedidoId",
                table: "tb_pedido_produto",
                column: "PedidoId",
                principalTable: "tb_pedido",
                principalColumn: "PedidoId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_tb_pedido_produto_tb_produto_ProdutoId",
                table: "tb_pedido_produto",
                column: "ProdutoId",
                principalTable: "tb_produto",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_tb_produto_tb_categoria_CategoriaId",
                table: "tb_produto",
                column: "CategoriaId",
                principalTable: "tb_categoria",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
