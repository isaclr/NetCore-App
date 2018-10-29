using Microsoft.EntityFrameworkCore.Migrations;

namespace NetCore.Dados.Migrations
{
    public partial class AlteracaoCampoCNPJ : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "CPFCNPJ",
                table: "Clientes",
                newName: "CNPJ");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "CNPJ",
                table: "Clientes",
                newName: "CPFCNPJ");
        }
    }
}
