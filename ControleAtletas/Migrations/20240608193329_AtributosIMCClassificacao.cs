using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ControleAtletas.Migrations
{
    public partial class AtributosIMCClassificacao : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Classificacao",
                table: "Atleta",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<double>(
                name: "IMC",
                table: "Atleta",
                type: "float",
                nullable: false,
                defaultValue: 0.0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Classificacao",
                table: "Atleta");

            migrationBuilder.DropColumn(
                name: "IMC",
                table: "Atleta");
        }
    }
}
