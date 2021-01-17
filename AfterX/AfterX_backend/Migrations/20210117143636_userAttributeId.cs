using Microsoft.EntityFrameworkCore.Migrations;

namespace AfterX_backend.Migrations
{
    public partial class userAttributeId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "UserattribueId",
                table: "user",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UserattribueId",
                table: "user");
        }
    }
}
