using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IFootball.Infrastructure.Migrations
{
    public partial class RfactorPlayerTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_gender_goalkepper",
                table: "goalkeeper");

            migrationBuilder.DropForeignKey(
                name: "FK_teamclass_goalkeeper",
                table: "goalkeeper");

            migrationBuilder.DropForeignKey(
                name: "FK_goalkeeper_teamuser",
                table: "team_user");

            migrationBuilder.DropForeignKey(
                name: "FK_lineplayerbackleft_teamuser",
                table: "team_user");

            migrationBuilder.DropForeignKey(
                name: "FK_lineplayerbackright_teamuser",
                table: "team_user");

            migrationBuilder.DropForeignKey(
                name: "FK_lineplayerfront_teamuser",
                table: "team_user");

            migrationBuilder.DropForeignKey(
                name: "FK_lineplayermiddle_teamuser",
                table: "team_user");

            migrationBuilder.DropForeignKey(
                name: "FK_reserveplayerone_teamuser",
                table: "team_user");

            migrationBuilder.DropForeignKey(
                name: "FK_reserveplayertwo_teamuser",
                table: "team_user");

            migrationBuilder.DropTable(
                name: "line_player");

            migrationBuilder.DropIndex(
                name: "IX_goalkeeper_IdGender",
                table: "goalkeeper");

            migrationBuilder.DropIndex(
                name: "IX_goalkeeper_IdTeamClass",
                table: "goalkeeper");

            migrationBuilder.DropColumn(
                name: "IdGender",
                table: "goalkeeper");

            migrationBuilder.DropColumn(
                name: "assists",
                table: "goalkeeper");

            migrationBuilder.DropColumn(
                name: "fouls",
                table: "goalkeeper");

            migrationBuilder.DropColumn(
                name: "goals",
                table: "goalkeeper");

            migrationBuilder.DropColumn(
                name: "image",
                table: "goalkeeper");

            migrationBuilder.DropColumn(
                name: "name",
                table: "goalkeeper");

            migrationBuilder.DropColumn(
                name: "red_card",
                table: "goalkeeper");

            migrationBuilder.DropColumn(
                name: "wins",
                table: "goalkeeper");

            migrationBuilder.DropColumn(
                name: "yellow_card",
                table: "goalkeeper");

            migrationBuilder.RenameColumn(
                name: "IdLinePlayerMiddle",
                table: "team_user",
                newName: "IdPlayerTwo");

            migrationBuilder.RenameColumn(
                name: "IdLinePlayerFront",
                table: "team_user",
                newName: "IdPlayerThree");

            migrationBuilder.RenameColumn(
                name: "IdLinePlayerBackRight",
                table: "team_user",
                newName: "IdPlayerOne");

            migrationBuilder.RenameColumn(
                name: "IdLinePlayerBackLeft",
                table: "team_user",
                newName: "IdPlayerFour");

            migrationBuilder.RenameIndex(
                name: "IX_team_user_IdLinePlayerMiddle",
                table: "team_user",
                newName: "IX_team_user_IdPlayerTwo");

            migrationBuilder.RenameIndex(
                name: "IX_team_user_IdLinePlayerFront",
                table: "team_user",
                newName: "IX_team_user_IdPlayerThree");

            migrationBuilder.RenameIndex(
                name: "IX_team_user_IdLinePlayerBackRight",
                table: "team_user",
                newName: "IX_team_user_IdPlayerOne");

            migrationBuilder.RenameIndex(
                name: "IX_team_user_IdLinePlayerBackLeft",
                table: "team_user",
                newName: "IX_team_user_IdPlayerFour");

            migrationBuilder.RenameColumn(
                name: "IdTeamClass",
                table: "goalkeeper",
                newName: "IdPlayer");

            migrationBuilder.CreateTable(
                name: "player",
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
                    table.PrimaryKey("PK_player", x => x.Id);
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

            migrationBuilder.CreateIndex(
                name: "IX_goalkeeper_IdPlayer",
                table: "goalkeeper",
                column: "IdPlayer",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_player_IdGender",
                table: "player",
                column: "IdGender");

            migrationBuilder.CreateIndex(
                name: "IX_player_IdTeamClass",
                table: "player",
                column: "IdTeamClass");

            migrationBuilder.AddForeignKey(
                name: "FK_player_goalkeeper",
                table: "goalkeeper",
                column: "IdPlayer",
                principalTable: "player",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_goalkeeper_teamuser",
                table: "team_user",
                column: "IdGoalkeeper",
                principalTable: "player",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_playerFour_teamuser",
                table: "team_user",
                column: "IdPlayerFour",
                principalTable: "player",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_playerOne_teamuser",
                table: "team_user",
                column: "IdPlayerOne",
                principalTable: "player",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_playerThree_teamuser",
                table: "team_user",
                column: "IdPlayerThree",
                principalTable: "player",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_playerTwo_teamuser",
                table: "team_user",
                column: "IdPlayerTwo",
                principalTable: "player",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_reserveplayerone_teamuser",
                table: "team_user",
                column: "IdReservePlayerOne",
                principalTable: "player",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_reserveplayertwo_teamuser",
                table: "team_user",
                column: "IdReservePlayerTwo",
                principalTable: "player",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_player_goalkeeper",
                table: "goalkeeper");

            migrationBuilder.DropForeignKey(
                name: "FK_goalkeeper_teamuser",
                table: "team_user");

            migrationBuilder.DropForeignKey(
                name: "FK_playerFour_teamuser",
                table: "team_user");

            migrationBuilder.DropForeignKey(
                name: "FK_playerOne_teamuser",
                table: "team_user");

            migrationBuilder.DropForeignKey(
                name: "FK_playerThree_teamuser",
                table: "team_user");

            migrationBuilder.DropForeignKey(
                name: "FK_playerTwo_teamuser",
                table: "team_user");

            migrationBuilder.DropForeignKey(
                name: "FK_reserveplayerone_teamuser",
                table: "team_user");

            migrationBuilder.DropForeignKey(
                name: "FK_reserveplayertwo_teamuser",
                table: "team_user");

            migrationBuilder.DropTable(
                name: "player");

            migrationBuilder.DropIndex(
                name: "IX_goalkeeper_IdPlayer",
                table: "goalkeeper");

            migrationBuilder.RenameColumn(
                name: "IdPlayerTwo",
                table: "team_user",
                newName: "IdLinePlayerMiddle");

            migrationBuilder.RenameColumn(
                name: "IdPlayerThree",
                table: "team_user",
                newName: "IdLinePlayerFront");

            migrationBuilder.RenameColumn(
                name: "IdPlayerOne",
                table: "team_user",
                newName: "IdLinePlayerBackRight");

            migrationBuilder.RenameColumn(
                name: "IdPlayerFour",
                table: "team_user",
                newName: "IdLinePlayerBackLeft");

            migrationBuilder.RenameIndex(
                name: "IX_team_user_IdPlayerTwo",
                table: "team_user",
                newName: "IX_team_user_IdLinePlayerMiddle");

            migrationBuilder.RenameIndex(
                name: "IX_team_user_IdPlayerThree",
                table: "team_user",
                newName: "IX_team_user_IdLinePlayerFront");

            migrationBuilder.RenameIndex(
                name: "IX_team_user_IdPlayerOne",
                table: "team_user",
                newName: "IX_team_user_IdLinePlayerBackRight");

            migrationBuilder.RenameIndex(
                name: "IX_team_user_IdPlayerFour",
                table: "team_user",
                newName: "IX_team_user_IdLinePlayerBackLeft");

            migrationBuilder.RenameColumn(
                name: "IdPlayer",
                table: "goalkeeper",
                newName: "IdTeamClass");

            migrationBuilder.AddColumn<long>(
                name: "IdGender",
                table: "goalkeeper",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<int>(
                name: "assists",
                table: "goalkeeper",
                type: "INT",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "fouls",
                table: "goalkeeper",
                type: "INT",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "goals",
                table: "goalkeeper",
                type: "INT",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "image",
                table: "goalkeeper",
                type: "NVARCHAR",
                maxLength: 512,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "name",
                table: "goalkeeper",
                type: "NVARCHAR",
                maxLength: 128,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "red_card",
                table: "goalkeeper",
                type: "INT",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "wins",
                table: "goalkeeper",
                type: "INT",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "yellow_card",
                table: "goalkeeper",
                type: "INT",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "line_player",
                columns: table => new
                {
                    Id = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    IdGender = table.Column<long>(type: "INTEGER", nullable: false),
                    IdTeamClass = table.Column<long>(type: "INTEGER", nullable: false),
                    assists = table.Column<int>(type: "INT", nullable: false),
                    fouls = table.Column<int>(type: "INT", nullable: false),
                    goals = table.Column<int>(type: "INT", nullable: false),
                    image = table.Column<string>(type: "NVARCHAR", maxLength: 512, nullable: false),
                    name = table.Column<string>(type: "NVARCHAR", maxLength: 128, nullable: false),
                    red_card = table.Column<int>(type: "INT", nullable: false),
                    wins = table.Column<int>(type: "INT", nullable: false),
                    yellow_card = table.Column<int>(type: "INT", nullable: false)
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

            migrationBuilder.AddForeignKey(
                name: "FK_gender_goalkepper",
                table: "goalkeeper",
                column: "IdGender",
                principalTable: "gender",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_teamclass_goalkeeper",
                table: "goalkeeper",
                column: "IdTeamClass",
                principalTable: "team_class",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_goalkeeper_teamuser",
                table: "team_user",
                column: "IdGoalkeeper",
                principalTable: "goalkeeper",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_lineplayerbackleft_teamuser",
                table: "team_user",
                column: "IdLinePlayerBackLeft",
                principalTable: "line_player",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_lineplayerbackright_teamuser",
                table: "team_user",
                column: "IdLinePlayerBackRight",
                principalTable: "line_player",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_lineplayerfront_teamuser",
                table: "team_user",
                column: "IdLinePlayerFront",
                principalTable: "line_player",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_lineplayermiddle_teamuser",
                table: "team_user",
                column: "IdLinePlayerMiddle",
                principalTable: "line_player",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_reserveplayerone_teamuser",
                table: "team_user",
                column: "IdReservePlayerOne",
                principalTable: "line_player",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_reserveplayertwo_teamuser",
                table: "team_user",
                column: "IdReservePlayerTwo",
                principalTable: "line_player",
                principalColumn: "Id");
        }
    }
}
