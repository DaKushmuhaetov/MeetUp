using Microsoft.EntityFrameworkCore.Migrations;

namespace MeetUp.DatabaseMigrations.Migrations
{
    public partial class Fixmeet : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Meet",
                type: "text",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                table: "Meet");
        }
    }
}
