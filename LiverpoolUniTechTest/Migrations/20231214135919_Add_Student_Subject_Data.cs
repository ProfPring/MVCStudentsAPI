using LiverpoolUniTechTest.Models;
using Microsoft.EntityFrameworkCore.Migrations;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;

#nullable disable

namespace LiverpoolUniTechTest.Migrations
{
    /// <inheritdoc />
    public partial class Add_Student_Subject_Data : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("INSERT INTO StudentSubject(StudentID, SubjectID) VALUES" +
            " (1, 1), (1, 4)," +
            " (2, 1), (2, 4), " +
            "(3, 1), (3, 4), " +
            "(4, 1), (4, 4), " +
            "(5, 1), (5, 4), " +

            "(6, 2), " +
            "(7, 2), " +
            "(8, 2), " +
            "(9, 2), " +
            "(10, 2), " +

            "(11, 4), " +
            "(12, 4), " +
            "(13, 4), " +
            "(14, 4), " +
            "(15, 4), "  +

            "(15, 5), (15, 3), " +
            "(16, 5), (16, 3), " +
            "(17, 5), (17, 3), " +
            "(18, 5), (18, 3), " +
            "(19, 5), (19, 3), " +
            "(20, 5), (20, 3);");
           ;
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
