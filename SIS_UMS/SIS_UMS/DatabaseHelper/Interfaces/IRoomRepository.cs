using SIS_UMS.Models;

namespace SIS_UMS.DatabaseHelper.Interfaces
{
    public interface IRoomRepository
    {

        /// Retrieve all room from the repository.

        Task<IEnumerable<room>> GetAllRoom();
        Task<room> GetRoomById(int roomId);


        /// Creates a new room .

        /// <param name="name">The name of the user.</param>
        /// <param name="age">The age of the user.</param>
        Task CreateRoom(room c);

        Task UpdateRoom(room c);


        Task DeleteRoom(room c);


    }
}
