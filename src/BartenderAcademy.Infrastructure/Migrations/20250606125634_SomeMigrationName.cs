using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BartenderAcademy.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class SomeMigrationName : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Enrollment_Course_CourseId",
                table: "Enrollment");

            migrationBuilder.DropForeignKey(
                name: "FK_QuizOption_QuizQuestion_QuizQuestionId",
                table: "QuizOption");

            migrationBuilder.DropForeignKey(
                name: "FK_QuizQuestion_Quiz_QuizId",
                table: "QuizQuestion");

            migrationBuilder.DropPrimaryKey(
                name: "PK_QuizQuestion",
                table: "QuizQuestion");

            migrationBuilder.DropPrimaryKey(
                name: "PK_QuizOption",
                table: "QuizOption");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Enrollment",
                table: "Enrollment");

            migrationBuilder.RenameTable(
                name: "QuizQuestion",
                newName: "QuizQuestions");

            migrationBuilder.RenameTable(
                name: "QuizOption",
                newName: "QuizOptions");

            migrationBuilder.RenameTable(
                name: "Enrollment",
                newName: "Enrollments");

            migrationBuilder.RenameIndex(
                name: "IX_QuizQuestion_QuizId",
                table: "QuizQuestions",
                newName: "IX_QuizQuestions_QuizId");

            migrationBuilder.RenameIndex(
                name: "IX_QuizOption_QuizQuestionId",
                table: "QuizOptions",
                newName: "IX_QuizOptions_QuizQuestionId");

            migrationBuilder.RenameIndex(
                name: "IX_Enrollment_CourseId",
                table: "Enrollments",
                newName: "IX_Enrollments_CourseId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_QuizQuestions",
                table: "QuizQuestions",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_QuizOptions",
                table: "QuizOptions",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Enrollments",
                table: "Enrollments",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Enrollments_Course_CourseId",
                table: "Enrollments",
                column: "CourseId",
                principalTable: "Course",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_QuizOptions_QuizQuestions_QuizQuestionId",
                table: "QuizOptions",
                column: "QuizQuestionId",
                principalTable: "QuizQuestions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_QuizQuestions_Quiz_QuizId",
                table: "QuizQuestions",
                column: "QuizId",
                principalTable: "Quiz",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Enrollments_Course_CourseId",
                table: "Enrollments");

            migrationBuilder.DropForeignKey(
                name: "FK_QuizOptions_QuizQuestions_QuizQuestionId",
                table: "QuizOptions");

            migrationBuilder.DropForeignKey(
                name: "FK_QuizQuestions_Quiz_QuizId",
                table: "QuizQuestions");

            migrationBuilder.DropPrimaryKey(
                name: "PK_QuizQuestions",
                table: "QuizQuestions");

            migrationBuilder.DropPrimaryKey(
                name: "PK_QuizOptions",
                table: "QuizOptions");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Enrollments",
                table: "Enrollments");

            migrationBuilder.RenameTable(
                name: "QuizQuestions",
                newName: "QuizQuestion");

            migrationBuilder.RenameTable(
                name: "QuizOptions",
                newName: "QuizOption");

            migrationBuilder.RenameTable(
                name: "Enrollments",
                newName: "Enrollment");

            migrationBuilder.RenameIndex(
                name: "IX_QuizQuestions_QuizId",
                table: "QuizQuestion",
                newName: "IX_QuizQuestion_QuizId");

            migrationBuilder.RenameIndex(
                name: "IX_QuizOptions_QuizQuestionId",
                table: "QuizOption",
                newName: "IX_QuizOption_QuizQuestionId");

            migrationBuilder.RenameIndex(
                name: "IX_Enrollments_CourseId",
                table: "Enrollment",
                newName: "IX_Enrollment_CourseId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_QuizQuestion",
                table: "QuizQuestion",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_QuizOption",
                table: "QuizOption",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Enrollment",
                table: "Enrollment",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Enrollment_Course_CourseId",
                table: "Enrollment",
                column: "CourseId",
                principalTable: "Course",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_QuizOption_QuizQuestion_QuizQuestionId",
                table: "QuizOption",
                column: "QuizQuestionId",
                principalTable: "QuizQuestion",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_QuizQuestion_Quiz_QuizId",
                table: "QuizQuestion",
                column: "QuizId",
                principalTable: "Quiz",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
