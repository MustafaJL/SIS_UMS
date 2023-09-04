using Microsoft.AspNetCore.Mvc;
using SIS_UMS.DatabaseHelper.Interface;
using SIS_UMS.Models;

namespace SIS_UMS.Controllers
{
    /// <summary>
    /// Controller for managing financial agreements.
    /// </summary>

    [Route("financial-agreement")]
    public class FinancialAgreementController : Controller
    {
        private readonly IFinancialAgreementRepository _financialAgreement;

        /// <summary>
        /// Initializes a new instance of the <see cref="FinancialAgreementController"/> class.
        /// </summary>
        /// <param name="financialAgreement">The financial Agreement repository.</param>
        public FinancialAgreementController(IFinancialAgreementRepository financialAgreement)
        {
            _financialAgreement = financialAgreement;
        }

        // Get: financial-application/create-new-financial-application
        [HttpGet("create-new-financial-application")]
        public ActionResult CreateFinancialAgreement()
        {
            return View();
        }

        // Get: financial-application/create-new-financial-application
        [HttpPost("create-new-financial-application")]
        public IActionResult CreateFinancialAgreement(FinancialAgreement financialAgreement)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _financialAgreement.CreateFinancialAgreement(
                        financialAgreement.OfficeName,
                        financialAgreement.StudentId,
                        financialAgreement.AgreementDate,
                        financialAgreement.AgreementDetails,
                        financialAgreement.StartDate,
                        financialAgreement.EndDate,
                        financialAgreement.IsActive
                    );
                }
                return RedirectToAction("GetAllFinancialAgreement");
            }
            catch (Exception ex)
            {
                Console.WriteLine("CreateFinancialAgreement(): An error occurred while creating the financial agreement: " + ex.Message);
            }

            return RedirectToAction("GetAllFinancialAgreement");
        }


        // Get: financial-agreement/all-financial-agreement
        [HttpGet("all-financial-agreement")]
        public IActionResult GetAllFinancialAgreement(int page = 1, int pageSize = 5)
        {
            var financialAgreements = _financialAgreement.GetAllFinancialAgreements()
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToList();

            var totalItems = _financialAgreement.GetAllFinancialAgreements().Count();
            var totalPages = (int)Math.Ceiling(totalItems / (double)pageSize);

            ViewBag.CurrentPage = page;
            ViewBag.TotalPages = totalPages;

            return View(financialAgreements);
        }

        // Get: view-financial-agreement/{formId}
        [HttpGet("view-financial-agreement/{financialAgreementId}")]
        public IActionResult GetFinancialAgreementById(int financialAgreementId)
        {
            var financialAgreement = _financialAgreement.GetFinancialAgreementById(financialAgreementId);
            return View(financialAgreement);
        }

        // Get: update-financial-agreement/{financialAgreementId}
        [HttpGet("update-financial-agreement/{financialAgreementId}")]
        public IActionResult UpdateFinancialAgreement(int financialAgreementId)
        {
            var financialAgreement = _financialAgreement.GetFinancialAgreementById(financialAgreementId);
            return View(financialAgreement);
        }

        // POST: update-financial-agreement/{financialAgreementId}
        [HttpPost("update-financial-agreement/{financialAgreementId}")]
        public IActionResult UpdateFinancialAgreement(int financialAgreementId, FinancialAgreement financialAgreement)
        {

            try
            {
                bool isUpdated = _financialAgreement.UpdateFinancialAgreement(financialAgreement);
                if (isUpdated)
                {
                    return RedirectToAction("GetAllFinancialAgreement");
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Failed to update the application form.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
                ModelState.AddModelError(string.Empty, "An error occurred while updating the application form.");
            }


            return View(financialAgreement);
        }

        // POST: application-form/delete/{formId}
        [HttpPost("delete/{financialAgreementId}")]
        public IActionResult DeleteFinancialAgreement(int financialAgreementId)
        {
            bool isDeleted = _financialAgreement.DeleteFinancialAgreement(financialAgreementId);
            return RedirectToAction("GetAllFinancialAgreement", "FinancualAgreement");

        }
    }
}
