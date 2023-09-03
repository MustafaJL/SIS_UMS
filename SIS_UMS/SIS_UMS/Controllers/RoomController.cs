using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SIS_UMS.DatabaseHelper.Interfaces;
using SIS_UMS.DatabaseHelper.Repositories;
using SIS_UMS.Models;

namespace SIS_UMS.Controllers
{
    [Route("Room")]
    public class RoomController : Controller
    {

        private readonly ILogger<RoomController> _logger;
        private readonly IRoomRepository _roomRepository;
        private readonly IBlockRepository _blockRepository;

        public RoomController(ILogger<RoomController> logger, IRoomRepository roomRepository, IBlockRepository blockRepository)
        {
            _logger = logger;
            _roomRepository = roomRepository;
            _blockRepository = blockRepository;
        }

        [HttpGet("Index")]
        public async Task<IActionResult> Index()
        {

            IEnumerable<room> room = await _roomRepository.GetAllRoom();

            return View(room);


        }


        [HttpGet("CreateRoom")]
        public async Task<IActionResult> CreateRoom()
        {
            RoomBlockViewModel roomBlockViewModel = new RoomBlockViewModel
            {
                room = new room(),
                block = await _blockRepository.GetAllBlocks()


            };
            return View(roomBlockViewModel);
        }

        [HttpPost("CreateRoom")]
        [ValidateAntiForgeryToken]

        public async Task<IActionResult> CreateRoom(RoomBlockViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
              await  _roomRepository.CreateRoom(viewModel.room);
                return RedirectToAction("Index");
            }

            return View(viewModel);
        }





        //[HttpGet("{id}")]
        //public async Task<IActionResult> GetRoomById(int id)
        //{

        //    try
        //    {
        //        var room = await _roomRepository.GetRoomById(id);

        //        if (room == null)
        //        {
        //            return NotFound();
        //        }

        //        return Ok(room);
        //    }
        //    catch (Exception)
        //    {
        //        return StatusCode(StatusCodes.Status500InternalServerError, "Error retrieving room");
        //    }
        //}

        [HttpGet("UpdateRoom/{id}")]
        public async Task<IActionResult> UpdateRoom(int id)
        {

            RoomBlockViewModel roomBlockViewModel = new RoomBlockViewModel
            {
                room = await _roomRepository.GetRoomById(id),
            block = await _blockRepository.GetAllBlocks()


            };
            return View(roomBlockViewModel);
           
         
          

        }



        [HttpPost("UpdateRoom/{id}")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> UpdateRoom(int id, room room)
        {
            if (id != room.room_id)
            {
                return NotFound(); // ID mismatch
            }

            if (ModelState.IsValid)
            {
                // Call a method to update the room in the repository
                await _roomRepository.UpdateRoom(room);

                // Redirect to a page to show the updated room or return to the room list
                return RedirectToAction("Index"); // Replace with the appropriate action
            }

            return View(room);
        }


        public async Task<IActionResult> DeleteRoom(int id)
        {
            var room = await _roomRepository.GetRoomById(id);
            await _roomRepository.DeleteRoom(room);
            return RedirectToAction("Index");
        }
    }
}
