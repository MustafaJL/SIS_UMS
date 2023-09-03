using Microsoft.AspNetCore.Mvc;
using SIS_UMS.DatabaseHelper.Interface;
using SIS_UMS.Models;

namespace SIS_UMS.Controllers
{
    /// <summary>
    /// Controller for managing application forms.
    /// </summary>

    [Route("application-form")]
    public class ApplicationFormController : Controller
    {
        private readonly IApplicationFormRepository _applicationForm;

        /// <summary>
        /// Initializes a new instance of the <see cref="ApplicationFormController"/> class.
        /// </summary>
        /// <param name="applicationForm">The application form repository.</param>
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
        [HttpPost("create-new-applicationForm")]
        public IActionResult CreateApplicationForm(ApplicationForm applicationForm)
        {

            if (ModelState.IsValid)
            {
                _applicationForm.CreateApplicationForm(applicationForm.OfficeName, applicationForm.StudentId, applicationForm.ApplicationType,
                applicationForm.Status, applicationForm.AdditionalApplicationDetails);
            }
            return RedirectToAction("GetAllApplicationForm");
        }


        // Get: application-form/all-application-form
        [HttpGet("all-application-form")]
        public IActionResult GetAllApplicationForm(int page = 1, int pageSize = 5)
        {
            var totalItems = _applicationForm.GetAllApplicationForms().Count();
            var totalPages = (int)Math.Ceiling(totalItems / (double)pageSize);

            var applicationForms = _applicationForm.GetAllApplicationForms()
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToList();

            ViewBag.CurrentPage = page;
            ViewBag.TotalPages = totalPages;

            return View(applicationForms);
        }

        // Get: view/{formId}
        [HttpGet("view/{formId}")]
        public IActionResult GetApplicationFormById(int formId)
        {
            var applicationForm = _applicationForm.GetApplicationFormById(formId);
            return View(applicationForm);
        }

        // POST: application-form/update-application-form/{formId}
        [HttpPost("update-application-form/{formId}")]
        public IActionResult UpdateApplicationForm(int formId, ApplicationForm updatedForm)
        {

            try
            {
                bool isUpdated = _applicationForm.UpdateApplicationForm(updatedForm);
                if (isUpdated)
                {
                    return RedirectToAction("GetAllApplicationForm");
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Failed to update the application form.");
                }
            }
            catch (Exception ex)
            {
                // Log the exception to help identify the issue
                Console.WriteLine("Error: " + ex.Message);
                ModelState.AddModelError(string.Empty, "An error occurred while updating the application form.");
            }


            return View(updatedForm);
        }

        // POST: application-form/delete/{formId}
        [HttpPost("delete/{formId}")]
        public IActionResult DeleteApplicationForm(int formId)
        {
            bool isDeleted = _applicationForm.DeleteApplicationForm(formId);
            return RedirectToAction("GetAllApplicationForm", "ApplicationForm");

        }








    }
}
