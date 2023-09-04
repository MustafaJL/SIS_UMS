using SIS_UMS.Models;
namespace SIS_UMS.DatabaseHelper.Interface
{
    public interface IFacultyRepository
    {
        /// <summary>
        /// Retrieves all Faculties from the repository.
        /// </summary>
        /// <returns>An enumerable collection of Faculty objects</returns>
        IEnumerable<Faculty> GetAllFaculties();
    }
}
