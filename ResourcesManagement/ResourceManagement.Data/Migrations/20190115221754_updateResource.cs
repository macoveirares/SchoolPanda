using Microsoft.EntityFrameworkCore.Migrations;

namespace ResourceManagement.Data.Migrations
{
    public partial class updateResource : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CourseId",
                table: "Resources",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CourseId",
                table: "Resources");
        }
    }
}
