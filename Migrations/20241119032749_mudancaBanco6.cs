using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Migrations
{
    /// <inheritdoc />
    public partial class mudancaBanco6 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Culturas_Produtos_ProdutoId",
                table: "Culturas");

            migrationBuilder.AddForeignKey(
                name: "FK_Culturas_Produtos_ProdutoId",
                table: "Culturas",
                column: "ProdutoId",
                principalTable: "Produtos",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Culturas_Produtos_ProdutoId",
                table: "Culturas");

            migrationBuilder.AddForeignKey(
                name: "FK_Culturas_Produtos_ProdutoId",
                table: "Culturas",
                column: "ProdutoId",
                principalTable: "Produtos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
