using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TesteZDZ.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class MigrationTeste3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Receitas",
                table: "Receitas");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Produtos",
                table: "Produtos");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Funcionarios",
                table: "Funcionarios");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Despesas",
                table: "Despesas");

            migrationBuilder.RenameTable(
                name: "Receitas",
                newName: "Revenues");

            migrationBuilder.RenameTable(
                name: "Produtos",
                newName: "Products");

            migrationBuilder.RenameTable(
                name: "Funcionarios",
                newName: "Employees");

            migrationBuilder.RenameTable(
                name: "Despesas",
                newName: "Expenses");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Revenues",
                table: "Revenues",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Products",
                table: "Products",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Employees",
                table: "Employees",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Expenses",
                table: "Expenses",
                column: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Revenues",
                table: "Revenues");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Products",
                table: "Products");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Expenses",
                table: "Expenses");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Employees",
                table: "Employees");

            migrationBuilder.RenameTable(
                name: "Revenues",
                newName: "Receitas");

            migrationBuilder.RenameTable(
                name: "Products",
                newName: "Produtos");

            migrationBuilder.RenameTable(
                name: "Expenses",
                newName: "Despesas");

            migrationBuilder.RenameTable(
                name: "Employees",
                newName: "Funcionarios");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Receitas",
                table: "Receitas",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Produtos",
                table: "Produtos",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Despesas",
                table: "Despesas",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Funcionarios",
                table: "Funcionarios",
                column: "Id");
        }
    }
}
