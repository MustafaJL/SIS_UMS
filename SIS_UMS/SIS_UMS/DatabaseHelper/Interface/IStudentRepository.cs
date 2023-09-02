using SIS_UMS.Models;

namespace SIS_UMS.DatabaseHelper.Interface
{
    /// <summary>
    /// Represents a repository for managing student-related data.
    /// </summary>
    public interface IStudentRepository
    {
        /// <summary>
        /// Retrieves a list of all student courses.
        /// </summary>
        /// <returns>An IEnumerable of StudentCourse objects representing the student courses.</returns>
        IEnumerable<StudentCourse> GetAllStudentCourses();
    }
}
