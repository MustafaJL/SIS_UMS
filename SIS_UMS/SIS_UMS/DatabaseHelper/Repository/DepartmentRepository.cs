using MySqlConnector;
using SIS_UMS.DatabaseHelper.Interface;
using SIS_UMS.Models;
using System.Data;

namespace SIS_UMS.DatabaseHelper.Repository
{
    public class DepartmentRepository : IDepartmentRepository
    {
        private readonly string _connectionString;
        private readonly IConfiguration _configuration;

        public DepartmentRepository(IConfiguration configuration)
        {
            _configuration = configuration;
            _connectionString = _configuration.GetConnectionString("Default");
        }

        public IEnumerable<Department> GetAllDepartments()
        {
            List<Department> departments = new();

            using MySqlConnection connection = new(_connectionString);
            connection.Open();

            using MySqlCommand command = new("GetAllDepartments", connection);
            command.CommandType = CommandType.StoredProcedure;

            using MySqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                departments.Add(new Department
                {
                    DepartmentId = reader.GetInt32("department_id"),
                    DepartmentName = reader.GetString("department_name"),
                    DepartmentPhoneNumber = reader.GetString("department_phone_number"),
                    DepartmentUniEmail = reader.GetString("department_uni_email"),
                    FacultyId = reader.GetInt32("faculty_id"),
                });
            }

            connection.Close();

            return departments;
        }
    }
}