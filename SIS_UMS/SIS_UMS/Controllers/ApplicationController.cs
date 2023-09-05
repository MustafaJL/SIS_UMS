using Microsoft.AspNetCore.Mvc;
using SIS_UMS.DatabaseHelper.Repository;
using SIS_UMS.Models;

namespace SIS_UMS.Controllers
{
    [Route("Application")]
    public class ApplicationController : Controller
    {
        private readonly IConfiguration _configuration;

        public ApplicationController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpGet]
        public IActionResult ApplicantForm()
        {
            CampusRepository cm = new CampusRepository(_configuration);
            FacultyRepository fy = new FacultyRepository(_configuration);
            DepartmentRepository dt = new DepartmentRepository(_configuration);
            MajorRepository mr = new MajorRepository(_configuration);
            SemesterRepository sr = new SemesterRepository(_configuration);
            ApplicationViewModel model = new ApplicationViewModel();
            model.user = new User();
            model.campuses = cm.GetAllCampuses();
            model.faculties = fy.GetAllFaculties();
            model.departments = dt.GetAllDepartments();
            model.majors = mr.GetAllMajors();
            model.semesters = sr.GetOpenSemesters();
            return View(model);
        }
    }
}