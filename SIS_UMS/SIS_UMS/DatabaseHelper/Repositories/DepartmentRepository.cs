using MySqlConnector;
using SIS_UMS.DatabaseHelper.Interfaces;
using SIS_UMS.Models;
using System.Data;

namespace SIS_UMS.DatabaseHelper.Repositories
{
    public class DepartmentRepository : IDepartmentRepository
    {
        private readonly string _connectionString;
        private readonly IConfiguration _configuration;
        public DepartmentRepository(IConfiguration configuration)
        {
            _configuration = configuration;
            _connectionString = _configuration.GetConnectionString("Default")
                ?? throw new InvalidOperationException("The 'Default' connection string is missing in configuration.");
        }

        public IEnumerable<Department> GetAllDepartments()
        {
            List<Department> departments = new();

            using MySqlConnection connection = new(_connectionString);
            connection.Open();

            using MySqlCommand command = new("get_all_departments", connection);
            command.CommandType = CommandType.StoredProcedure;


            using MySqlDataReader reader = command.ExecuteReader();

            // Convert the table to a list of type User
            while (reader.Read())
            {
                departments.Add(new Department
                {
                    department_id = reader.GetInt32("department_id"),
                    faculty_id = reader.GetInt32("faculty_id"),
                    faculty_name= reader.GetString("faculty_name"),
                    department_name = reader.GetString("department_name"),
                    department_phone_number = reader.GetString("department_phone_number"),
                    department_uni_email = reader.GetString("department_uni_email")
                });
            }

            connection.Close();
            return departments;
        }

        public void CreateDepartment(int faculty_id, string department_name, string department_phone_number, string department_uni_email)
        {
                using MySqlConnection connection = new(_connectionString);
                connection.Open();

                using MySqlCommand command = new("create_department", connection);
                command.CommandType = CommandType.StoredProcedure;
                

                command.Parameters.AddWithValue("@p_faculty_id", faculty_id);
                command.Parameters.AddWithValue("@p_department_name", department_name);
                command.Parameters.AddWithValue("@p_department_phone_number", department_phone_number);
                command.Parameters.AddWithValue("@p_department_uni_email", department_uni_email);

                command.ExecuteNonQuery();
                connection.Close();
        }

        public async Task<bool> DeleteDepartment(int id)
        {
            using MySqlConnection connection = new(_connectionString);
            await connection.OpenAsync();

            using MySqlCommand command = new("delete_department", connection);
            command.CommandType = CommandType.StoredProcedure;

            command.Parameters.AddWithValue("@p_department_id", id);

            command.ExecuteNonQuery();
            connection.Close();
            return true;
        }

        public Department GetDepartment(int departmentid)
        {
            using MySqlConnection connection = new(_connectionString);
            connection.Open();

            using MySqlCommand command = new("get_department_by_id", connection);
            command.CommandType = CommandType.StoredProcedure;

            command.Parameters.AddWithValue("@p_department_id", departmentid);
            command.ExecuteNonQuery();

            using MySqlDataReader reader = command.ExecuteReader();
            reader.Read();

            Department department = new Department
            {
                faculty_id = reader.GetInt32("faculty_id"),
                faculty_name = reader.GetString("faculty_name"),
                department_name = reader.GetString("department_name"),
                department_phone_number = reader.GetString("department_phone_number"),
                department_uni_email = reader.GetString("department_uni_email")
            };
            connection.Close();
            return department;
        }

        public void EditDepartment(int department_id, int faculty_id, string department_name, string department_phone_number, string department_uni_email)
        {
            using MySqlConnection connection = new(_connectionString);
            connection.Open();

            using MySqlCommand command = new("edit_department", connection);
            command.CommandType = CommandType.StoredProcedure;

            command.Parameters.AddWithValue("@p_department_id", department_id);
            command.Parameters.AddWithValue("@p_faculty_id", faculty_id);
            command.Parameters.AddWithValue("@p_department_name", department_name);
            command.Parameters.AddWithValue("@p_department_phone_number", department_phone_number);
            command.Parameters.AddWithValue("@p_department_uni_email", department_uni_email);

            command.ExecuteNonQuery();
            connection.Close();
        }

        public IEnumerable<Department> GetAllDepartmentsInAFaculty(int faculty_id)
        {
            List<Department> departments = new();

            using MySqlConnection connection = new(_connectionString);
            connection.Open();

            using MySqlCommand command = new("show_departments_in_a_faculty", connection);
            command.CommandType = CommandType.StoredProcedure;

            command.Parameters.AddWithValue("@p_faculty_id", faculty_id);

            using MySqlDataReader reader = command.ExecuteReader();

            // Convert the table to a list of type User
            while (reader.Read())
            {
                departments.Add(new Department
                {
                    faculty_id = reader.GetInt32("faculty_id"),
                    faculty_name= reader.GetString("faculty_name"),
                    department_id = reader.GetInt32("department_id"),
                    department_name = reader.GetString("department_name"),
                    department_phone_number = reader.GetString("department_phone_number"),
                    department_uni_email = reader.GetString("department_uni_email")
                });
            }

            connection.Close();

            return departments;
        }
    }
}
