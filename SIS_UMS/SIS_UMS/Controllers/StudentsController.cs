using Microsoft.AspNetCore.Mvc;
using SIS_UMS.DatabaseHelper.Interface;

namespace SIS_UMS.Controllers
{
    [Route("students")]
    public class StudentsController : Controller
    {
        private readonly IStudentRepository _studentRepository;

        public StudentsController(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }

        // GET: students/student-courses
        [HttpGet("student-courses")]
        public IActionResult GetAllStudentCourses()
        {
            var studentsCourse = _studentRepository.GetAllStudentCourses();
            return View(studentsCourse);

        }
    }
}
