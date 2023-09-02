using Microsoft.AspNetCore.Mvc;
using SIS_UMS.DatabaseHelper.Interface;
using SIS_UMS.Models;

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

        // Get: application-form/create-new-applicationForm
        [HttpGet("create-new-applicationForm")]
        public ActionResult CreateApplicationForm()
        {
            return View();
        }

        // Get: application-form/create-new-applicationForm
        public IActionResult CreateApplicationForm(ApplicationForm applicationForm)
        {

            _applicationForm.CreateApplicationForm(applicationForm.OfficeName, applicationForm.StudentId, applicationForm.ApplicationDate, applicationForm.ApplicationType,
                applicationForm.Status, applicationForm.ProcessingDate, applicationForm.AdditionalApplicationDetails);

            return View("GetAllApplicationForm", "GetAllApplicationForm");

        }

        // Get: application-form/all-application-form
        [HttpGet("all-application-form")]
        public IActionResult GetAllApplicationForm()
        {
            var applicationForms = _applicationForm.GetAllApplicationForms();
            return View(applicationForms);
        }
    }
}
