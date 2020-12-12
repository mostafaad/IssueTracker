using Microsoft.EntityFrameworkCore.Migrations;

namespace IssueTracker.Infrastructure.Migrations
{
    public partial class migrationuserOwner : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsOwner",
                table: "Participants",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsOwner",
                table: "Participants");
        }
    }
}
