using Microsoft.AspNetCore.Mvc;
using SIS_UMS.DatabaseHelper.Interface;

namespace SIS_UMS.Controllers
{
    [Route("application-form")]
    public class ApplicationFormController : Controller
    {
        private readonly IApplicationFormRepository _applicationForm;

        public ApplicationFormController(IApplicationFormRepository applicationForm)
        {
            _applicationForm = applicationForm;
        }

        [HttpGet("all-application-form")]
        public IActionResult GetAllApplicationForm()
        {
            var applicationForms = _applicationForm.GetAllApplicationForms();
            return View(applicationForms);
        }
    }
}
