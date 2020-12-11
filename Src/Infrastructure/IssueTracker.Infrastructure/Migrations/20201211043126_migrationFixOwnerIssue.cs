using Microsoft.EntityFrameworkCore.Migrations;

namespace IssueTracker.Infrastructure.Migrations
{
    public partial class migrationFixOwnerIssue : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Projects_Owner",
                table: "Projects");

            migrationBuilder.CreateIndex(
                name: "IX_Projects_Owner",
                table: "Projects",
                column: "Owner");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Projects_Owner",
                table: "Projects");

            migrationBuilder.CreateIndex(
                name: "IX_Projects_Owner",
                table: "Projects",
                column: "Owner",
                unique: true,
                filter: "[Owner] IS NOT NULL");
        }
    }
}
