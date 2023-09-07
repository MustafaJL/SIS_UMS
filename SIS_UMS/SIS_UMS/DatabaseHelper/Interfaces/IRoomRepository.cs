﻿using SIS_UMS.Models;
using SIS_UMS.Models.ViewModels;

namespace SIS_UMS.DatabaseHelper.Interfaces
{
    public interface IRoomRepository
    {

        /// Retrieve all room from the repository.

        Task<IEnumerable<RoomViewModel>> GetAllRoom();
        Task<room> GetRoomById(int roomId);


        /// Creates a new room. 

        /// <param name="name">The name of the user.</param>
        /// <param name="age">The age of the user.</param>
        Task CreateRoom(room c);

        Task UpdateRoom(room c);


        Task DeleteRoom(room c);


    }
}