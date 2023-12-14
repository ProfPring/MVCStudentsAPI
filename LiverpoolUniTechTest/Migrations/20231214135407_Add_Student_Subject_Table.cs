using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LiverpoolUniTechTest.Migrations
{
    /// <inheritdoc />
    public partial class Add_Student_Subject_Table : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            // Create Student_Subject Junction Table
            migrationBuilder.CreateTable(
                name: "StudentSubject",
                columns: table => new
                {
                    StudentId = table.Column<int>(nullable: false),
                    SubjectId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Student_Subject", x => new { x.StudentId, x.SubjectId });
                    table.ForeignKey(
                        name: "FK_Student_Subject_Students_student_id",
                        column: x => x.SubjectId,
                        principalTable: "Students",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Student_Subject_Subjects_subject_id",
                        column: x => x.SubjectId,
                        principalTable: "Subjects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
            name: "Student_Subject");
        }
    }
}
