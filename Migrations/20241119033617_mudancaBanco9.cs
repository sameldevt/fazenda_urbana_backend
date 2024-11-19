using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Migrations
{
    /// <inheritdoc />
    public partial class mudancaBanco9 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Colheitas_Produtos_ProdutoId",
                table: "Colheitas");

            migrationBuilder.AddForeignKey(
                name: "FK_Colheitas_Produtos_ProdutoId",
                table: "Colheitas",
                column: "ProdutoId",
                principalTable: "Produtos",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Colheitas_Produtos_ProdutoId",
                table: "Colheitas");

            migrationBuilder.AddForeignKey(
                name: "FK_Colheitas_Produtos_ProdutoId",
                table: "Colheitas",
                column: "ProdutoId",
                principalTable: "Produtos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
