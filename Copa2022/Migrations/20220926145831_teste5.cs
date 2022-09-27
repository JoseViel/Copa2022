using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Copa2022.Migrations
{
    public partial class teste5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Transacoes_Contas_contaid",
                table: "Transacoes");

            migrationBuilder.RenameColumn(
                name: "contaid",
                table: "Transacoes",
                newName: "Contaid");

            migrationBuilder.RenameIndex(
                name: "IX_Transacoes_contaid",
                table: "Transacoes",
                newName: "IX_Transacoes_Contaid");

            migrationBuilder.AlterColumn<int>(
                name: "Contaid",
                table: "Transacoes",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "clienteid",
                table: "Transacoes",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Transacoes_clienteid",
                table: "Transacoes",
                column: "clienteid");

            migrationBuilder.AddForeignKey(
                name: "FK_Transacoes_Clientes_clienteid",
                table: "Transacoes",
                column: "clienteid",
                principalTable: "Clientes",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Transacoes_Contas_Contaid",
                table: "Transacoes",
                column: "Contaid",
                principalTable: "Contas",
                principalColumn: "id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Transacoes_Clientes_clienteid",
                table: "Transacoes");

            migrationBuilder.DropForeignKey(
                name: "FK_Transacoes_Contas_Contaid",
                table: "Transacoes");

            migrationBuilder.DropIndex(
                name: "IX_Transacoes_clienteid",
                table: "Transacoes");

            migrationBuilder.DropColumn(
                name: "clienteid",
                table: "Transacoes");

            migrationBuilder.RenameColumn(
                name: "Contaid",
                table: "Transacoes",
                newName: "contaid");

            migrationBuilder.RenameIndex(
                name: "IX_Transacoes_Contaid",
                table: "Transacoes",
                newName: "IX_Transacoes_contaid");

            migrationBuilder.AlterColumn<int>(
                name: "contaid",
                table: "Transacoes",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Transacoes_Contas_contaid",
                table: "Transacoes",
                column: "contaid",
                principalTable: "Contas",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
