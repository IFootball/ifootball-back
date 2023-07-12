using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IFootball.Infrastructure.Migrations
{
    public partial class initialProject : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_coach_teamuser",
                table: "team_user");

            migrationBuilder.DropTable(
                name: "coche");

            migrationBuilder.DropIndex(
                name: "IX_team_user_IdCoach",
                table: "team_user");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "coche",
                columns: table => new
                {
                    Id = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    IdClass = table.Column<long>(type: "INTEGER", nullable: false),
                    IdGender = table.Column<long>(type: "INTEGER", nullable: false),
                    IdTeamClass = table.Column<long>(type: "INTEGER", nullable: false),
                    image = table.Column<string>(type: "NVARCHAR", maxLength: 512, nullable: false),
                    name = table.Column<string>(type: "NVARCHAR", maxLength: 128, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_coche", x => x.Id);
                    table.ForeignKey(
                        name: "FK_class_coach",
                        column: x => x.IdClass,
                        principalTable: "class",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_gender_coach",
                        column: x => x.IdGender,
                        principalTable: "gender",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_teamclass_coach",
                        column: x => x.IdTeamClass,
                        principalTable: "team_class",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_team_user_IdCoach",
                table: "team_user",
                column: "IdCoach");

            migrationBuilder.CreateIndex(
                name: "IX_coche_IdClass",
                table: "coche",
                column: "IdClass");

            migrationBuilder.CreateIndex(
                name: "IX_coche_IdGender",
                table: "coche",
                column: "IdGender");

            migrationBuilder.CreateIndex(
                name: "IX_coche_IdTeamClass",
                table: "coche",
                column: "IdTeamClass",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_coach_teamuser",
                table: "team_user",
                column: "IdCoach",
                principalTable: "coche",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
