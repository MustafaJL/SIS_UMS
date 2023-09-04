using SIS_UMS.Models;
namespace SIS_UMS.DatabaseHelper.Interface
{
    public interface IMajorRepository
    {
        /// <summary>
        /// Retrieves all Majors from the repository.
        /// </summary>
        /// <returns>An enumerable collection of Major objects</returns>
        IEnumerable<Major> GetAllMajors();
    }
}
