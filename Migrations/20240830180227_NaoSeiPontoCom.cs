using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace _.Migrations
{
    /// <inheritdoc />
    public partial class NaoSeiPontoCom : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PkContato",
                table: "tb_usuario");

            migrationBuilder.DropColumn(
                name: "PkEndereco",
                table: "tb_usuario");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PkContato",
                table: "tb_usuario",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "PkEndereco",
                table: "tb_usuario",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }
    }
}
