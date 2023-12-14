using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace LiverpoolUniTechTest.Models
{
    public class StudentSubject
    {
        [Key]
        public int StudentId { get; set; }

        public int SubjectId { get; set;}
    }
}
