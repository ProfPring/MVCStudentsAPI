using LiverpoolUniTechTest.Models;
using Microsoft.EntityFrameworkCore;

namespace LiverpoolUniTechTest.Data
{
    public class LiverpoolUniDBContext : DbContext
    {
        public DbSet<Student> Students { get; set; } = null!;

        public DbSet<SubjectObj> Subjects { get; set; } = null!;

        public DbSet<StudentSubject> studentSubject { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=localhost;Database=liverpoolUniDB;Trusted_Connection=True;TrustServerCertificate=true;");
        }
    }
}
