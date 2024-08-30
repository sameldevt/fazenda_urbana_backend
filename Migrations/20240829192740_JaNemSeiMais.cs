using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace _.Migrations
{
    /// <inheritdoc />
    public partial class JaNemSeiMais : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.CreateIndex(
                name: "IX_tb_produto_FkNutriente",
                table: "tb_produto",
                column: "FkNutriente",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_tb_produto_tb_nutriente_FkNutriente",
                table: "tb_produto",
                column: "FkNutriente",
                principalTable: "tb_nutriente",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tb_produto_tb_nutriente_FkNutriente",
                table: "tb_produto");

            migrationBuilder.DropIndex(
                name: "IX_tb_produto_FkNutriente",
                table: "tb_produto");

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
    }
}
