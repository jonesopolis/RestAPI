using Microsoft.EntityFrameworkCore.Migrations;

namespace AG.Data.Migrations
{
    public partial class WistiaKey_OnHole : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "WistiaKey",
                table: "Holes",
                maxLength: 50,
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "WistiaKey",
                table: "Holes");
        }
    }
}
