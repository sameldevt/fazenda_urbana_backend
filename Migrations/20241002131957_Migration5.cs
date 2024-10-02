using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Migrations
{
    /// <inheritdoc />
    public partial class Migration5 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Subtotal",
                table: "ItemPedido",
                newName: "SubTotal");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "SubTotal",
                table: "ItemPedido",
                newName: "Subtotal");
        }
    }
}
