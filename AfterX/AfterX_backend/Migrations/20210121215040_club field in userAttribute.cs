using Microsoft.EntityFrameworkCore.Migrations;

namespace AfterX_backend.Migrations
{
    public partial class clubfieldinuserAttribute : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ClubId",
                table: "userattribues",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_userattribues_ClubId",
                table: "userattribues",
                column: "ClubId");

            migrationBuilder.AddForeignKey(
                name: "FK_userattribues_club_ClubId",
                table: "userattribues",
                column: "ClubId",
                principalTable: "club",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_userattribues_club_ClubId",
                table: "userattribues");

            migrationBuilder.DropIndex(
                name: "IX_userattribues_ClubId",
                table: "userattribues");

            migrationBuilder.DropColumn(
                name: "ClubId",
                table: "userattribues");
        }
    }
}
