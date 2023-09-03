using Microsoft.AspNetCore.Mvc;

namespace SIS_UMS.Controllers
{
    [Route("Application")]
    public class ApplicationController : Controller
    {
        [HttpGet]
        public IActionResult ApplicantForm()
        {
            return View();
        }
    }
}