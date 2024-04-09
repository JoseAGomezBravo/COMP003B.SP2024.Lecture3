// TODO: reference Models namespace
using COMP003B.SP2024.Lecture3.Models;
using Microsoft.AspNetCore.Mvc;


namespace COMP003B.SP2024.Lecture3.Controllers
{
    public class StudentsController : Controller
    {
        private static List<Student> _students = new List<Student>();
        // GET: Students
        public IActionResult Index()
        {
            return View(_students);
        }
        // GET: Students/Create
        public IActionResult Create()
        {
            return View();
        }
        // POST: Students/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Student student)
        {
            // TODO: add model state validation
            if (ModelState.IsValid) 
            {
                // TODO: check if students already exists
                if(!_students.Any(s => s.Id == student.Id)) 
                {
                    // TODO: add student to list
                    _students.Add(student);
                }

                // TODO: Redirect back to index
                return RedirectToAction(nameof(Index));
            }

            return View();
        }

        // GET: Students/Edit/5
        [HttpGet]
        public IActionResult Edit(int? id)
        {
            // TODO: check if id is null
            if (id == null) 
            {
                return NotFound();
            }
            // TODO: find student by id
            var student = _students.FirstOrDefault(p => p.Id == id);

            //TODO: check again if student is null after searching the list
            if (student == null) 
            {
                return NotFound();
            }

            //TODO: return student to view
            return View(student);
        }

        // POST: Students/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int? id, Student student)
        {
            // TODO: check if id is the same as student id
            if (id != student.Id) 
            {
                return NotFound();
            }

            // TODO: check if model state is valid
            if (ModelState.IsValid)
            {
                // TODO: search for student in list
                var existingStudent = _students.FirstOrDefault(s => s.Id == student.Id);

                // TODO: check if student found
                if (existingStudent != null) 
                {
                    // TODO: update student details
                    existingStudent.Name = student.Name;
                    existingStudent.Age = student.Age;
                }

                // TODO: redirect back to index
                return RedirectToAction(nameof(Index));
            }

            return View(student);
        }


    }
}
