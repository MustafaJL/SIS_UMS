using SIS_UMS.Models;

namespace SIS_UMS.DatabaseHelper.Interfaces
{
    public interface IFacultyRepository
    {
        bool CreateFaculty(Faculty faculty);
        IEnumerable<Faculty> GetAllFaculties(int campus_id);

        //bool EditFaculty(Faculty faculty);

        //bool DeleteFaculty(int facultyid);
    }
}
