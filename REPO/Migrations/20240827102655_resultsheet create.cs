using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace REPO.Migrations
{
    /// <inheritdoc />
    public partial class resultsheetcreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ResultsSheets",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Mark = table.Column<int>(type: "int", nullable: false),
                    ClassId = table.Column<int>(type: "int", nullable: false),
                    CourseId = table.Column<int>(type: "int", nullable: false),
                    StudentId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ResultsSheets", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ResultsSheets_ClassLevels_ClassId",
                        column: x => x.ClassId,
                        principalTable: "ClassLevels",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_ResultsSheets_Courses_CourseId",
                        column: x => x.CourseId,
                        principalTable: "Courses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_ResultsSheets_Students_StudentId",
                        column: x => x.StudentId,
                        principalTable: "Students",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ResultsSheets_ClassId",
                table: "ResultsSheets",
                column: "ClassId");

            migrationBuilder.CreateIndex(
                name: "IX_ResultsSheets_CourseId",
                table: "ResultsSheets",
                column: "CourseId");

            migrationBuilder.CreateIndex(
                name: "IX_ResultsSheets_StudentId",
                table: "ResultsSheets",
                column: "StudentId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ResultsSheets");
        }
    }
}
