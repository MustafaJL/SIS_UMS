using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SIS_UMS.DatabaseHelper.Interfaces;
using SIS_UMS.DatabaseHelper.Repositories;
using SIS_UMS.Models;

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

            IEnumerable<block> block = await _blockRepository.GetAllBlocks();

            return View(block);


        }


        [HttpGet("CreateBlock")]
        public async Task<IActionResult> CreateBlock()
        {
            BlockCampusViewModel blockCampusViewModel = new BlockCampusViewModel
            {
                block = new block(),
                campus = await _campusRepository.GetAllCampus()


            };
             return    View(blockCampusViewModel);
        }


        [HttpPost("CreateBlock")]
        [ValidateAntiForgeryToken]
       
        public async Task<IActionResult> CreateBlock(BlockCampusViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                await _blockRepository.CreateBlock(viewModel.block);
                return RedirectToAction("Index"); 
            }

            return View(viewModel);
        }







        [HttpGet("UpdateBlock/{id}")]
        public async Task<IActionResult> UpdateBlock(int id)
        {
            

           

            BlockCampusViewModel viewModel = new BlockCampusViewModel
            {
                block = await _blockRepository.GetBlockById(id),
                campus = await _campusRepository.GetAllCampus()


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
