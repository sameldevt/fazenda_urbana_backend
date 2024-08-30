using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace _.Migrations
{
    /// <inheritdoc />
    public partial class MudancaFks3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tb_produto_tb_categoria_CategoriaId",
                table: "tb_produto");

            migrationBuilder.RenameColumn(
                name: "CategoriaId",
                table: "tb_produto",
                newName: "FkCategoria");

            migrationBuilder.RenameIndex(
                name: "IX_tb_produto_CategoriaId",
                table: "tb_produto",
                newName: "IX_tb_produto_FkCategoria");

            migrationBuilder.AddForeignKey(
                name: "fk_categoria",
                table: "tb_produto",
                column: "FkCategoria",
                principalTable: "tb_categoria",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_categoria",
                table: "tb_produto");

            migrationBuilder.RenameColumn(
                name: "FkCategoria",
                table: "tb_produto",
                newName: "CategoriaId");

            migrationBuilder.RenameIndex(
                name: "IX_tb_produto_FkCategoria",
                table: "tb_produto",
                newName: "IX_tb_produto_CategoriaId");

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
