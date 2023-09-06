using SIS_UMS.Models;

namespace SIS_UMS.DatabaseHelper.Interfaces
{
    public interface IMajorRepository
    {
        IEnumerable<Major> GetAllMajorsInADepartment(int department_id);
        IEnumerable<Major> GetAllMajors();
    }
}
