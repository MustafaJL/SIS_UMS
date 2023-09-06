using SIS_UMS.Models;

namespace SIS_UMS.DatabaseHelper.Interface
{
    public interface ICampusRepository
    {
        /// <summary>
        /// Retrieves all Campuses from the repository.
        /// </summary>
        /// <returns>An enumerable collection of Campus objects</returns>
        IEnumerable<Campus> GetAllCampuses();
    }
}