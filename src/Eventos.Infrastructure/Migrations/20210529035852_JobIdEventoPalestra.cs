using Microsoft.EntityFrameworkCore.Migrations;

namespace Eventos.Infrastructure.Migrations
{
    public partial class JobIdEventoPalestra : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "JobId",
                table: "Palestra",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "JobId",
                table: "Evento",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "JobId",
                table: "Palestra");

            migrationBuilder.DropColumn(
                name: "JobId",
                table: "Evento");
        }
    }
}
