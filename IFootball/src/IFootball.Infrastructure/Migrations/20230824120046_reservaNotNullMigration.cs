using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IFootball.Infrastructure.Migrations
{
    public partial class reservaNotNullMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_reserveplayerone_teamuser",
                table: "team_user");

            migrationBuilder.DropForeignKey(
                name: "FK_reserveplayertwo_teamuser",
                table: "team_user");

            migrationBuilder.AlterColumn<long>(
                name: "id_captain",
                table: "team_user",
                type: "INT",
                nullable: false,
                defaultValue: 0L,
                oldClrType: typeof(long),
                oldType: "INT",
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "IdReservePlayerTwo",
                table: "team_user",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0L,
                oldClrType: typeof(long),
                oldType: "INTEGER",
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "IdReservePlayerOne",
                table: "team_user",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0L,
                oldClrType: typeof(long),
                oldType: "INTEGER",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_reserveplayerone_teamuser",
                table: "team_user",
                column: "IdReservePlayerOne",
                principalTable: "player",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_reserveplayertwo_teamuser",
                table: "team_user",
                column: "IdReservePlayerTwo",
                principalTable: "player",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_reserveplayerone_teamuser",
                table: "team_user");

            migrationBuilder.DropForeignKey(
                name: "FK_reserveplayertwo_teamuser",
                table: "team_user");

            migrationBuilder.AlterColumn<long>(
                name: "id_captain",
                table: "team_user",
                type: "INT",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "INT");

            migrationBuilder.AlterColumn<long>(
                name: "IdReservePlayerTwo",
                table: "team_user",
                type: "INTEGER",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "INTEGER");

            migrationBuilder.AlterColumn<long>(
                name: "IdReservePlayerOne",
                table: "team_user",
                type: "INTEGER",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "INTEGER");

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
    }
}
