using MySqlConnector;
using SIS_UMS.DatabaseHelper.Interface;
using SIS_UMS.Models;
using System.Data;

namespace SIS_UMS.DatabaseHelper.Repository
{
    public class CampusRepository : ICampusRepository
    {
        private readonly string _connectionString;
        private readonly IConfiguration _configuration;

        public CampusRepository(IConfiguration configuration)
        {
            _configuration = configuration;
            _connectionString = _configuration.GetConnectionString("Default");
        }

        public IEnumerable<Campus> GetAllCampuses()
        {
            List<Campus> campuses = new();

            using MySqlConnection connection = new(_connectionString);
            connection.Open();

            using MySqlCommand command = new("GetAllCampuses", connection);
            command.CommandType = CommandType.StoredProcedure;

            using MySqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                campuses.Add(new Campus
                {
                    CampusId = reader.GetInt32("campus_id"),
                    CampusName = reader.GetString("campus_name"),
                    CampusAddress = reader.GetString("campus_address"),
                    CampusPhoneNumber = reader.GetString("campus_phone_number"),
                    CampusFax = reader.GetString("campus_fax"),
                    CampusEmail = reader.GetString("campus_email")
                });
            }

            connection.Close();

            return campuses;
        }
    }
}
