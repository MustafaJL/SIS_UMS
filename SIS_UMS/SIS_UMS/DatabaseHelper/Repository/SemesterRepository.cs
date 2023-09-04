using MySqlConnector;
using SIS_UMS.DatabaseHelper.Interface;
using SIS_UMS.Models;
using System.Data;

namespace SIS_UMS.DatabaseHelper.Repository
{
    public class SemesterRepository : ISemesterRepository
    {
        private readonly string _connectionString;
        private readonly IConfiguration _configuration;

        public SemesterRepository(IConfiguration configuration)
        {
            _configuration = configuration;
            _connectionString = _configuration.GetConnectionString("Default");
        }

        public IEnumerable<Semester> GetOpenSemesters()
        {
            List<Semester> semesters = new();

            using MySqlConnection connection = new(_connectionString);
            connection.Open();

            using MySqlCommand command = new("GetOpenSemesters", connection);
            command.CommandType = CommandType.StoredProcedure;

            using MySqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                semesters.Add(new Semester
                {
                    SemesterId = reader.GetInt32("semester_id"),
                    SemesterCodeId = reader.GetInt32("semester_code_id"),
                    AcademicYearId = reader.GetInt32("academic_year_id"),
                    SemesterName = reader.GetString("semester_name"),
                    IsCourseWithdrawWithRefundEndDate = reader.GetBoolean("is_course_withdraw_withrefund_end_date"),
                    IsSemesterWithdrawWithRefundEndDate = reader.GetBoolean("is_semester_withdraw_withrefund_end_date"),
                    IsRegistrationStartDate = reader.GetBoolean("is_registration_start_date"),
                    IsRegistrationEndDate = reader.GetBoolean("is_registration_end_date")
                });
            }

            connection.Close();

            return semesters;
        }
    }
}
