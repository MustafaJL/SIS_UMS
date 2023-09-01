using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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

        [HttpGet("Index")]
        public async Task<IActionResult> Index()
        {

            IEnumerable<campus> campus = await _campusRepository.GetAllCampus();

            return View(campus);

        
        }


        [HttpGet("CreateCampus")]
        public IActionResult CreateCampus()
        {
            return View();
        }
      
       [HttpPost("CreateCampus")]
       [ValidateAntiForgeryToken]
            public ActionResult CreateCampus(campus campus)
            {
               
                    _campusRepository.CreateCampus(campus);
                    return RedirectToAction("Index");
             
            }




        //[HttpGet("{id}")]
        //public async Task<IActionResult> GetCampusById(int id)
        //{

        //    try
        //    {
        //        var campus = await _campusRepository.GetCampusById(id);

        //        if (campus == null)
        //        {
        //            return NotFound();
        //        }

        //        return Ok(campus);
        //    }
        //    catch (Exception)
        //    {
        //        return StatusCode(StatusCodes.Status500InternalServerError, "Error retrieving campus");
        //    }
        //}

        [HttpGet("UpdateCampus/{id}")]
        public async Task<IActionResult> UpdateCampus(int id)
        {
            var campus = await _campusRepository.GetCampusById(id);
            if (campus == null)
            {
                return NotFound(); // Campus with the specified ID not found
            }

            return View(campus);
        }



        [HttpPost("UpdateCampus/{id}")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> UpdateCampus(int id, campus campus)
        {
            if (id != campus.campus_id)
            {
                return NotFound(); // ID mismatch
            }

            if (ModelState.IsValid)
            {
                // Call a method to update the campus in the repository
                await _campusRepository.UpdateCampus(campus);

                // Redirect to a page to show the updated campus or return to the campus list
                return RedirectToAction("Index"); // Replace with the appropriate action
            }

            return View(campus);
        }

        
        public async Task<IActionResult> DeleteCampus(int id)
        {
            var campus = await _campusRepository.GetCampusById(id);
            await  _campusRepository.DeleteCampus(campus);
            return RedirectToAction("Index");
        }
    }
}
