using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IFootball.Infrastructure.Migrations
{
    public partial class initialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Role",
                table: "user",
                newName: "role");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "role",
                table: "user",
                newName: "Role");
        }
    }
}
