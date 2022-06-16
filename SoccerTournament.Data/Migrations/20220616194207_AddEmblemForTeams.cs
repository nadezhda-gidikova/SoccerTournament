using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SoccerTournament.Data.Migrations
{
    public partial class AddEmblemForTeams : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Emblem",
                table: "Games",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Emblem",
                table: "Games");
        }
    }
}
