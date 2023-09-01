using SIS_UMS.Models;

namespace SIS_UMS.DatabaseHelper.Interfaces
{
    public interface ICampusRepository
    {
        
        /// Retrieve all campus from the repository.
       
        Task <IEnumerable<campus>> GetAllCampus();
        Task<campus>  GetCampusById(int campusId);
        

            /// Creates a new campus .

            /// <param name="name">The name of the user.</param>
            /// <param name="age">The age of the user.</param>
            Task CreateCampus(campus c);

          Task UpdateCampus(campus c);

          
          Task DeleteCampus(campus c);


    }
}
