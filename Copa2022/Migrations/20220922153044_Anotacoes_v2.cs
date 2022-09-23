using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Copa2022.Migrations
{
    public partial class Anotacoes_v2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "jogador",
                table: "Figurinhas",
                type: "nvarchar(40)",
                maxLength: 40,
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "jogador",
                table: "Figurinhas");
        }
    }
}
