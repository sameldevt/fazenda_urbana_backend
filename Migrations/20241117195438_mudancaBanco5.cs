using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Migrations
{
    /// <inheritdoc />
    public partial class mudancaBanco5 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Colheitas_Fazenda_FazendaId",
                table: "Colheitas");

            migrationBuilder.DropForeignKey(
                name: "FK_Equipamentos_Fazenda_FazendaId",
                table: "Equipamentos");

            migrationBuilder.DropForeignKey(
                name: "FK_Funcionarios_Fazenda_FazendaId",
                table: "Funcionarios");

            migrationBuilder.DropForeignKey(
                name: "FK_Insumo_Fornecedores_FornecedorId",
                table: "Insumo");

            migrationBuilder.DropForeignKey(
                name: "FK_UsoInsumo_Insumo_InsumoId",
                table: "UsoInsumo");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Insumo",
                table: "Insumo");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Fazenda",
                table: "Fazenda");

            migrationBuilder.RenameTable(
                name: "Insumo",
                newName: "Insumos");

            migrationBuilder.RenameTable(
                name: "Fazenda",
                newName: "Fazendas");

            migrationBuilder.RenameIndex(
                name: "IX_Insumo_FornecedorId",
                table: "Insumos",
                newName: "IX_Insumos_FornecedorId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Insumos",
                table: "Insumos",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Fazendas",
                table: "Fazendas",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Colheitas_Fazendas_FazendaId",
                table: "Colheitas",
                column: "FazendaId",
                principalTable: "Fazendas",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Equipamentos_Fazendas_FazendaId",
                table: "Equipamentos",
                column: "FazendaId",
                principalTable: "Fazendas",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Funcionarios_Fazendas_FazendaId",
                table: "Funcionarios",
                column: "FazendaId",
                principalTable: "Fazendas",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Insumos_Fornecedores_FornecedorId",
                table: "Insumos",
                column: "FornecedorId",
                principalTable: "Fornecedores",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_UsoInsumo_Insumos_InsumoId",
                table: "UsoInsumo",
                column: "InsumoId",
                principalTable: "Insumos",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Colheitas_Fazendas_FazendaId",
                table: "Colheitas");

            migrationBuilder.DropForeignKey(
                name: "FK_Equipamentos_Fazendas_FazendaId",
                table: "Equipamentos");

            migrationBuilder.DropForeignKey(
                name: "FK_Funcionarios_Fazendas_FazendaId",
                table: "Funcionarios");

            migrationBuilder.DropForeignKey(
                name: "FK_Insumos_Fornecedores_FornecedorId",
                table: "Insumos");

            migrationBuilder.DropForeignKey(
                name: "FK_UsoInsumo_Insumos_InsumoId",
                table: "UsoInsumo");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Insumos",
                table: "Insumos");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Fazendas",
                table: "Fazendas");

            migrationBuilder.RenameTable(
                name: "Insumos",
                newName: "Insumo");

            migrationBuilder.RenameTable(
                name: "Fazendas",
                newName: "Fazenda");

            migrationBuilder.RenameIndex(
                name: "IX_Insumos_FornecedorId",
                table: "Insumo",
                newName: "IX_Insumo_FornecedorId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Insumo",
                table: "Insumo",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Fazenda",
                table: "Fazenda",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Colheitas_Fazenda_FazendaId",
                table: "Colheitas",
                column: "FazendaId",
                principalTable: "Fazenda",
                principalColumn: "Id");

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
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Insumo_Fornecedores_FornecedorId",
                table: "Insumo",
                column: "FornecedorId",
                principalTable: "Fornecedores",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_UsoInsumo_Insumo_InsumoId",
                table: "UsoInsumo",
                column: "InsumoId",
                principalTable: "Insumo",
                principalColumn: "Id");
        }
    }
}
