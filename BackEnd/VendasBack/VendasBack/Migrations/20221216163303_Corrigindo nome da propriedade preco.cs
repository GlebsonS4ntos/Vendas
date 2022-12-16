using Microsoft.EntityFrameworkCore.Migrations;

namespace VendasBack.Migrations
{
    public partial class Corrigindonomedapropriedadepreco : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Preço",
                table: "Produtos",
                newName: "Preco");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Preco",
                table: "Produtos",
                newName: "Preço");
        }
    }
}
