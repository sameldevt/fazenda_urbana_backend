using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Migrations
{
    /// <inheritdoc />
    public partial class mudancaBanco4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ProdutoId",
                table: "Culturas",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Culturas_ProdutoId",
                table: "Culturas",
                column: "ProdutoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Culturas_Produtos_ProdutoId",
                table: "Culturas",
                column: "ProdutoId",
                principalTable: "Produtos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Culturas_Produtos_ProdutoId",
                table: "Culturas");

            migrationBuilder.DropIndex(
                name: "IX_Culturas_ProdutoId",
                table: "Culturas");

            migrationBuilder.DropColumn(
                name: "ProdutoId",
                table: "Culturas");
        }
    }
}
