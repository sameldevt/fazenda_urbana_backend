using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Migrations
{
    /// <inheritdoc />
    public partial class Migration6 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Nome",
                table: "MensagensFaleConosco",
                newName: "NomeUsuario");

            migrationBuilder.RenameColumn(
                name: "Mensagem",
                table: "MensagensFaleConosco",
                newName: "Conteudo");

            migrationBuilder.RenameColumn(
                name: "Email",
                table: "MensagensFaleConosco",
                newName: "EmailUsuario");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "NomeUsuario",
                table: "MensagensFaleConosco",
                newName: "Nome");

            migrationBuilder.RenameColumn(
                name: "EmailUsuario",
                table: "MensagensFaleConosco",
                newName: "Email");

            migrationBuilder.RenameColumn(
                name: "Conteudo",
                table: "MensagensFaleConosco",
                newName: "Mensagem");
        }
    }
}
