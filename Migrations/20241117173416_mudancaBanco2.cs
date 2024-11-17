using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Migrations
{
    /// <inheritdoc />
    public partial class mudancaBanco2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "FazendaId",
                table: "Funcionarios",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "FazendaId",
                table: "Equipamentos",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Fazenda",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Localizacao = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Area = table.Column<double>(type: "float", nullable: false),
                    DataFundacao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    NumeroEstufas = table.Column<int>(type: "int", nullable: false),
                    Ativo = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Fazenda", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UsoInsumo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CulturaId = table.Column<int>(type: "int", nullable: false),
                    InsumoId = table.Column<int>(type: "int", nullable: false),
                    Quantidade = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UsoInsumo", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UsoInsumo_Culturas_CulturaId",
                        column: x => x.CulturaId,
                        principalTable: "Culturas",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_UsoInsumo_Insumo_InsumoId",
                        column: x => x.InsumoId,
                        principalTable: "Insumo",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "UsoEquipamento",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FazendaId = table.Column<int>(type: "int", nullable: false),
                    EquipamentoId = table.Column<int>(type: "int", nullable: false)
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
                name: "IX_Funcionarios_FazendaId",
                table: "Funcionarios",
                column: "FazendaId");

            migrationBuilder.CreateIndex(
                name: "IX_Equipamentos_FazendaId",
                table: "Equipamentos",
                column: "FazendaId");

            migrationBuilder.CreateIndex(
                name: "IX_UsoEquipamento_EquipamentoId",
                table: "UsoEquipamento",
                column: "EquipamentoId");

            migrationBuilder.CreateIndex(
                name: "IX_UsoEquipamento_FazendaId",
                table: "UsoEquipamento",
                column: "FazendaId");

            migrationBuilder.CreateIndex(
                name: "IX_UsoInsumo_CulturaId",
                table: "UsoInsumo",
                column: "CulturaId");

            migrationBuilder.CreateIndex(
                name: "IX_UsoInsumo_InsumoId",
                table: "UsoInsumo",
                column: "InsumoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Equipamentos_Fazenda_FazendaId",
                table: "Equipamentos",
                column: "FazendaId",
                principalTable: "Fazenda",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Funcionarios_Fazenda_FazendaId",
                table: "Funcionarios",
                column: "FazendaId",
                principalTable: "Fazenda",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Equipamentos_Fazenda_FazendaId",
                table: "Equipamentos");

            migrationBuilder.DropForeignKey(
                name: "FK_Funcionarios_Fazenda_FazendaId",
                table: "Funcionarios");

            migrationBuilder.DropTable(
                name: "UsoEquipamento");

            migrationBuilder.DropTable(
                name: "UsoInsumo");

            migrationBuilder.DropTable(
                name: "Fazenda");

            migrationBuilder.DropIndex(
                name: "IX_Funcionarios_FazendaId",
                table: "Funcionarios");

            migrationBuilder.DropIndex(
                name: "IX_Equipamentos_FazendaId",
                table: "Equipamentos");

            migrationBuilder.DropColumn(
                name: "FazendaId",
                table: "Funcionarios");

            migrationBuilder.DropColumn(
                name: "FazendaId",
                table: "Equipamentos");
        }
    }
}
