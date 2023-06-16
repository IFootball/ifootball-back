using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IFootball.Infrastructure.Migrations
{
    public partial class mapDB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "IdClass",
                table: "user",
                type: "TEXT",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<int>(
                name: "Role",
                table: "user",
                type: "INT",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "email",
                table: "user",
                type: "NVARCHAR",
                maxLength: 255,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "name",
                table: "user",
                type: "NVARCHAR",
                maxLength: 128,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "password",
                table: "user",
                type: "NVARCHAR",
                maxLength: 128,
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "class",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    name = table.Column<string>(type: "NVARCHAR", maxLength: 128, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_class", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "gender",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    name = table.Column<int>(type: "INT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_gender", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "team_class",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    IdGender = table.Column<Guid>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_team_class", x => x.Id);
                    table.ForeignKey(
                        name: "FK_gender_teamclass",
                        column: x => x.IdGender,
                        principalTable: "gender",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "coche",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    IdClass = table.Column<Guid>(type: "TEXT", nullable: false),
                    IdGender = table.Column<Guid>(type: "TEXT", nullable: false),
                    IdTeamClass = table.Column<Guid>(type: "TEXT", nullable: false),
                    name = table.Column<string>(type: "NVARCHAR", maxLength: 128, nullable: false),
                    image = table.Column<string>(type: "NVARCHAR", maxLength: 512, nullable: false)
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

            migrationBuilder.CreateTable(
                name: "goalkeeper",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    IdGender = table.Column<Guid>(type: "TEXT", nullable: false),
                    IdClass = table.Column<Guid>(type: "TEXT", nullable: false),
                    IdTeamClass = table.Column<Guid>(type: "TEXT", nullable: false),
                    taken_gols = table.Column<int>(type: "INT", nullable: false),
                    penalty_saves = table.Column<int>(type: "INT", nullable: false),
                    saves = table.Column<int>(type: "INT", nullable: false),
                    name = table.Column<string>(type: "NVARCHAR", maxLength: 128, nullable: false),
                    image = table.Column<string>(type: "NVARCHAR", maxLength: 512, nullable: false),
                    goals = table.Column<int>(type: "INT", nullable: false),
                    assists = table.Column<int>(type: "INT", nullable: false),
                    yellow_card = table.Column<int>(type: "INT", nullable: false),
                    red_card = table.Column<int>(type: "INT", nullable: false),
                    fouls = table.Column<int>(type: "INT", nullable: false),
                    wins = table.Column<int>(type: "INT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_goalkeeper", x => x.Id);
                    table.ForeignKey(
                        name: "FK_class_goalkeeper",
                        column: x => x.IdClass,
                        principalTable: "class",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_gender_goalkepper",
                        column: x => x.IdGender,
                        principalTable: "gender",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_teamclass_goalkeeper",
                        column: x => x.IdTeamClass,
                        principalTable: "team_class",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "line_player",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    IdGender = table.Column<Guid>(type: "TEXT", nullable: false),
                    IdClass = table.Column<Guid>(type: "TEXT", nullable: false),
                    IdTeamClass = table.Column<Guid>(type: "TEXT", nullable: false),
                    name = table.Column<string>(type: "NVARCHAR", maxLength: 128, nullable: false),
                    image = table.Column<string>(type: "NVARCHAR", maxLength: 512, nullable: false),
                    goals = table.Column<int>(type: "INT", nullable: false),
                    assists = table.Column<int>(type: "INT", nullable: false),
                    yellow_card = table.Column<int>(type: "INT", nullable: false),
                    red_card = table.Column<int>(type: "INT", nullable: false),
                    fouls = table.Column<int>(type: "INT", nullable: false),
                    wins = table.Column<int>(type: "INT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_line_player", x => x.Id);
                    table.ForeignKey(
                        name: "FK_class_lineplayer",
                        column: x => x.IdClass,
                        principalTable: "class",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_gender_lineplayer",
                        column: x => x.IdGender,
                        principalTable: "gender",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_teamclass_lineplayer",
                        column: x => x.IdTeamClass,
                        principalTable: "team_class",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "team_user",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    IdUser = table.Column<Guid>(type: "TEXT", nullable: false),
                    IdGender = table.Column<Guid>(type: "TEXT", nullable: false),
                    IdCoach = table.Column<Guid>(type: "TEXT", nullable: false),
                    IdGoalkeeper = table.Column<Guid>(type: "TEXT", nullable: false),
                    IdLinePlayerFrontLeft = table.Column<Guid>(type: "TEXT", nullable: false),
                    IdLinePlayerFrontRight = table.Column<Guid>(type: "TEXT", nullable: false),
                    IdLinePlayerBackRight = table.Column<Guid>(type: "TEXT", nullable: false),
                    IdLinePlayerBackLeft = table.Column<Guid>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_team_user", x => x.Id);
                    table.ForeignKey(
                        name: "FK_coach_teamuser",
                        column: x => x.IdCoach,
                        principalTable: "coche",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_gender_teamuser",
                        column: x => x.IdGender,
                        principalTable: "gender",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_goalkeeper_teamuser",
                        column: x => x.IdGoalkeeper,
                        principalTable: "goalkeeper",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_lineplayerbackleft_teamuser",
                        column: x => x.IdLinePlayerBackLeft,
                        principalTable: "line_player",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_lineplayerbackright_teamuser",
                        column: x => x.IdLinePlayerBackRight,
                        principalTable: "line_player",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_lineplayerfrontleft_teamuser",
                        column: x => x.IdLinePlayerFrontLeft,
                        principalTable: "line_player",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_lineplayerfrontright_teamuser",
                        column: x => x.IdLinePlayerFrontRight,
                        principalTable: "line_player",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_user_teamuser",
                        column: x => x.IdUser,
                        principalTable: "user",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_user_IdClass",
                table: "user",
                column: "IdClass");

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

            migrationBuilder.CreateIndex(
                name: "IX_goalkeeper_IdClass",
                table: "goalkeeper",
                column: "IdClass");

            migrationBuilder.CreateIndex(
                name: "IX_goalkeeper_IdGender",
                table: "goalkeeper",
                column: "IdGender");

            migrationBuilder.CreateIndex(
                name: "IX_goalkeeper_IdTeamClass",
                table: "goalkeeper",
                column: "IdTeamClass");

            migrationBuilder.CreateIndex(
                name: "IX_line_player_IdClass",
                table: "line_player",
                column: "IdClass");

            migrationBuilder.CreateIndex(
                name: "IX_line_player_IdGender",
                table: "line_player",
                column: "IdGender");

            migrationBuilder.CreateIndex(
                name: "IX_line_player_IdTeamClass",
                table: "line_player",
                column: "IdTeamClass");

            migrationBuilder.CreateIndex(
                name: "IX_team_class_IdGender",
                table: "team_class",
                column: "IdGender");

            migrationBuilder.CreateIndex(
                name: "IX_team_user_IdCoach",
                table: "team_user",
                column: "IdCoach");

            migrationBuilder.CreateIndex(
                name: "IX_team_user_IdGender",
                table: "team_user",
                column: "IdGender");

            migrationBuilder.CreateIndex(
                name: "IX_team_user_IdGoalkeeper",
                table: "team_user",
                column: "IdGoalkeeper");

            migrationBuilder.CreateIndex(
                name: "IX_team_user_IdLinePlayerBackLeft",
                table: "team_user",
                column: "IdLinePlayerBackLeft");

            migrationBuilder.CreateIndex(
                name: "IX_team_user_IdLinePlayerBackRight",
                table: "team_user",
                column: "IdLinePlayerBackRight");

            migrationBuilder.CreateIndex(
                name: "IX_team_user_IdLinePlayerFrontLeft",
                table: "team_user",
                column: "IdLinePlayerFrontLeft");

            migrationBuilder.CreateIndex(
                name: "IX_team_user_IdLinePlayerFrontRight",
                table: "team_user",
                column: "IdLinePlayerFrontRight");

            migrationBuilder.CreateIndex(
                name: "IX_team_user_IdUser",
                table: "team_user",
                column: "IdUser",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_class_user",
                table: "user",
                column: "IdClass",
                principalTable: "class",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_class_user",
                table: "user");

            migrationBuilder.DropTable(
                name: "team_user");

            migrationBuilder.DropTable(
                name: "coche");

            migrationBuilder.DropTable(
                name: "goalkeeper");

            migrationBuilder.DropTable(
                name: "line_player");

            migrationBuilder.DropTable(
                name: "class");

            migrationBuilder.DropTable(
                name: "team_class");

            migrationBuilder.DropTable(
                name: "gender");

            migrationBuilder.DropIndex(
                name: "IX_user_IdClass",
                table: "user");

            migrationBuilder.DropColumn(
                name: "IdClass",
                table: "user");

            migrationBuilder.DropColumn(
                name: "Role",
                table: "user");

            migrationBuilder.DropColumn(
                name: "email",
                table: "user");

            migrationBuilder.DropColumn(
                name: "name",
                table: "user");

            migrationBuilder.DropColumn(
                name: "password",
                table: "user");
        }
    }
}
