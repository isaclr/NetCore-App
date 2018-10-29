using Microsoft.EntityFrameworkCore.Migrations;

namespace NetCore.Dados.Migrations
{
    public partial class NumeroNullable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Numero",
                table: "Clientes",
                nullable: true,
                oldClrType: typeof(int));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Numero",
                table: "Clientes",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);
        }
    }
}
