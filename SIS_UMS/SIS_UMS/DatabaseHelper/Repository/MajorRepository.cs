using MySqlConnector;
using SIS_UMS.DatabaseHelper.Interface;
using SIS_UMS.Models;
using System.Data;

namespace SIS_UMS.DatabaseHelper.Repository
{
    public class MajorRepository : IMajorRepository
    {
        private readonly string _connectionString;
        private readonly IConfiguration _configuration;

        public MajorRepository(IConfiguration configuration)
        {
            _configuration = configuration;
            _connectionString = _configuration.GetConnectionString("Default");
        }

        public IEnumerable<Major> GetAllMajors()
        {
            List<Major> majors = new();

            using MySqlConnection connection = new(_connectionString);
            connection.Open();

            using MySqlCommand command = new("GetAllMajors", connection);
            command.CommandType = CommandType.StoredProcedure;

            using MySqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                majors.Add(new Major
                {
                    MajorId = reader.GetInt32("major_id"),
                    MajorName = reader.GetString("major_name"),
                    DepartmentId = reader.GetInt32("department_id"),
                    UniversityRequirements = reader.GetInt32("university_requirements"),
                    DepartmentRequirements = reader.GetInt32("department_requirements"),
                    ConcentrationRequirements = reader.GetInt32("concnetration_requirements"),
                    ElectiveRequirements = reader.GetInt32("elective_requirements")
                });
            }

            connection.Close();

            return majors;
        }
    }
}
