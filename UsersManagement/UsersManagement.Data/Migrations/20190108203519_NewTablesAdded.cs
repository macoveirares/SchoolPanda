using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace UsersManagement.Data.Migrations
{
    public partial class NewTablesAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Courses",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    Year = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Courses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UsersToCourses",
                columns: table => new
                {
                    UserId = table.Column<int>(nullable: false),
                    CourseId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UsersToCourses", x => new { x.UserId, x.CourseId });
                    table.ForeignKey(
                        name: "FK_UsersToCourses_Courses_CourseId",
                        column: x => x.CourseId,
                        principalTable: "Courses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UsersToCourses_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_UsersToCourses_CourseId",
                table: "UsersToCourses",
                column: "CourseId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UsersToCourses");

            migrationBuilder.DropTable(
                name: "Courses");
        }
    }
}
