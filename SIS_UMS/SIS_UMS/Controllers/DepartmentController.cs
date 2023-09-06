using Microsoft.AspNetCore.Mvc;
using SIS_UMS.DatabaseHelper.Interfaces;
using SIS_UMS.DatabaseHelper.Repositories;
using SIS_UMS.Models;
using SIS_UMS.Models.View_Model;

namespace SIS_UMS.Controllers
{
    public class DepartmentController : Controller
    {
        private readonly ILogger<DepartmentController> _logger;
        private readonly IFacultyRepository _facultyRepository;
        private readonly IDepartmentRepository _departmentRepository;

        public DepartmentController(ILogger<DepartmentController> logger, IFacultyRepository facultyRepository,IDepartmentRepository departmentRepository)
        {
            _logger = logger;
            _facultyRepository = facultyRepository;
            _departmentRepository = departmentRepository;
        }

        // GET: DepartmentController
        [HttpGet("AllDepartments")]
        public ActionResult AllDepartments()
        {
            IEnumerable<Department> departments = _departmentRepository.GetAllDepartments();
            return View(departments);
        }

        [HttpGet("CreateDepartment")]
        public IActionResult CreateDepartment()
        {
            DepartmentFacultyViewModel DepartmentFaculty = new DepartmentFacultyViewModel
            {
                faculties = _facultyRepository.GetAllFaculties(),
                department = new Department()
            };
            return View(DepartmentFaculty);
        }

        // POST: DepartmentController/Create
        [HttpPost("CreateDepartment")]
        public IActionResult CreateDepartment(Department department)
        {
            _departmentRepository.CreateDepartment(department.faculty_id, department.department_name, department.department_phone_number, department.department_uni_email);
            return RedirectToAction("AllDepartments", "Department");
        }

        public async Task<IActionResult> DeleteDepartment(int id)
        {
            await _departmentRepository.DeleteDepartment(id);
            return RedirectToAction("AllDepartments");
        }

        // Get: DepartmentController/Edit
        [HttpGet("EditDepartment/{id}")]
        public IActionResult EditDepartment(int id)
        {
            DepartmentFacultyViewModel DepartmentFacultyViewModel = new DepartmentFacultyViewModel
            {
                department = _departmentRepository.GetDepartment(id),
                faculties= _facultyRepository.GetAllFaculties()
            };
            return View(DepartmentFacultyViewModel);
        }

        // POST: DepartmentController/Edit
        [HttpPost("EditDepartment/{id}")]
        public IActionResult EditDepartment(int id, Department department)
        {
            _departmentRepository.EditDepartment(id, department.faculty_id, department.department_name, department.department_phone_number, department.department_uni_email);
            return RedirectToAction("AllDepartments");
        }

        // GET: DepartmentController/Read
        [HttpGet("AllDepartments/{id}")]
        public IActionResult ShowDepartmentsInFaculty(int id)
        {
            IEnumerable<Department> departments = _departmentRepository.GetAllDepartmentsInAFaculty(id);
            return View(departments);
        }
    }
}
