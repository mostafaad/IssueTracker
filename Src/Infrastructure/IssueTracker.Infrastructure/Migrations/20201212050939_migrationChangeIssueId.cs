using Microsoft.EntityFrameworkCore.Migrations;

namespace IssueTracker.Infrastructure.Migrations
{
    public partial class migrationChangeIssueId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Issues",
                newName: "Idd");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Idd",
                table: "Issues",
                newName: "Id");
        }
    }
}
