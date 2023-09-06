using Microsoft.AspNetCore.Mvc;
using SIS_UMS.DatabaseHelper.Interfaces;
using SIS_UMS.DatabaseHelper.Repositories;
using SIS_UMS.Models;

namespace SIS_UMS.Controllers
{
    public class MajorController : Controller
    {
        private readonly ILogger<MajorController> _logger;
        private readonly IDepartmentRepository _departmentRepository;
        private readonly IMajorRepository _majorRepository;

        public MajorController(ILogger<MajorController> logger, IMajorRepository majorRepository, IDepartmentRepository departmentRepository)
        {
            _logger = logger;
            _majorRepository = majorRepository;
            _departmentRepository = departmentRepository;
        }

        // GET: MajorController
        [HttpGet("AllMajors")]
        public ActionResult AllMajors()
        {
            IEnumerable<Major> majors = _majorRepository.GetAllMajors();
            return View(majors);
        }

        // GET: DepartmentController/Read
        [HttpGet("AllMajors/{id}")]
        public IActionResult ShowMajorsInDepartment(int id)
        {
            IEnumerable<Major> majors = _majorRepository.GetAllMajorsInADepartment(id);
            return View(majors);
        }
    }
}
