using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Copa2022.Migrations
{
    public partial class Anotacoes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_contas_clientes_clienteid",
                table: "contas");

            migrationBuilder.DropForeignKey(
                name: "FK_contas_figurinhas_figurinhaid",
                table: "contas");

            migrationBuilder.DropForeignKey(
                name: "FK_transacoes_contas_contaid",
                table: "transacoes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_transacoes",
                table: "transacoes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_figurinhas",
                table: "figurinhas");

            migrationBuilder.DropPrimaryKey(
                name: "PK_contas",
                table: "contas");

            migrationBuilder.DropPrimaryKey(
                name: "PK_clientes",
                table: "clientes");

            migrationBuilder.DropColumn(
                name: "descricao",
                table: "figurinhas");

            migrationBuilder.RenameTable(
                name: "transacoes",
                newName: "Transacoes");

            migrationBuilder.RenameTable(
                name: "figurinhas",
                newName: "Figurinhas");

            migrationBuilder.RenameTable(
                name: "contas",
                newName: "Contas");

            migrationBuilder.RenameTable(
                name: "clientes",
                newName: "Clientes");

            migrationBuilder.RenameIndex(
                name: "IX_transacoes_contaid",
                table: "Transacoes",
                newName: "IX_Transacoes_contaid");

            migrationBuilder.RenameIndex(
                name: "IX_contas_figurinhaid",
                table: "Contas",
                newName: "IX_Contas_figurinhaid");

            migrationBuilder.RenameIndex(
                name: "IX_contas_clienteid",
                table: "Contas",
                newName: "IX_Contas_clienteid");

            migrationBuilder.AlterColumn<int>(
                name: "contaid",
                table: "Transacoes",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "figurinhaid",
                table: "Contas",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "clienteid",
                table: "Contas",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "nome",
                table: "Clientes",
                type: "nvarchar(40)",
                maxLength: 40,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "cidade",
                table: "Clientes",
                type: "nvarchar(25)",
                maxLength: 25,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Transacoes",
                table: "Transacoes",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Figurinhas",
                table: "Figurinhas",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Contas",
                table: "Contas",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Clientes",
                table: "Clientes",
                column: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_Contas_Clientes_clienteid",
                table: "Contas",
                column: "clienteid",
                principalTable: "Clientes",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Contas_Figurinhas_figurinhaid",
                table: "Contas",
                column: "figurinhaid",
                principalTable: "Figurinhas",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Transacoes_Contas_contaid",
                table: "Transacoes",
                column: "contaid",
                principalTable: "Contas",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Contas_Clientes_clienteid",
                table: "Contas");

            migrationBuilder.DropForeignKey(
                name: "FK_Contas_Figurinhas_figurinhaid",
                table: "Contas");

            migrationBuilder.DropForeignKey(
                name: "FK_Transacoes_Contas_contaid",
                table: "Transacoes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Transacoes",
                table: "Transacoes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Figurinhas",
                table: "Figurinhas");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Contas",
                table: "Contas");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Clientes",
                table: "Clientes");

            migrationBuilder.RenameTable(
                name: "Transacoes",
                newName: "transacoes");

            migrationBuilder.RenameTable(
                name: "Figurinhas",
                newName: "figurinhas");

            migrationBuilder.RenameTable(
                name: "Contas",
                newName: "contas");

            migrationBuilder.RenameTable(
                name: "Clientes",
                newName: "clientes");

            migrationBuilder.RenameIndex(
                name: "IX_Transacoes_contaid",
                table: "transacoes",
                newName: "IX_transacoes_contaid");

            migrationBuilder.RenameIndex(
                name: "IX_Contas_figurinhaid",
                table: "contas",
                newName: "IX_contas_figurinhaid");

            migrationBuilder.RenameIndex(
                name: "IX_Contas_clienteid",
                table: "contas",
                newName: "IX_contas_clienteid");

            migrationBuilder.AlterColumn<int>(
                name: "contaid",
                table: "transacoes",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<string>(
                name: "descricao",
                table: "figurinhas",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "figurinhaid",
                table: "contas",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "clienteid",
                table: "contas",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "nome",
                table: "clientes",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(40)",
                oldMaxLength: 40);

            migrationBuilder.AlterColumn<string>(
                name: "cidade",
                table: "clientes",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(25)",
                oldMaxLength: 25);

            migrationBuilder.AddPrimaryKey(
                name: "PK_transacoes",
                table: "transacoes",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_figurinhas",
                table: "figurinhas",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_contas",
                table: "contas",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_clientes",
                table: "clientes",
                column: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_contas_clientes_clienteid",
                table: "contas",
                column: "clienteid",
                principalTable: "clientes",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_contas_figurinhas_figurinhaid",
                table: "contas",
                column: "figurinhaid",
                principalTable: "figurinhas",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_transacoes_contas_contaid",
                table: "transacoes",
                column: "contaid",
                principalTable: "contas",
                principalColumn: "id");
        }
    }
}
