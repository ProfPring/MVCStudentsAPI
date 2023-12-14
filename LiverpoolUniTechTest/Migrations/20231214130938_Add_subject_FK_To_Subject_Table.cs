using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LiverpoolUniTechTest.Migrations
{
    /// <inheritdoc />
    public partial class Add_subject_FK_To_Subject_Table : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "SubjectId",
                table: "Students",
                type: "int",
                nullable: true,
                
                defaultValue: 0);

            migrationBuilder.AddForeignKey("FK_SubjectId", "Students", "SubjectId", "Subjects");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SubjectId",
                table: "Students");
        }
    }
}
