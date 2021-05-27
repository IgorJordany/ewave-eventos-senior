using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Eventos.Infrastructure.Migrations
{
    public partial class palestraMaping : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Palestra",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CategoriaId = table.Column<Guid>(nullable: false),
                    Tema = table.Column<string>(type: "varchar(50)", nullable: false),
                    Local = table.Column<string>(type: "varchar(50)", nullable: false),
                    DataInicio = table.Column<DateTime>(nullable: false),
                    Duracao = table.Column<float>(nullable: false),
                    PalestranteId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Palestra", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Palestra_Funcionario_PalestranteId",
                        column: x => x.PalestranteId,
                        principalTable: "Funcionario",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Participante",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    PalestraId = table.Column<Guid>(nullable: false),
                    FuncionarioId = table.Column<Guid>(nullable: false),
                    Confirmou = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Participante", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Participante_Funcionario_FuncionarioId",
                        column: x => x.FuncionarioId,
                        principalTable: "Funcionario",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Participante_Palestra_PalestraId",
                        column: x => x.PalestraId,
                        principalTable: "Palestra",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Palestra_PalestranteId",
                table: "Palestra",
                column: "PalestranteId");

            migrationBuilder.CreateIndex(
                name: "IX_Participante_FuncionarioId",
                table: "Participante",
                column: "FuncionarioId");

            migrationBuilder.CreateIndex(
                name: "IX_Participante_PalestraId",
                table: "Participante",
                column: "PalestraId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Participante");

            migrationBuilder.DropTable(
                name: "Palestra");
        }
    }
}
