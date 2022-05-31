using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BlazorNotesApp.Server.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Notes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Heading = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Body = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsChecked = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Notes", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Notes",
                columns: new[] { "Id", "Body", "Heading", "IsChecked" },
                values: new object[] { 1, "This is the first note about the first thing I want to talk about", "First Note", false });

            migrationBuilder.InsertData(
                table: "Notes",
                columns: new[] { "Id", "Body", "Heading", "IsChecked" },
                values: new object[] { 2, "This is the Second note about the second thing I want to talk about", "Second Note", true });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Notes");
        }
    }
}
