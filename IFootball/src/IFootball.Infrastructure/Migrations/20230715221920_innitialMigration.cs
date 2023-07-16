using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IFootball.Infrastructure.Migrations
{
    public partial class innitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_class_goalkeeper",
                table: "goalkeeper");

            migrationBuilder.DropForeignKey(
                name: "FK_class_lineplayer",
                table: "line_player");

            migrationBuilder.DropIndex(
                name: "IX_line_player_IdClass",
                table: "line_player");

            migrationBuilder.DropIndex(
                name: "IX_goalkeeper_IdClass",
                table: "goalkeeper");

            migrationBuilder.DropColumn(
                name: "IdClass",
                table: "line_player");

            migrationBuilder.DropColumn(
                name: "IdClass",
                table: "goalkeeper");

            migrationBuilder.AddColumn<long>(
                name: "IdClass",
                table: "team_class",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.CreateIndex(
                name: "IX_team_class_IdClass",
                table: "team_class",
                column: "IdClass");

            migrationBuilder.AddForeignKey(
                name: "FK_class_teamclass",
                table: "team_class",
                column: "IdClass",
                principalTable: "class",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_class_teamclass",
                table: "team_class");

            migrationBuilder.DropIndex(
                name: "IX_team_class_IdClass",
                table: "team_class");

            migrationBuilder.DropColumn(
                name: "IdClass",
                table: "team_class");

            migrationBuilder.AddColumn<long>(
                name: "IdClass",
                table: "line_player",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<long>(
                name: "IdClass",
                table: "goalkeeper",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.CreateIndex(
                name: "IX_line_player_IdClass",
                table: "line_player",
                column: "IdClass");

            migrationBuilder.CreateIndex(
                name: "IX_goalkeeper_IdClass",
                table: "goalkeeper",
                column: "IdClass");

            migrationBuilder.AddForeignKey(
                name: "FK_class_goalkeeper",
                table: "goalkeeper",
                column: "IdClass",
                principalTable: "class",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_class_lineplayer",
                table: "line_player",
                column: "IdClass",
                principalTable: "class",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
