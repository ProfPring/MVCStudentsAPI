using Microsoft.VisualBasic;

namespace LiverpoolUniTechTest.Models
{
    public class Student
    {
        public int Id { get; set; }

        public string FirstName { get; set; } = null!;

        public string LastName { get; set; } = null!;

        public string dob { get; set; } = null!;

        public int YearOfStudy { get; set; }
    }
}
