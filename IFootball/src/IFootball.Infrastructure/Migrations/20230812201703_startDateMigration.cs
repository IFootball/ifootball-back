using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IFootball.Infrastructure.Migrations
{
    public partial class startDateMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "start_date",
                columns: table => new
                {
                    Id = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    start_date_of_matches = table.Column<DateTime>(type: "SMALLDATETIME", maxLength: 60, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_start_date", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "start_date");
        }
    }
}
