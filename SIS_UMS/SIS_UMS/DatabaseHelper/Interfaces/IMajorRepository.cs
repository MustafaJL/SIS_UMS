using SIS_UMS.Models;

namespace SIS_UMS.DatabaseHelper.Interfaces
{
    public interface IMajorRepository
    {
        IEnumerable<Major> GetAllMajorsInADepartment(int department_id);
        IEnumerable<Major> GetAllMajors();
        Major GetMajorById(int major_id);
        void EditMajor(int major_id, string major_name, int department_id,int university_requirements, int department_requirements, int elective_requirements, int concentration_requirements);
        Task<bool> DeleteMajor(int majorid);
        void CreateMajor(int department_id, string major_name, int university_requirements, int department_requirements, int elective_requirements, int concentration_requirements);
    }
}
