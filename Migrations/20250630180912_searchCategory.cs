using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace houlala_suggestion.Migrations
{
    /// <inheritdoc />
    public partial class searchCategory : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "SearchCategory",
                table: "Suggestions",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SearchCategory",
                table: "Suggestions");
        }
    }
}
