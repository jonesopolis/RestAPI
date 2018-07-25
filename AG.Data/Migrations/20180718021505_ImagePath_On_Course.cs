using Microsoft.EntityFrameworkCore.Migrations;

namespace AG.Data.Migrations
{
    public partial class ImagePath_On_Course : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LogoUrl",
                table: "Courses");

            migrationBuilder.AddColumn<string>(
                name: "ImagePath",
                table: "Courses",
                maxLength: 50,
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImagePath",
                table: "Courses");

            migrationBuilder.AddColumn<string>(
                name: "LogoUrl",
                table: "Courses",
                maxLength: 250,
                nullable: true);
        }
    }
}
