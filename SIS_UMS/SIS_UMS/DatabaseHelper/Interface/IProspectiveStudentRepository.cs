using SIS_UMS.Models;

namespace SIS_UMS.DatabaseHelper.Interface
{
    public interface IProspectiveStudentRepository
    {
        /// <summary>
        /// Adds a prospective student to the tables of user and prospective_student.
        /// </summary>
        void CreateProspectiveStudent();
    }
}
