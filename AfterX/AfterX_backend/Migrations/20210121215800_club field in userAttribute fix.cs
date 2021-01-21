using Microsoft.EntityFrameworkCore.Migrations;

namespace AfterX_backend.Migrations
{
    public partial class clubfieldinuserAttributefix : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_userattribues_club_ClubId",
                table: "userattribues");

            migrationBuilder.AlterColumn<int>(
                name: "ClubId",
                table: "userattribues",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AddForeignKey(
                name: "FK_userattribues_club_ClubId",
                table: "userattribues",
                column: "ClubId",
                principalTable: "club",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_userattribues_club_ClubId",
                table: "userattribues");

            migrationBuilder.AlterColumn<int>(
                name: "ClubId",
                table: "userattribues",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_userattribues_club_ClubId",
                table: "userattribues",
                column: "ClubId",
                principalTable: "club",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
