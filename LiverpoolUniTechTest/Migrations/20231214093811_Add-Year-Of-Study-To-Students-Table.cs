using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LiverpoolUniTechTest.Migrations
{
    /// <inheritdoc />
    public partial class AddYearOfStudyToStudentsTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {

            migrationBuilder.AddColumn<int>(
                            name: "YearOfStudy",
                            table: "Students", 
                            nullable: false, 
                            defaultValue: 1
                            );
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                          name: "FirstYear",
                          table: "Students"
                          );
        }
    }
}
