using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SIS_UMS.DatabaseHelper.Interfaces;
using SIS_UMS.DatabaseHelper.Repositories;
using SIS_UMS.Models;
using SIS_UMS.Models.ViewModels;

namespace SIS_UMS.Controllers
{
    [Route("Block")]
    public class BlockController : Controller
    {

        private readonly ILogger<BlockController> _logger;
        private readonly IBlockRepository _blockRepository;
        private readonly ICampusRepository _campusRepository;


        public BlockController(ILogger<BlockController> logger, IBlockRepository blockRepository, ICampusRepository campusRepository)
        {
            _logger = logger;
            _blockRepository = blockRepository;
            _campusRepository = campusRepository;
        }

        [HttpGet("Index")]
        public async Task<IActionResult> Index()
        {
            // Retrieve the blocks data using your existing repository method
            var blocks = await _blockRepository.GetAllBlocks();

            // Create a list of BlockViewModel and populate it with the data
            var blockViewModels = blocks.Select(block => new BlockViewModel
            {
                block_id = block.block_id,
                campus_id = block.campus_id,
                created_at = block.created_at,
                block_code = block.block_code,
                floor_count = block.floor_count,
                room_count = block.room_count,
                campus_name = block.campus_name,
                // Populate other properties as needed
            }).ToList();

            return View(blockViewModels);
        }



        [HttpGet("CreateBlock")]
        public async Task<IActionResult> CreateBlock()
        {
            BlockCampusViewModel blockCampusViewModel = new BlockCampusViewModel
            {
                block = new block(),
                campus = await _campusRepository.GetAllCampuses()


            };
            return View(blockCampusViewModel);
        }




        [HttpPost("CreateBlock")]
        [ValidateAntiForgeryToken]

        public ActionResult CreateBlock(block block, string action)
        {
            if (ModelState.IsValid)
            {
                _blockRepository.CreateBlock(block);

                if (action == "CreateAndNext")
                {
                    // Redirect to the CreateBlock action in the BlockController
                    return RedirectToAction("CreateRoom", "Room");
                }

                // Redirect to the Index action in the CampusController
                return RedirectToAction("Index");
            }

            return View(block);
        }












        [HttpGet("UpdateBlock/{id}")]
        public async Task<IActionResult> UpdateBlock(int id)
        {




            BlockCampusViewModel viewModel = new BlockCampusViewModel
            {
                block = await _blockRepository.GetBlockById(id),
                campus = await _campusRepository.GetAllCampuses()


            };
            return View(viewModel);


        }



        [HttpPost("UpdateBlock/{id}")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> UpdateBlock(int id, block block)
        {
            if (id != block.block_id)
            {
                return NotFound(); // ID mismatch
            }

            if (ModelState.IsValid)
            {
                // Call a method to update the block in the repository
                await _blockRepository.UpdateBlock(block);

                // Redirect to a page to show the updated block or return to the block list
                return RedirectToAction("Index"); // Replace with the appropriate action
            }

            return View(block);
        }


        public async Task<IActionResult> DeleteBlock(int id)
        {
            var block = await _blockRepository.GetBlockById(id);
            await _blockRepository.DeleteBlock(block);
            return RedirectToAction("Index");
        }
    }
}