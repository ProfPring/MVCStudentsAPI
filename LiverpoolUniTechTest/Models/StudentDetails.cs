namespace LiverpoolUniTechTest.Models
{
    public class StudentDetails
    {
        public int Id { get; set; }

        public string FirstName { get; set; } = null!;

        public string LastName { get; set; } = null!;

        public string dob { get; set; } = null!;

        public int YearOfStudy { get; set; }

        public string Subject { get; set; } = null!;
    }
}
