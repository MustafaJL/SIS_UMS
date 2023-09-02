using Microsoft.AspNetCore.Mvc;

namespace SIS_UMS.Controllers
{
    [Route("accounting")]
    public class AccountingController : Controller
    {
        [HttpGet("accounting")]
        public IActionResult Accounting()
        {
            return View();
        }
    }
}
