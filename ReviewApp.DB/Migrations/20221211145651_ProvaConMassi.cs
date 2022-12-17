using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ReviewApp.DB.Migrations
{
    public partial class ProvaConMassi : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_comment",
                table: "comment");

            migrationBuilder.RenameTable(
                name: "comment",
                newName: "review");

            migrationBuilder.AddPrimaryKey(
                name: "PK_review",
                table: "review",
                column: "id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_review",
                table: "review");

            migrationBuilder.RenameTable(
                name: "review",
                newName: "comment");

            migrationBuilder.AddPrimaryKey(
                name: "PK_comment",
                table: "comment",
                column: "id");
        }
    }
}
