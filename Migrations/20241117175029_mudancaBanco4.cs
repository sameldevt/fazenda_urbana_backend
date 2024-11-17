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
            migrationBuilder.DropForeignKey(
                name: "FK_Colheitas_Culturas_CulturaId",
                table: "Colheitas");

            migrationBuilder.AddColumn<int>(
                name: "FazendaId",
                table: "Colheitas",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Colheitas_FazendaId",
                table: "Colheitas",
                column: "FazendaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Colheitas_Culturas_CulturaId",
                table: "Colheitas",
                column: "CulturaId",
                principalTable: "Culturas",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Colheitas_Fazenda_FazendaId",
                table: "Colheitas",
                column: "FazendaId",
                principalTable: "Fazenda",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Colheitas_Culturas_CulturaId",
                table: "Colheitas");

            migrationBuilder.DropForeignKey(
                name: "FK_Colheitas_Fazenda_FazendaId",
                table: "Colheitas");

            migrationBuilder.DropIndex(
                name: "IX_Colheitas_FazendaId",
                table: "Colheitas");

            migrationBuilder.DropColumn(
                name: "FazendaId",
                table: "Colheitas");

            migrationBuilder.AddForeignKey(
                name: "FK_Colheitas_Culturas_CulturaId",
                table: "Colheitas",
                column: "CulturaId",
                principalTable: "Culturas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
