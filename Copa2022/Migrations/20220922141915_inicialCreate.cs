using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Copa2022.Migrations
{
    public partial class inicialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "clientes",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nome = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    cidade = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    estado = table.Column<int>(type: "int", nullable: false),
                    idade = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_clientes", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "figurinhas",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    descricao = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    venda = table.Column<float>(type: "real", nullable: false),
                    compra = table.Column<float>(type: "real", nullable: false),
                    pais = table.Column<int>(type: "int", nullable: false),
                    posicao = table.Column<int>(type: "int", nullable: false),
                    raridade = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_figurinhas", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "contas",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    clienteid = table.Column<int>(type: "int", nullable: true),
                    figurinhaid = table.Column<int>(type: "int", nullable: true),
                    quantidade = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_contas", x => x.id);
                    table.ForeignKey(
                        name: "FK_contas_clientes_clienteid",
                        column: x => x.clienteid,
                        principalTable: "clientes",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_contas_figurinhas_figurinhaid",
                        column: x => x.figurinhaid,
                        principalTable: "figurinhas",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "transacoes",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    contaid = table.Column<int>(type: "int", nullable: true),
                    data = table.Column<DateTime>(type: "datetime2", nullable: false),
                    quantidade = table.Column<float>(type: "real", nullable: false),
                    valor = table.Column<float>(type: "real", nullable: false),
                    operacao = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_transacoes", x => x.id);
                    table.ForeignKey(
                        name: "FK_transacoes_contas_contaid",
                        column: x => x.contaid,
                        principalTable: "contas",
                        principalColumn: "id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_contas_clienteid",
                table: "contas",
                column: "clienteid");

            migrationBuilder.CreateIndex(
                name: "IX_contas_figurinhaid",
                table: "contas",
                column: "figurinhaid");

            migrationBuilder.CreateIndex(
                name: "IX_transacoes_contaid",
                table: "transacoes",
                column: "contaid");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "transacoes");

            migrationBuilder.DropTable(
                name: "contas");

            migrationBuilder.DropTable(
                name: "clientes");

            migrationBuilder.DropTable(
                name: "figurinhas");
        }
    }
}
