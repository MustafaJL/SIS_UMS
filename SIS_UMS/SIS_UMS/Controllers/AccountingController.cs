using Microsoft.AspNetCore.Mvc;

namespace SIS_UMS.Controllers
{
    [Route("/")]
    public class AccountingController : Controller
    {
        public IActionResult Accounting()
        {
            return View("AccountingLandingPage");
        }
    }
}
