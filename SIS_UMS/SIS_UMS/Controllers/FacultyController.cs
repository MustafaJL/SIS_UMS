using Microsoft.AspNetCore.Mvc;
using SIS_UMS.DatabaseHelper.Interfaces;
using SIS_UMS.DatabaseHelper.Repositories;
using SIS_UMS.Models;

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

        // GET: FacultyController
        [HttpGet("AllFaculties/{id}")]
        public IActionResult ShowFaculties(int id)
        {
            IEnumerable<Faculty> faculties = _facultyRepository.GetAllFaculties(id);
            return View(faculties);
        }

        // GET: FacultyController/Create
        [HttpGet("CreateFaculty")]
        public IActionResult CreateFaculty()
        {
            return View();
        }
    }
}
