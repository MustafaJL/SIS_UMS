using Microsoft.AspNetCore.Mvc;
using SIS_UMS.DatabaseHelper.Interfaces;
using SIS_UMS.DatabaseHelper.Repositories;
using SIS_UMS.Models;
using SIS_UMS.Models.View_Model;

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

        public async Task<IActionResult> DeleteMajor(int id)
        {
            await _majorRepository.DeleteMajor(id);
            return RedirectToAction("AllMajors");
        }

        [HttpGet("CreateMajor")]
        public IActionResult CreateMajor()
        {
            MajorDepartmentViewModel MajorDepartmentViewModel = new MajorDepartmentViewModel
            {
                major = new Major(),
                departments= _departmentRepository.GetAllDepartments()
            };
            return View(MajorDepartmentViewModel);
        }

        // POST: DepartmentController/Create
        [HttpPost("CreateMajor")]
        public IActionResult CreateMajor(Major major)
        {
            _majorRepository.CreateMajor(major.department_id, major.major_name, major.university_requirements, major.department_requirements,major.elective_requirements,major.concentration_requirements);
            return RedirectToAction("AllMajors");
        }

        [HttpGet("EditMajor/{id}")]
        public IActionResult EditMajor(int id)
        {
            MajorDepartmentViewModel MajorDepartmentViewModel = new MajorDepartmentViewModel
            {
                major = _majorRepository.GetMajorById(id),
                departments = _departmentRepository.GetAllDepartments()
            };
            return View(MajorDepartmentViewModel);
        }


        // POST: MajorController/Edit
        [HttpPost("EditMajor/{id}")]
        public IActionResult EditMajor(int id, Major Major)
        {
            _majorRepository.EditMajor(id,Major.major_name,Major.department_id,Major.university_requirements,Major.department_requirements,Major.elective_requirements,Major.concentration_requirements);
            return RedirectToAction("AllMajors");
        }
    }
}
