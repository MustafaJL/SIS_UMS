using Microsoft.AspNetCore.Mvc;
using NuGet.Protocol.Plugins;
using SIS_UMS.DatabaseHelper.Interfaces;
using SIS_UMS.DatabaseHelper.Repositories;
using SIS_UMS.Models;
using SIS_UMS.Models.View_Model;

namespace SIS_UMS.Controllers
{
    public class FacultyController : Controller
    {
        private readonly ILogger<FacultyController> _logger;
        private readonly IFacultyRepository _facultyRepository;
        private readonly IUserRepository _userRepository;
        private readonly ICampusRepository _campusRepository;
        public FacultyController(ILogger<FacultyController> logger, IFacultyRepository facultyRepository, IUserRepository userRepository, ICampusRepository campusRepository)
        {
            _logger = logger;
            _facultyRepository = facultyRepository;
            _userRepository = userRepository;
            _campusRepository = campusRepository;
        }

        // GET: FacultyController/Read
        [HttpGet("AllFaculties")]
        public IActionResult AllFaculties()
        {
            IEnumerable<Faculty> faculties = _facultyRepository.GetAllFaculties();
            return View(faculties);
        }

        // GET: FacultyController/Read
        [HttpGet("AllFaculties/{id}")]
        public IActionResult ShowFacultiesInACampus(int id)
        {
            IEnumerable<Faculty> faculties = _facultyRepository.GetAllFacultiesInACampus(id);
            return View(faculties);
        }

        // GET: FacultyController/Create
        [HttpGet("CreateFaculty")]
        public IActionResult CreateFaculty()
        {
            FacultyUserCampusViewModel FacultyUserCampus = new FacultyUserCampusViewModel
            {
                faculty = new Faculty(),
                users = _userRepository.GetAllUsers(),
                campuses = _campusRepository.GetAllCampuses()
            };
            return View(FacultyUserCampus);
        }

        // POST: FacultyController/Create
        [HttpPost("CreateFaculty")]
        public IActionResult CreateFaculty(Faculty faculty)
        {
            _facultyRepository.CreateFaculty(faculty.campus_id,faculty.faculty_name,faculty.dean_user_id,faculty.faculty_phone_number,faculty.faculty_uni_email);
            return RedirectToAction("AllFaculties","Faculty");
        }

        // Get: FacultyController/Edit
        [HttpGet("EditFaculty/{id}")]
        public IActionResult EditFaculty(int id)
        {
            FacultyUserCampusViewModel FacultyUserCampus = new FacultyUserCampusViewModel
            {
                faculty =_facultyRepository.GetFaculty(id),
                users = _userRepository.GetAllUsers(),
                campuses = _campusRepository.GetAllCampuses()
            };
            return View(FacultyUserCampus);
        }

        // POST: FacultyController/Edit
        [HttpPost("EditFaculty/{id}")]
        public IActionResult EditFaculty(int id, Faculty faculty)
        {
             _facultyRepository.EditFaculty(id,faculty.campus_id,faculty.faculty_name,faculty.dean_user_id,faculty.faculty_phone_number,faculty.faculty_uni_email);
              return RedirectToAction("AllFaculties");
        }

        public async Task <ActionResult> DeleteFaculty(int id)
        {
            await _facultyRepository.DeleteFaculty(id);
            return RedirectToAction("AllFaculties");
        }
    }
}
