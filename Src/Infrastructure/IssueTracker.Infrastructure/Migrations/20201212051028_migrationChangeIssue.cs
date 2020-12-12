using Microsoft.EntityFrameworkCore.Migrations;

namespace IssueTracker.Infrastructure.Migrations
{
    public partial class migrationChangeIssue : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Issues",
                table: "Issues");

            migrationBuilder.DropColumn(
                name: "Idd",
                table: "Issues");

            migrationBuilder.AddColumn<string>(
                name: "Id",
                table: "Issues",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Issues",
                table: "Issues",
                column: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Issues",
                table: "Issues");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "Issues");

            migrationBuilder.AddColumn<int>(
                name: "Idd",
                table: "Issues",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Issues",
                table: "Issues",
                column: "Idd");
        }
    }
}
