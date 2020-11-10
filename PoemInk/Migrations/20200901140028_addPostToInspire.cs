using Microsoft.EntityFrameworkCore.Migrations;

namespace PoemInk.Migrations
{
    public partial class addPostToInspire : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "PostToInspire",
                table: "Poems",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PostToInspire",
                table: "Poems");
        }
    }
}
