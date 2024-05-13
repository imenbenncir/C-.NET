using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CRUDelicious.Migrations
{
    /// <inheritdoc />
    public partial class CRUDelicious1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Dishs",
                newName: "NameofDish");

            migrationBuilder.RenameColumn(
                name: "Chef",
                table: "Dishs",
                newName: "ChefName");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "NameofDish",
                table: "Dishs",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "ChefName",
                table: "Dishs",
                newName: "Chef");
        }
    }
}
