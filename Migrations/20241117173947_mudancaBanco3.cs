using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Migrations
{
    /// <inheritdoc />
    public partial class mudancaBanco3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Funcionarios_Fazenda_FazendaId",
                table: "Funcionarios");

            migrationBuilder.DropTable(
                name: "UsoEquipamento");

            migrationBuilder.AlterColumn<int>(
                name: "FazendaId",
                table: "Equipamentos",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Funcionarios_Fazenda_FazendaId",
                table: "Funcionarios",
                column: "FazendaId",
                principalTable: "Fazenda",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Funcionarios_Fazenda_FazendaId",
                table: "Funcionarios");

            migrationBuilder.AlterColumn<int>(
                name: "FazendaId",
                table: "Equipamentos",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateTable(
                name: "UsoEquipamento",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EquipamentoId = table.Column<int>(type: "int", nullable: false),
                    FazendaId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UsoEquipamento", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UsoEquipamento_Equipamentos_EquipamentoId",
                        column: x => x.EquipamentoId,
                        principalTable: "Equipamentos",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_UsoEquipamento_Fazenda_FazendaId",
                        column: x => x.FazendaId,
                        principalTable: "Fazenda",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_UsoEquipamento_EquipamentoId",
                table: "UsoEquipamento",
                column: "EquipamentoId");

            migrationBuilder.CreateIndex(
                name: "IX_UsoEquipamento_FazendaId",
                table: "UsoEquipamento",
                column: "FazendaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Funcionarios_Fazenda_FazendaId",
                table: "Funcionarios",
                column: "FazendaId",
                principalTable: "Fazenda",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
