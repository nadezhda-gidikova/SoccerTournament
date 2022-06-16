using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SoccerTournament.Data.Migrations
{
    public partial class changeColumnCoachId1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Coaches_TeamId",
                table: "Coaches");

            migrationBuilder.AlterColumn<int>(
                name: "TeamId",
                table: "Coaches",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateIndex(
                name: "IX_Coaches_TeamId",
                table: "Coaches",
                column: "TeamId",
                unique: true,
                filter: "[TeamId] IS NOT NULL");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Coaches_TeamId",
                table: "Coaches");

            migrationBuilder.AlterColumn<int>(
                name: "TeamId",
                table: "Coaches",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Coaches_TeamId",
                table: "Coaches",
                column: "TeamId",
                unique: true);
        }
    }
}
