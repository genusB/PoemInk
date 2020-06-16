using Microsoft.EntityFrameworkCore.Migrations;

namespace PoemInk.Migrations
{
    public partial class Changepoetmodel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Gender",
                table: "Poets",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Locale",
                table: "Poets",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Gender",
                table: "Poets");

            migrationBuilder.DropColumn(
                name: "Locale",
                table: "Poets");
        }
    }
}
