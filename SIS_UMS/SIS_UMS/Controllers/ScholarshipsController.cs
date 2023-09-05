using Microsoft.AspNetCore.Mvc;
using SIS_UMS.DatabaseHelper.Interfaces;
using SIS_UMS.Models;


namespace SIS_UMS.Controllers
{
    public class ScholarshipsController : Controller
    {
        private readonly IScholarshipsRepository _scholarshipsRepository;

        public ScholarshipsController(IScholarshipsRepository scholarshipsRepository)
        {
            _scholarshipsRepository = scholarshipsRepository;
        }

        // GET: Scholarship
        public ActionResult AllScholarships()
        {
            IEnumerable<Scholarships> scholarships = _scholarshipsRepository.GetAllScholarships();
            return View(scholarships);
        }

        // GET: Role/CreateRole
        public ActionResult AddScholarship()
        {
            return View();
        }

        // POST: Role/CreateRole
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddScholarship(Scholarships scholarship)
        {
            try
            {
                _scholarshipsRepository.AddScholarship(scholarship.scholarship_type,scholarship.percentage_in_dollar,scholarship.percentage_in_lebanese);
                return RedirectToAction(nameof(AllScholarships));
            }
            catch
            {
                return View();
            }
        }

         // GET: Role/DeleteScholarship
        public ActionResult DeleteScholarship()
        {
            return View();
        }

        // POST: Role/DeleteScholarship
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteScholarship(Role role)
        {
            try
            {
                _scholarshipsRepository.DeleteScholarship(role.role_id);
                return RedirectToAction(nameof(AllScholarships));
            }
            catch
            {
                return View();
            }
        }

    }
}