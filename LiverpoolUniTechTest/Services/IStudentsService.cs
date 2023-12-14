using LiverpoolUniTechTest.Models;
using Microsoft.AspNetCore.Components.Web;

namespace LiverpoolUniTechTest.Services
{
    public interface IStudentsService
    {
        public Task<List<StudentDetails>> GetStudents();

        public Task<StudentDetails?> GetStudentDetails(int? id);

        public Task<Student?> Create(Student student);

        public Task<Student?> GetStudentById(int? id);

        Task<bool> EditStudent(Student student);

        Task<bool> DeleteStudent(int id);
    }
}
