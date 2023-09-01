using Microsoft.AspNetCore.Mvc;

namespace SIS_UMS.Controllers
{
    public class DepartmentController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
