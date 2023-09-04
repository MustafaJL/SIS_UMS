using MySqlConnector;
using SIS_UMS.DatabaseHelper.Interface;
using SIS_UMS.Models;
using System.Data;

namespace SIS_UMS.DatabaseHelper.Repository
{
    public class FacultyRepository : IFacultyRepository
    {
        private readonly string _connectionString;
        private readonly IConfiguration _configuration;

        public FacultyRepository(IConfiguration configuration)
        {
            _configuration = configuration;
            _connectionString = _configuration.GetConnectionString("Default");
        }

        public IEnumerable<Faculty> GetAllFaculties()
        {
            List<Faculty> faculties = new();

            using MySqlConnection connection = new(_connectionString);
            connection.Open();

            using MySqlCommand command = new("GetAllFaculties", connection);
            command.CommandType = CommandType.StoredProcedure;

            using MySqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                faculties.Add(new Faculty
                {
                    FacultyId = reader.GetInt32("faculty_id"),
                    CampusId = reader.GetInt32("campus_id"),
                    FacultyName = reader.GetString("faculty_name"),
                    FacultyPhoneNumber = reader.GetString("faculty_phone_number"),
                    FacultyUniEmail = reader.GetString("faculty_uni_email")
                });
            }

            connection.Close();

            return faculties;
        }
    }
}
