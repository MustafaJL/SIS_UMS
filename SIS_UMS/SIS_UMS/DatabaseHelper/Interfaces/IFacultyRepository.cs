using SIS_UMS.Models;

namespace SIS_UMS.DatabaseHelper.Interfaces
{
    public interface IFacultyRepository
    {
        Task <bool> CreateFaculty(int campus_id,string faculty_name,int dean_user_id,string faculty_phone_number,string faculty_uni_email);
        IEnumerable<Faculty> GetAllFacultiesInACampus(int campus_id);

        IEnumerable<Faculty> GetAllFaculties();
        Faculty GetFaculty(int facultyid);
        void EditFaculty(int faculty_id,int campus_id, string faculty_name, int dean_user_id, string faculty_phone_number, string faculty_uni_email);

        Task<bool> DeleteFaculty(int id);
    }
}
