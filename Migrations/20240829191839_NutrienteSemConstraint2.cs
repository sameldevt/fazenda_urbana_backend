using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace _.Migrations
{
    /// <inheritdoc />
    public partial class NutrienteSemConstraint2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tb_nutriente_tb_produto_FkProduto",
                table: "tb_nutriente");

            migrationBuilder.DropIndex(
                name: "IX_tb_nutriente_FkProduto",
                table: "tb_nutriente");

            migrationBuilder.DropColumn(
                name: "FkProduto",
                table: "tb_nutriente");

            migrationBuilder.AddColumn<int>(
                name: "NutrienteId",
                table: "tb_produto",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_tb_produto_NutrienteId",
                table: "tb_produto",
                column: "NutrienteId");

            migrationBuilder.AddForeignKey(
                name: "FK_tb_produto_tb_nutriente_NutrienteId",
                table: "tb_produto",
                column: "NutrienteId",
                principalTable: "tb_nutriente",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tb_produto_tb_nutriente_NutrienteId",
                table: "tb_produto");

            migrationBuilder.DropIndex(
                name: "IX_tb_produto_NutrienteId",
                table: "tb_produto");

            migrationBuilder.DropColumn(
                name: "NutrienteId",
                table: "tb_produto");

            migrationBuilder.AddColumn<int>(
                name: "FkProduto",
                table: "tb_nutriente",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_tb_nutriente_FkProduto",
                table: "tb_nutriente",
                column: "FkProduto",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_tb_nutriente_tb_produto_FkProduto",
                table: "tb_nutriente",
                column: "FkProduto",
                principalTable: "tb_produto",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
