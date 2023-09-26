using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Task2MVC.Migrations
{
    /// <inheritdoc />
    public partial class fkCrsid : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Instructors_Courses_CourseID",
                table: "Instructors");

            migrationBuilder.RenameColumn(
                name: "CourseID",
                table: "Instructors",
                newName: "CourseId");

            migrationBuilder.RenameIndex(
                name: "IX_Instructors_CourseID",
                table: "Instructors",
                newName: "IX_Instructors_CourseId");

            migrationBuilder.AlterColumn<int>(
                name: "CourseId",
                table: "Instructors",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Instructors_Courses_CourseId",
                table: "Instructors",
                column: "CourseId",
                principalTable: "Courses",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Instructors_Courses_CourseId",
                table: "Instructors");

            migrationBuilder.RenameColumn(
                name: "CourseId",
                table: "Instructors",
                newName: "CourseID");

            migrationBuilder.RenameIndex(
                name: "IX_Instructors_CourseId",
                table: "Instructors",
                newName: "IX_Instructors_CourseID");

            migrationBuilder.AlterColumn<int>(
                name: "CourseID",
                table: "Instructors",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Instructors_Courses_CourseID",
                table: "Instructors",
                column: "CourseID",
                principalTable: "Courses",
                principalColumn: "ID");
        }
    }
}
