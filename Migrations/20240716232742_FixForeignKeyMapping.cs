using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplication2.Migrations
{
    /// <inheritdoc />
    public partial class FixForeignKeyMapping : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Vendas_Clientes_ClienteIdCliente",
                table: "Vendas");

            migrationBuilder.DropForeignKey(
                name: "FK_Vendas_Produtos_ProdutoIdProduto",
                table: "Vendas");

            migrationBuilder.DropIndex(
                name: "IX_Vendas_ClienteIdCliente",
                table: "Vendas");

            migrationBuilder.DropIndex(
                name: "IX_Vendas_ProdutoIdProduto",
                table: "Vendas");

            migrationBuilder.DropColumn(
                name: "ClienteIdCliente",
                table: "Vendas");

            migrationBuilder.DropColumn(
                name: "ProdutoIdProduto",
                table: "Vendas");

            migrationBuilder.CreateIndex(
                name: "IX_Vendas_IdCliente",
                table: "Vendas",
                column: "IdCliente");

            migrationBuilder.CreateIndex(
                name: "IX_Vendas_IdProduto",
                table: "Vendas",
                column: "IdProduto");

            migrationBuilder.AddForeignKey(
                name: "FK_Vendas_Clientes_IdCliente",
                table: "Vendas",
                column: "IdCliente",
                principalTable: "Clientes",
                principalColumn: "IdCliente",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Vendas_Produtos_IdProduto",
                table: "Vendas",
                column: "IdProduto",
                principalTable: "Produtos",
                principalColumn: "IdProduto",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Vendas_Clientes_IdCliente",
                table: "Vendas");

            migrationBuilder.DropForeignKey(
                name: "FK_Vendas_Produtos_IdProduto",
                table: "Vendas");

            migrationBuilder.DropIndex(
                name: "IX_Vendas_IdCliente",
                table: "Vendas");

            migrationBuilder.DropIndex(
                name: "IX_Vendas_IdProduto",
                table: "Vendas");

            migrationBuilder.AddColumn<int>(
                name: "ClienteIdCliente",
                table: "Vendas",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ProdutoIdProduto",
                table: "Vendas",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Vendas_ClienteIdCliente",
                table: "Vendas",
                column: "ClienteIdCliente");

            migrationBuilder.CreateIndex(
                name: "IX_Vendas_ProdutoIdProduto",
                table: "Vendas",
                column: "ProdutoIdProduto");

            migrationBuilder.AddForeignKey(
                name: "FK_Vendas_Clientes_ClienteIdCliente",
                table: "Vendas",
                column: "ClienteIdCliente",
                principalTable: "Clientes",
                principalColumn: "IdCliente",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Vendas_Produtos_ProdutoIdProduto",
                table: "Vendas",
                column: "ProdutoIdProduto",
                principalTable: "Produtos",
                principalColumn: "IdProduto",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
