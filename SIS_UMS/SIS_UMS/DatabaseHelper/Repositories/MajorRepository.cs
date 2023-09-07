using MySqlConnector;
using SIS_UMS.DatabaseHelper.Interfaces;
using SIS_UMS.Models;
using System.Data;

namespace SIS_UMS.DatabaseHelper.Repositories
{
    public class MajorRepository: IMajorRepository
    {
        private readonly string _connectionString;
        private readonly IConfiguration _configuration;
        public MajorRepository(IConfiguration configuration)
        {
            _configuration = configuration;
            _connectionString = _configuration.GetConnectionString("Default")
                ?? throw new InvalidOperationException("The 'Default' connection string is missing in configuration.");
        }

        public IEnumerable<Major> GetAllMajors()
        {
            List<Major> majors = new();

            using MySqlConnection connection = new(_connectionString);
            connection.Open();

            using MySqlCommand command = new("get_all_majors", connection);
            command.CommandType = CommandType.StoredProcedure;


            using MySqlDataReader reader = command.ExecuteReader();

            // Convert the table to a list of type User
            while (reader.Read())
            {
                majors.Add(new Major
                {
                    major_id = reader.GetInt32("major_id"),
                    department_id = reader.GetInt32("department_id"),
                    department_name = reader.GetString("department_name"),
                    major_name = reader.GetString("major_name"),
                    university_requirements=reader.GetInt32("university_requirements"),
                    department_requirements=reader.GetInt32("department_requirements"),
                    concentration_requirements= reader.GetInt32("concentration_requirements"),
                    elective_requirements= reader.GetInt32("elective_requirements")
                });
            }

            connection.Close();
            return majors;
        }
        public IEnumerable<Major> GetAllMajorsInADepartment(int department_id)
        {
            List<Major> majors = new();

            using MySqlConnection connection = new(_connectionString);
            connection.Open();

            using MySqlCommand command = new("show_majors_in_a_department", connection);
            command.CommandType = CommandType.StoredProcedure;

            command.Parameters.AddWithValue("@p_department_id", department_id);

            using MySqlDataReader reader = command.ExecuteReader();

            // Convert the table to a list of type User
            while (reader.Read())
            {
                majors.Add(new Major
                {
                    major_id = reader.GetInt32("major_id"),
                    major_name = reader.GetString("major_name"),
                    department_id = reader.GetInt32("department_id"),
                    department_name = reader.GetString("department_name"),
                    university_requirements = reader.GetInt32("university_requirements"),
                    department_requirements = reader.GetInt32("department_requirements"),
                    concentration_requirements = reader.GetInt32("concentration_requirements"),
                    elective_requirements = reader.GetInt32("elective_requirements")
                });
            }

            connection.Close();

            return majors;
        }

        public async Task<bool> DeleteMajor(int majorid)
        {
            using MySqlConnection connection = new(_connectionString);
            await connection.OpenAsync();

            using MySqlCommand command = new("delete_major", connection);
            command.CommandType = CommandType.StoredProcedure;

            command.Parameters.AddWithValue("@p_major_id", majorid);

            command.ExecuteNonQuery();
            connection.Close();
            return true;
        }

        public void CreateMajor(int department_id, string major_name, int university_requirements, int department_requirements,int elective_requirements, int concentration_requirements)
        {
            using MySqlConnection connection = new(_connectionString);
            connection.Open();

            using MySqlCommand command = new("create_major", connection);
            command.CommandType = CommandType.StoredProcedure;


            command.Parameters.AddWithValue("@p_department_id", department_id);
            command.Parameters.AddWithValue("@p_major_name", major_name);
            command.Parameters.AddWithValue("@p_university_requirements", university_requirements);
            command.Parameters.AddWithValue("@p_department_requirements", department_requirements);
            command.Parameters.AddWithValue("@p_elective_requirements", elective_requirements);
            command.Parameters.AddWithValue("@p_concentration_requirements", concentration_requirements);

            command.ExecuteNonQuery();
            connection.Close();
        }

    }
}
