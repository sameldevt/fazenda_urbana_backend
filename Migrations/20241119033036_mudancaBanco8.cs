using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Migrations
{
    /// <inheritdoc />
    public partial class mudancaBanco8 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Colheitas_Culturas_CulturaId",
                table: "Colheitas");

            migrationBuilder.DropForeignKey(
                name: "FK_Culturas_Fazendas_FazendaId",
                table: "Culturas");

            migrationBuilder.DropForeignKey(
                name: "FK_Equipamentos_Fazendas_FazendaId",
                table: "Equipamentos");

            migrationBuilder.DropForeignKey(
                name: "FK_Equipamentos_Fornecedores_FornecedorId",
                table: "Equipamentos");

            migrationBuilder.DropForeignKey(
                name: "FK_Funcionarios_Fazendas_FazendaId",
                table: "Funcionarios");

            migrationBuilder.DropForeignKey(
                name: "FK_Insumos_Fornecedores_FornecedorId",
                table: "Insumos");

            migrationBuilder.DropForeignKey(
                name: "FK_ItemPedido_Pedidos_PedidoId",
                table: "ItemPedido");

            migrationBuilder.DropForeignKey(
                name: "FK_ItemPedido_Produtos_ProdutoId",
                table: "ItemPedido");

            migrationBuilder.DropForeignKey(
                name: "FK_Pedidos_Clientes_ClienteId",
                table: "Pedidos");

            migrationBuilder.DropForeignKey(
                name: "FK_Produtos_Categorias_CategoriaId",
                table: "Produtos");

            migrationBuilder.DropForeignKey(
                name: "FK_Produtos_InformacoesNutricionais_NutrientesId",
                table: "Produtos");

            migrationBuilder.AddForeignKey(
                name: "FK_Colheitas_Culturas_CulturaId",
                table: "Colheitas",
                column: "CulturaId",
                principalTable: "Culturas",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Culturas_Fazendas_FazendaId",
                table: "Culturas",
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
                name: "FK_Equipamentos_Fornecedores_FornecedorId",
                table: "Equipamentos",
                column: "FornecedorId",
                principalTable: "Fornecedores",
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
                name: "FK_ItemPedido_Pedidos_PedidoId",
                table: "ItemPedido",
                column: "PedidoId",
                principalTable: "Pedidos",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ItemPedido_Produtos_ProdutoId",
                table: "ItemPedido",
                column: "ProdutoId",
                principalTable: "Produtos",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Pedidos_Clientes_ClienteId",
                table: "Pedidos",
                column: "ClienteId",
                principalTable: "Clientes",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Produtos_Categorias_CategoriaId",
                table: "Produtos",
                column: "CategoriaId",
                principalTable: "Categorias",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Produtos_InformacoesNutricionais_NutrientesId",
                table: "Produtos",
                column: "NutrientesId",
                principalTable: "InformacoesNutricionais",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Colheitas_Culturas_CulturaId",
                table: "Colheitas");

            migrationBuilder.DropForeignKey(
                name: "FK_Culturas_Fazendas_FazendaId",
                table: "Culturas");

            migrationBuilder.DropForeignKey(
                name: "FK_Equipamentos_Fazendas_FazendaId",
                table: "Equipamentos");

            migrationBuilder.DropForeignKey(
                name: "FK_Equipamentos_Fornecedores_FornecedorId",
                table: "Equipamentos");

            migrationBuilder.DropForeignKey(
                name: "FK_Funcionarios_Fazendas_FazendaId",
                table: "Funcionarios");

            migrationBuilder.DropForeignKey(
                name: "FK_Insumos_Fornecedores_FornecedorId",
                table: "Insumos");

            migrationBuilder.DropForeignKey(
                name: "FK_ItemPedido_Pedidos_PedidoId",
                table: "ItemPedido");

            migrationBuilder.DropForeignKey(
                name: "FK_ItemPedido_Produtos_ProdutoId",
                table: "ItemPedido");

            migrationBuilder.DropForeignKey(
                name: "FK_Pedidos_Clientes_ClienteId",
                table: "Pedidos");

            migrationBuilder.DropForeignKey(
                name: "FK_Produtos_Categorias_CategoriaId",
                table: "Produtos");

            migrationBuilder.DropForeignKey(
                name: "FK_Produtos_InformacoesNutricionais_NutrientesId",
                table: "Produtos");

            migrationBuilder.AddForeignKey(
                name: "FK_Colheitas_Culturas_CulturaId",
                table: "Colheitas",
                column: "CulturaId",
                principalTable: "Culturas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Culturas_Fazendas_FazendaId",
                table: "Culturas",
                column: "FazendaId",
                principalTable: "Fazendas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Equipamentos_Fazendas_FazendaId",
                table: "Equipamentos",
                column: "FazendaId",
                principalTable: "Fazendas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Equipamentos_Fornecedores_FornecedorId",
                table: "Equipamentos",
                column: "FornecedorId",
                principalTable: "Fornecedores",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Funcionarios_Fazendas_FazendaId",
                table: "Funcionarios",
                column: "FazendaId",
                principalTable: "Fazendas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Insumos_Fornecedores_FornecedorId",
                table: "Insumos",
                column: "FornecedorId",
                principalTable: "Fornecedores",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ItemPedido_Pedidos_PedidoId",
                table: "ItemPedido",
                column: "PedidoId",
                principalTable: "Pedidos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ItemPedido_Produtos_ProdutoId",
                table: "ItemPedido",
                column: "ProdutoId",
                principalTable: "Produtos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Pedidos_Clientes_ClienteId",
                table: "Pedidos",
                column: "ClienteId",
                principalTable: "Clientes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Produtos_Categorias_CategoriaId",
                table: "Produtos",
                column: "CategoriaId",
                principalTable: "Categorias",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Produtos_InformacoesNutricionais_NutrientesId",
                table: "Produtos",
                column: "NutrientesId",
                principalTable: "InformacoesNutricionais",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
