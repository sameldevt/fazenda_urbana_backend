using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Migrations
{
    /// <inheritdoc />
    public partial class Migration4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Notas",
                table: "Pedidos",
                newName: "Observacoes");

            migrationBuilder.RenameColumn(
                name: "PreçoUnitario",
                table: "ItemPedido",
                newName: "PrecoUnitario");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Observacoes",
                table: "Pedidos",
                newName: "Notas");

            migrationBuilder.RenameColumn(
                name: "PrecoUnitario",
                table: "ItemPedido",
                newName: "PreçoUnitario");
        }
    }
}
