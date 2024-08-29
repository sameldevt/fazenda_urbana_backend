using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace _.Migrations
{
    /// <inheritdoc />
    public partial class MudancaNomesTabelas : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Contato_Usuario_UsuarioId",
                table: "Contato");

            migrationBuilder.DropForeignKey(
                name: "FK_Endereco_Usuario_UsuarioId",
                table: "Endereco");

            migrationBuilder.DropForeignKey(
                name: "FK_Produto_Categoria_CategoriaId",
                table: "Produto");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Usuario",
                table: "Usuario");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Produto",
                table: "Produto");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Mensagen",
                table: "Mensagen");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Endereco",
                table: "Endereco");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Contato",
                table: "Contato");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Categoria",
                table: "Categoria");

            migrationBuilder.RenameTable(
                name: "Usuario",
                newName: "tb_usuario");

            migrationBuilder.RenameTable(
                name: "Produto",
                newName: "tb_produto");

            migrationBuilder.RenameTable(
                name: "Mensagen",
                newName: "tb_contato_mensagem");

            migrationBuilder.RenameTable(
                name: "Endereco",
                newName: "tb_endereco");

            migrationBuilder.RenameTable(
                name: "Contato",
                newName: "tb_contato");

            migrationBuilder.RenameTable(
                name: "Categoria",
                newName: "tb_categoria");

            migrationBuilder.RenameIndex(
                name: "IX_Produto_CategoriaId",
                table: "tb_produto",
                newName: "IX_tb_produto_CategoriaId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_tb_usuario",
                table: "tb_usuario",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_tb_produto",
                table: "tb_produto",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_tb_contato_mensagem",
                table: "tb_contato_mensagem",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_tb_endereco",
                table: "tb_endereco",
                column: "UsuarioId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_tb_contato",
                table: "tb_contato",
                column: "UsuarioId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_tb_categoria",
                table: "tb_categoria",
                column: "Id");

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
                name: "FK_tb_contato_tb_usuario_UsuarioId",
                table: "tb_contato");

            migrationBuilder.DropForeignKey(
                name: "FK_tb_endereco_tb_usuario_UsuarioId",
                table: "tb_endereco");

            migrationBuilder.DropForeignKey(
                name: "FK_tb_produto_tb_categoria_CategoriaId",
                table: "tb_produto");

            migrationBuilder.DropPrimaryKey(
                name: "PK_tb_usuario",
                table: "tb_usuario");

            migrationBuilder.DropPrimaryKey(
                name: "PK_tb_produto",
                table: "tb_produto");

            migrationBuilder.DropPrimaryKey(
                name: "PK_tb_endereco",
                table: "tb_endereco");

            migrationBuilder.DropPrimaryKey(
                name: "PK_tb_contato_mensagem",
                table: "tb_contato_mensagem");

            migrationBuilder.DropPrimaryKey(
                name: "PK_tb_contato",
                table: "tb_contato");

            migrationBuilder.DropPrimaryKey(
                name: "PK_tb_categoria",
                table: "tb_categoria");

            migrationBuilder.RenameTable(
                name: "tb_usuario",
                newName: "Usuario");

            migrationBuilder.RenameTable(
                name: "tb_produto",
                newName: "Produto");

            migrationBuilder.RenameTable(
                name: "tb_endereco",
                newName: "Endereco");

            migrationBuilder.RenameTable(
                name: "tb_contato_mensagem",
                newName: "Mensagen");

            migrationBuilder.RenameTable(
                name: "tb_contato",
                newName: "Contato");

            migrationBuilder.RenameTable(
                name: "tb_categoria",
                newName: "Categoria");

            migrationBuilder.RenameIndex(
                name: "IX_tb_produto_CategoriaId",
                table: "Produto",
                newName: "IX_Produto_CategoriaId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Usuario",
                table: "Usuario",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Produto",
                table: "Produto",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Endereco",
                table: "Endereco",
                column: "UsuarioId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Mensagen",
                table: "Mensagen",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Contato",
                table: "Contato",
                column: "UsuarioId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Categoria",
                table: "Categoria",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Contato_Usuario_UsuarioId",
                table: "Contato",
                column: "UsuarioId",
                principalTable: "Usuario",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Endereco_Usuario_UsuarioId",
                table: "Endereco",
                column: "UsuarioId",
                principalTable: "Usuario",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Produto_Categoria_CategoriaId",
                table: "Produto",
                column: "CategoriaId",
                principalTable: "Categoria",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
