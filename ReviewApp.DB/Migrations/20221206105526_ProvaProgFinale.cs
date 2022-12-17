using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ReviewApp.DB.Migrations
{
    public partial class ProvaProgFinale : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "rating",
                table: "comment",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "rating",
                table: "comment");
        }
    }
}
