using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Eventos.Infrastructure.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CategoriaPalestra",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Nome = table.Column<string>(type: "varchar(50)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CategoriaPalestra", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Evento",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Nome = table.Column<string>(type: "varchar(50)", nullable: false),
                    DataInicio = table.Column<DateTime>(nullable: false),
                    DataFim = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Evento", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Funcionario",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Nome = table.Column<string>(type: "varchar(50)", nullable: false),
                    Cpf = table.Column<string>(nullable: false),
                    DataNascimento = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Funcionario", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "EventoFuncionario",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    EventoId = table.Column<Guid>(nullable: false),
                    FuncionarioId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EventoFuncionario", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EventoFuncionario_Evento_EventoId",
                        column: x => x.EventoId,
                        principalTable: "Evento",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EventoFuncionario_Funcionario_FuncionarioId",
                        column: x => x.FuncionarioId,
                        principalTable: "Funcionario",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

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
                        name: "FK_Palestra_CategoriaPalestra_CategoriaId",
                        column: x => x.CategoriaId,
                        principalTable: "CategoriaPalestra",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
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
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Participante_Palestra_PalestraId",
                        column: x => x.PalestraId,
                        principalTable: "Palestra",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_EventoFuncionario_EventoId",
                table: "EventoFuncionario",
                column: "EventoId");

            migrationBuilder.CreateIndex(
                name: "IX_EventoFuncionario_FuncionarioId",
                table: "EventoFuncionario",
                column: "FuncionarioId");

            migrationBuilder.CreateIndex(
                name: "IX_Palestra_CategoriaId",
                table: "Palestra",
                column: "CategoriaId");

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
                name: "EventoFuncionario");

            migrationBuilder.DropTable(
                name: "Participante");

            migrationBuilder.DropTable(
                name: "Evento");

            migrationBuilder.DropTable(
                name: "Palestra");

            migrationBuilder.DropTable(
                name: "CategoriaPalestra");

            migrationBuilder.DropTable(
                name: "Funcionario");
        }
    }
}
