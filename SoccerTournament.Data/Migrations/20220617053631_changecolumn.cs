using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SoccerTournament.Data.Migrations
{
    public partial class changecolumn : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Emblem",
                table: "Games");

            migrationBuilder.AddColumn<string>(
                name: "Emblem",
                table: "Teams",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Emblem",
                table: "Teams");

            migrationBuilder.AddColumn<string>(
                name: "Emblem",
                table: "Games",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
