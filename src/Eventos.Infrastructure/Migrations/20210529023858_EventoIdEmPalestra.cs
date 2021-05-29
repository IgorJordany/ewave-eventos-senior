using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Eventos.Infrastructure.Migrations
{
    public partial class EventoIdEmPalestra : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "EventoId",
                table: "Palestra",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_Palestra_EventoId",
                table: "Palestra",
                column: "EventoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Palestra_Evento_EventoId",
                table: "Palestra",
                column: "EventoId",
                principalTable: "Evento",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Palestra_Evento_EventoId",
                table: "Palestra");

            migrationBuilder.DropIndex(
                name: "IX_Palestra_EventoId",
                table: "Palestra");

            migrationBuilder.DropColumn(
                name: "EventoId",
                table: "Palestra");
        }
    }
}
