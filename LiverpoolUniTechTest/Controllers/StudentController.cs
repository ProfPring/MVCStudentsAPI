using LiverpoolUniTechTest.Models;
using LiverpoolUniTechTest.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LiverpoolUniTechTest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly IStudentsService _studentsService;

        public StudentController(IStudentsService studentsService)
        {
            _studentsService = studentsService;
        }

        [HttpGet("GetStudents")]
        public async Task<ActionResult> GetStudents()
        {
            var students = await _studentsService.GetStudents();
            if (students != null)
            {
                return Ok(students);
            }

            return BadRequest("There was a problem getting the student");
        }

        [HttpGet("GetStudentById")]
        public async Task<ActionResult> GetStudents([FromRoute] int studentId)
        {
            var student = await _studentsService.GetStudentById(studentId);

            if (student != null) 
            {
                return Ok(student);
            }

            return BadRequest("There was a problem getting the student");
        }


    }
}
