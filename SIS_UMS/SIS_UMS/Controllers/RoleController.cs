using Microsoft.AspNetCore.Mvc;
using SIS_UMS.DatabaseHelper.Interfaces;
using SIS_UMS.Models;


namespace SIS_UMS.Controllers
{
    public class RoleController : Controller
    {
        private readonly IRoleRepository _roleRepository;

        public RoleController(IRoleRepository roleRepository)
        {
            _roleRepository = roleRepository;
        }

        // GET: Role
        public ActionResult AllRoles()
        {
            IEnumerable<Role> roles = _roleRepository.GetAllRoles();
            return View(roles);
        }

        // GET: Role/CreateRole
        public ActionResult CreateRole()
        {
            return View();
        }

        // POST: Role/CreateRole
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateRole(Role role)
        {
            try
            {
                _roleRepository.CreateRole(role.role_name);
                return RedirectToAction(nameof(AllRoles));
            }
            catch
            {
                return View();
            }
        }

        // GET: Role/DeleteRole
        public ActionResult DeleteRole()
        {
            return View();
        }

        // POST: Role/DeleteRole
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteRole(Role role)
        {
            try
            {
                _roleRepository.DeleteRole(role.role_id);
                return RedirectToAction(nameof(AllRoles));
            }
            catch
            {
                return View();
            }
        }



    }
}
