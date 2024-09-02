using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace REPO.Migrations
{
    /// <inheritdoc />
    public partial class raselvaigrade : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Grade",
                table: "ResultsSheets",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Grade",
                table: "ResultsSheets");
        }
    }
}
