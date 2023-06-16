using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IFootball.Infrastructure.Migrations
{
    public partial class refactorMapDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_team_user_IdUser",
                table: "team_user");

            migrationBuilder.CreateIndex(
                name: "IX_team_user_IdUser",
                table: "team_user",
                column: "IdUser");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_team_user_IdUser",
                table: "team_user");

            migrationBuilder.CreateIndex(
                name: "IX_team_user_IdUser",
                table: "team_user",
                column: "IdUser",
                unique: true);
        }
    }
}
