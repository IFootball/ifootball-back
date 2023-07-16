using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IFootball.Infrastructure.Migrations
{
    public partial class initialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "class",
                columns: table => new
                {
                    Id = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
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
                    Id = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    name = table.Column<int>(type: "INT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_gender", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "user",
                columns: table => new
                {
                    Id = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    IdClass = table.Column<long>(type: "INTEGER", nullable: false),
                    name = table.Column<string>(type: "NVARCHAR", maxLength: 128, nullable: false),
                    email = table.Column<string>(type: "NVARCHAR", maxLength: 255, nullable: false),
                    password = table.Column<string>(type: "NVARCHAR", maxLength: 128, nullable: false),
                    role = table.Column<int>(type: "INT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_user", x => x.Id);
                    table.ForeignKey(
                        name: "FK_class_user",
                        column: x => x.IdClass,
                        principalTable: "class",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "team_class",
                columns: table => new
                {
                    Id = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    IdGender = table.Column<long>(type: "INTEGER", nullable: false),
                    IdClass = table.Column<long>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_team_class", x => x.Id);
                    table.ForeignKey(
                        name: "FK_class_teamclass",
                        column: x => x.IdClass,
                        principalTable: "class",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_gender_teamclass",
                        column: x => x.IdGender,
                        principalTable: "gender",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "goalkeeper",
                columns: table => new
                {
                    Id = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    IdGender = table.Column<long>(type: "INTEGER", nullable: false),
                    IdTeamClass = table.Column<long>(type: "INTEGER", nullable: false),
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
                    Id = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    IdGender = table.Column<long>(type: "INTEGER", nullable: false),
                    IdTeamClass = table.Column<long>(type: "INTEGER", nullable: false),
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
                    Id = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    IdUser = table.Column<long>(type: "INTEGER", nullable: false),
                    id_captain = table.Column<long>(type: "INT", nullable: true),
                    IdGender = table.Column<long>(type: "INTEGER", nullable: false),
                    IdGoalkeeper = table.Column<long>(type: "INTEGER", nullable: false),
                    IdLinePlayerFront = table.Column<long>(type: "INTEGER", nullable: false),
                    IdLinePlayerMiddle = table.Column<long>(type: "INTEGER", nullable: false),
                    IdLinePlayerBackRight = table.Column<long>(type: "INTEGER", nullable: false),
                    IdLinePlayerBackLeft = table.Column<long>(type: "INTEGER", nullable: false),
                    IdReservePlayerOne = table.Column<long>(type: "INTEGER", nullable: true),
                    IdReservePlayerTwo = table.Column<long>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_team_user", x => x.Id);
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
                        name: "FK_lineplayerfront_teamuser",
                        column: x => x.IdLinePlayerFront,
                        principalTable: "line_player",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_lineplayermiddle_teamuser",
                        column: x => x.IdLinePlayerMiddle,
                        principalTable: "line_player",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_reserveplayerone_teamuser",
                        column: x => x.IdReservePlayerOne,
                        principalTable: "line_player",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_reserveplayertwo_teamuser",
                        column: x => x.IdReservePlayerTwo,
                        principalTable: "line_player",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_user_teamuser",
                        column: x => x.IdUser,
                        principalTable: "user",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_goalkeeper_IdGender",
                table: "goalkeeper",
                column: "IdGender");

            migrationBuilder.CreateIndex(
                name: "IX_goalkeeper_IdTeamClass",
                table: "goalkeeper",
                column: "IdTeamClass");

            migrationBuilder.CreateIndex(
                name: "IX_line_player_IdGender",
                table: "line_player",
                column: "IdGender");

            migrationBuilder.CreateIndex(
                name: "IX_line_player_IdTeamClass",
                table: "line_player",
                column: "IdTeamClass");

            migrationBuilder.CreateIndex(
                name: "IX_team_class_IdClass",
                table: "team_class",
                column: "IdClass");

            migrationBuilder.CreateIndex(
                name: "IX_team_class_IdGender",
                table: "team_class",
                column: "IdGender");

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
                name: "IX_team_user_IdLinePlayerFront",
                table: "team_user",
                column: "IdLinePlayerFront");

            migrationBuilder.CreateIndex(
                name: "IX_team_user_IdLinePlayerMiddle",
                table: "team_user",
                column: "IdLinePlayerMiddle");

            migrationBuilder.CreateIndex(
                name: "IX_team_user_IdReservePlayerOne",
                table: "team_user",
                column: "IdReservePlayerOne");

            migrationBuilder.CreateIndex(
                name: "IX_team_user_IdReservePlayerTwo",
                table: "team_user",
                column: "IdReservePlayerTwo");

            migrationBuilder.CreateIndex(
                name: "IX_team_user_IdUser",
                table: "team_user",
                column: "IdUser");

            migrationBuilder.CreateIndex(
                name: "IX_user_IdClass",
                table: "user",
                column: "IdClass");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "team_user");

            migrationBuilder.DropTable(
                name: "goalkeeper");

            migrationBuilder.DropTable(
                name: "line_player");

            migrationBuilder.DropTable(
                name: "user");

            migrationBuilder.DropTable(
                name: "team_class");

            migrationBuilder.DropTable(
                name: "class");

            migrationBuilder.DropTable(
                name: "gender");
        }
    }
}
