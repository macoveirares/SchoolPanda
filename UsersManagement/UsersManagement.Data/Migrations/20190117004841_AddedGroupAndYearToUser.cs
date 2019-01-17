using Microsoft.EntityFrameworkCore.Migrations;

namespace UsersManagement.Data.Migrations
{
    public partial class AddedGroupAndYearToUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Group",
                table: "Users",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "Year",
                table: "Users",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Group",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "Year",
                table: "Users");
        }
    }
}
