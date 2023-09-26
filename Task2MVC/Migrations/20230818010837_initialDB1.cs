using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Task2MVC.Migrations
{
    /// <inheritdoc />
    public partial class initialDB1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CrsResults_Courses_CourseID",
                table: "CrsResults");

            migrationBuilder.DropIndex(
                name: "IX_CrsResults_CourseID",
                table: "CrsResults");

            migrationBuilder.DropColumn(
                name: "CourseID",
                table: "CrsResults");

            migrationBuilder.CreateIndex(
                name: "IX_CrsResults_crsid",
                table: "CrsResults",
                column: "crsid");

            migrationBuilder.AddForeignKey(
                name: "FK_CrsResults_Courses_crsid",
                table: "CrsResults",
                column: "crsid",
                principalTable: "Courses",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CrsResults_Courses_crsid",
                table: "CrsResults");

            migrationBuilder.DropIndex(
                name: "IX_CrsResults_crsid",
                table: "CrsResults");

            migrationBuilder.AddColumn<int>(
                name: "CourseID",
                table: "CrsResults",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_CrsResults_CourseID",
                table: "CrsResults",
                column: "CourseID");

            migrationBuilder.AddForeignKey(
                name: "FK_CrsResults_Courses_CourseID",
                table: "CrsResults",
                column: "CourseID",
                principalTable: "Courses",
                principalColumn: "ID");
        }
    }
}
