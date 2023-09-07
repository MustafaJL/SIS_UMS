using SIS_UMS.Models;

namespace SIS_UMS.DatabaseHelper.Interfaces
{
    public interface IMajorRepository
    {
        IEnumerable<Major> GetAllMajorsInADepartment(int department_id);
        IEnumerable<Major> GetAllMajors();
        Task<bool> DeleteMajor(int majorid);
        void CreateMajor(int department_id, string major_name, int university_requirements, int department_requirements, int elective_requirements, int concentration_requirements);
    }
}
