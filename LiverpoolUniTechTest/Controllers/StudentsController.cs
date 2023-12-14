using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using LiverpoolUniTechTest.Models;
using LiverpoolUniTechTest.Data;
using LiverpoolUniTechTest.Services;
using System.Security.Cryptography;
using System.Net.WebSockets;

namespace LiverpoolUniTechTest.Controllers
{
    public class StudentsController : Controller
    {
        private readonly IStudentsService _studentsService;

        public StudentsController(IStudentsService studentsService)
        {
            _studentsService = studentsService;
        }

        // GET: Students
        public async Task<IActionResult> Index()
        {
            return View(await _studentsService.GetStudents());
        }

        // GET: Students/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var student = await _studentsService.GetStudentDetails(id);
            if (student == null)
            {
                return NotFound();
            }

            return View(student);
        }


        // GET: Students/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Students/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,FirstName,LastName,dob, YearOfStudy")] Student student)
        {
            if (ModelState.IsValid)
            {
                var createdStudent = await _studentsService.Create(student);
                if (createdStudent != null)
                {
                    return RedirectToAction(nameof(Index));
                }
            }
            return View(student);
        }

        // GET: Students/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            var student = await _studentsService.GetStudentById(id);

            if (student == null)
            {
                return NotFound();
            }
            return View(student);
        }

        // POST: Students/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,FirstName,LastName,dob, YearOfStudy")] Student student)
        {
            if (id != student.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                var editSuccessful = await _studentsService.EditStudent(student);
                if (editSuccessful) 
                {
                    return RedirectToAction(nameof(Index));
                }
                return RedirectToAction(nameof(Index));
            }
            return View(student);
        }

        // GET: Students/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var student = await _studentsService.GetStudentDetails(id);
            if (student == null)
            {
                return NotFound();
            }

            return View(student);
        }

        // POST: Students/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var deleted = await _studentsService.DeleteStudent(id);

            if (deleted)
            {
                return RedirectToAction(nameof(Index));
            }
            return View(nameof(Index));
        }
    }
}
