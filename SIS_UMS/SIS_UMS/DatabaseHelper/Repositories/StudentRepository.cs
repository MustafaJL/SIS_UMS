using Microsoft.EntityFrameworkCore;
using MySqlConnector;
using SIS_UMS.DatabaseHelper.Interface;
using SIS_UMS.Models;
using System.Data;

namespace SIS_UMS.DatabaseHelper.Repositories
{
    /// <summary>
    /// Repository for managing student-related data.
    /// </summary>
    public class StudentRepository : IStudentRepository
    {
        private readonly string _connectionString;
        private readonly IConfiguration _configuration;

        /// <summary>
        /// Initializes a new instance of the <see cref="StudentRepository"/> class.
        /// </summary>
        /// <param name="configuration">The configuration object providing access to connection strings.</param>
        public StudentRepository(IConfiguration configuration)
        {
            _configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));
            _connectionString = _configuration.GetConnectionString("Default")
                ?? throw new InvalidOperationException("The 'Default' connection string is missing in configuration.");
        }


        /// <inheritdoc/>
        public IEnumerable<StudentCourse> GetAllStudentCourses()
        {
            List<StudentCourse> studentsCourse = new List<StudentCourse>();

            using MySqlConnection connection = new MySqlConnection(_connectionString);
            connection.Open();

            using MySqlCommand command = new MySqlCommand("get_all_student_courses", connection);
            command.CommandType = CommandType.StoredProcedure;

            using MySqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                studentsCourse.Add(new StudentCourse
                {
                    StudentId = reader.GetString("student_id"),
                    CourseName = reader.GetString("course_name"),
                    CourseStatus = reader.GetString("course_status"),
                    CreatedAt = reader.GetDateTime("created_at")
                });
            }

            return studentsCourse;
        }
    }
}
