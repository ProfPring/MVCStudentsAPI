using LiverpoolUniTechTest.Data;
using LiverpoolUniTechTest.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NuGet.Packaging.Signing;

namespace LiverpoolUniTechTest.Services
{
    public class StudentsService: IStudentsService
    {
        public async Task<List<StudentDetails>> GetStudents()
        {
            using LiverpoolUniDBContext _context = new LiverpoolUniDBContext();


            var students = await _context.Students.ToListAsync();

            var studentsToReturn = new List<StudentDetails>(); 

            foreach (var student in students) 
            {
                var currentStudent = GetStudentDetailsById(student.Id);
                studentsToReturn.Add(currentStudent);
            }

            return studentsToReturn;
        }

        public async Task<StudentDetails?> GetStudentDetails(int? id)
        {
            using LiverpoolUniDBContext _context = new LiverpoolUniDBContext();
            if (id == null)
            {
                return null;
            }

            var student = await _context.Students
                .FirstOrDefaultAsync(m => m.Id == id);

            var studentToReturn = GetStudentDetailsById(student.Id);

            if (student == null)
            {
                return null;
            }

            return studentToReturn;
        }

        public async Task<Student?> Create(Student student) 
        {
            using LiverpoolUniDBContext _context = new LiverpoolUniDBContext();

            try 
            {
                _context.Add(student);
                await _context.SaveChangesAsync();

                return student;
            }
            catch (Exception ex) 
            {
                //Adding some logging here would work well.
                return null;
            }
        }

        public async Task<Student?> GetStudentById(int? id) 
        {
            
            if (id == null)
            {
                return null;
            }

            using LiverpoolUniDBContext _context = new LiverpoolUniDBContext();
            var student = await _context.Students.FindAsync(id);

            if (student == null)
            {
                return null;
            }

            return student;
        }

        public async Task<bool> EditStudent(Student student) 
        {
            using LiverpoolUniDBContext _context = new LiverpoolUniDBContext();
            try
            {   
                _context.Update(student);
                await _context.SaveChangesAsync();

                return true; 
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!StudentExists(student.Id, _context))
                {
                    return false;
                }
                else
                {
                    throw;
                }
            }
        }

        public async Task<bool> DeleteStudent(int id)
        {
            using LiverpoolUniDBContext _context = new LiverpoolUniDBContext();
            var student = await _context.Students.FindAsync(id);
            if (student != null)
            {
                _context.Students.Remove(student);
                await _context.SaveChangesAsync();
                return true;
            }

            return false;
        }

        private StudentDetails GetStudentDetailsById(int studentId) 
        {
            using LiverpoolUniDBContext _context = new LiverpoolUniDBContext();

            var query = from stu in _context.Students
            join stuSub in _context.studentSubject on stu.Id equals stuSub.StudentId
            join subject in _context.Subjects on stuSub.SubjectId equals subject.Id
            where stu.Id == studentId
            select new StudentDetails
            {
                Id = stu.Id,
                FirstName = stu.FirstName,
                LastName = stu.LastName,
                dob = stu.dob,
                YearOfStudy = stu.YearOfStudy,
                Subject = subject.Subject
            };

            var currentStudents = query.ToList();
            if (currentStudents != null && currentStudents.Count != 0)
            {
                string concatenatedSubjects = string.Join(", ", currentStudents.Select(s => s.Subject));
                var student = currentStudents.FirstOrDefault();

                student.Subject = concatenatedSubjects;

                return student;
            }

            return new StudentDetails();
        }

        private bool StudentExists(int id, LiverpoolUniDBContext context)
        {
            return context.Students.Any(e => e.Id == id);
        }
    }
}
