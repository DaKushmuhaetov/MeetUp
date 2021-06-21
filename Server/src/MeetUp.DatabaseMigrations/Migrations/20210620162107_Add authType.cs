using Microsoft.EntityFrameworkCore.Migrations;

namespace MeetUp.DatabaseMigrations.Migrations
{
    public partial class AddauthType : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AuthType",
                table: "User",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_User_AuthType",
                table: "User",
                column: "AuthType",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_User_AuthType",
                table: "User");

            migrationBuilder.DropColumn(
                name: "AuthType",
                table: "User");
        }
    }
}
