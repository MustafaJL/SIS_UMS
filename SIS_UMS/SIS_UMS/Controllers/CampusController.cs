﻿using Microsoft.AspNetCore.Mvc;
using SIS_UMS.DatabaseHelper.Interfaces;
using SIS_UMS.Models;

namespace SIS_UMS.Controllers
{
    [Route("Campus")]
    public class CampusController : Controller
    {

        private readonly ILogger<CampusController> _logger;
        private readonly ICampusRepository _campusRepository;

        public CampusController(ILogger<CampusController> logger, ICampusRepository campusRepository)
        {
            _logger = logger;
            _campusRepository = campusRepository;
        }

        // GET: CampusController/Create
        [HttpGet("CreateCampus")]
        public IActionResult CreateCampus()
        {
            return View();
        }

        // POST: CampusController/Create
        [HttpPost("CreateCampus")]
        [ValidateAntiForgeryToken]
        public IActionResult CreateCampus(Campus campus)
        {
            try
            {
                bool isSuccess = _campusRepository.CreateCampus(campus.campus_name, campus.campus_address, campus.campus_phone_number, campus.campus_fax, campus.campus_email);
                if (isSuccess)
                {
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    // Handle failure case here, if needed
                    ModelState.AddModelError("", "Failed to create campus.");
                    return View(campus);
                }
            }
            catch
            {
                 return View();
            }
        }

        // GET: CampusController
        [HttpGet("AllCampuses")]
        public ActionResult AllCampuses()
        {
            IEnumerable<Campus> campuses = _campusRepository.GetAllCampuses();
            return View(campuses);
        }

        // GET: CampusController
        [HttpGet("EditCampusDetails/{id}")]
        public ActionResult EditCampusDetails(int id)
        {
            Campus campus=_campusRepository.GetCampus(id);
            return View(campus);
        }

        // POST: CampusController
        [HttpPost("EditCampusDetails/{id}")]
        public ActionResult EditCampusDetails(int id , Campus campus)
        {
            try
            {
                bool isSuccess = _campusRepository.EditCampus(id, campus.campus_name, campus.campus_address, campus.campus_phone_number, campus.campus_fax, campus.campus_email);
                if (isSuccess)
                {
                    return RedirectToAction("AllCampuses");
                }
                else
                {
                    // Handle failure case here, if needed
                    ModelState.AddModelError("", "Name already exists");
                    return View(campus);
                }
            }
            catch
            {
                return View(campus);
            }
        }

        public ActionResult DeleteCampus(int id)
        {
            _campusRepository.DeleteCampus(id);
            return RedirectToAction("AllCampuses");
        }

    }
}