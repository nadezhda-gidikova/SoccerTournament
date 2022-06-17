using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SoccerTournament.Data.Migrations
{
    public partial class changewinnertimeType : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Competitions_Teams_WinnerId",
                table: "Competitions");

            migrationBuilder.AlterColumn<int>(
                name: "WinnerId",
                table: "Competitions",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Competitions_Teams_WinnerId",
                table: "Competitions",
                column: "WinnerId",
                principalTable: "Teams",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Competitions_Teams_WinnerId",
                table: "Competitions");

            migrationBuilder.AlterColumn<int>(
                name: "WinnerId",
                table: "Competitions",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Competitions_Teams_WinnerId",
                table: "Competitions",
                column: "WinnerId",
                principalTable: "Teams",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
