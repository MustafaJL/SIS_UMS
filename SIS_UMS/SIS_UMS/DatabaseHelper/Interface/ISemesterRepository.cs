using SIS_UMS.Models;

namespace SIS_UMS.DatabaseHelper.Interface
{
    public interface ISemesterRepository
    {
        /// <summary>
        /// Retrieves all Semesters from the repository.
        /// </summary>
        /// <returns>An enumerable collection of Semester objects</returns>
        IEnumerable<Semester> GetOpenSemesters();
    }
}
