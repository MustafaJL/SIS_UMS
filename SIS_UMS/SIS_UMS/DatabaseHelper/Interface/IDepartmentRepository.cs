using SIS_UMS.Models;
namespace SIS_UMS.DatabaseHelper.Interface
{
    public interface IDepartmentRepository
    {
        /// <summary>
        /// Retrieves all Departments from the repository.
        /// </summary>
        /// <returns>An enumerable collection of Department objects</returns>
        IEnumerable<Department> GetAllDepartments();
    }
}
