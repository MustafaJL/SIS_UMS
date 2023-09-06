using Microsoft.AspNetCore.Mvc;
using MySqlConnector;
using NuGet.Protocol.Plugins;
using SIS_UMS.DatabaseHelper.Interfaces;
using SIS_UMS.Models;
using System.Data;

namespace SIS_UMS.DatabaseHelper.Repositories
{
    public class FacultyRepository: IFacultyRepository
    {
        private readonly string _connectionString;
        private readonly IConfiguration _configuration;

        public FacultyRepository(IConfiguration configuration)
        {
            _configuration = configuration;
            _connectionString = _configuration.GetConnectionString("Default")
                ?? throw new InvalidOperationException("The 'Default' connection string is missing in configuration.");
        }

        public IEnumerable<Faculty> GetAllFaculties()
        {
            List<Faculty> faculties = new();

            using MySqlConnection connection = new(_connectionString);
            connection.Open();

            using MySqlCommand command = new("get_all_faculties", connection);
            command.CommandType = CommandType.StoredProcedure;


            using MySqlDataReader reader = command.ExecuteReader();

            // Convert the table to a list of type User
            while (reader.Read())
            {
                faculties.Add(new Faculty
                {
                    faculty_id = reader.GetInt32("faculty_id"),
                    campus_id = reader.GetInt32("campus_id"),
                    campus_name = reader.GetString("campus_name"),
                    faculty_name = reader.GetString("faculty_name"),
                    faculty_phone_number = reader.GetString("faculty_phone_number"),
                    faculty_uni_email = reader.GetString("faculty_uni_email"),
                    dean_user_id = reader.GetInt32("dean_user_id"),
                    dean_user_name = reader.GetString("dean_name")
                });
            }

            connection.Close();

            return faculties;
        }

        public IEnumerable<Faculty> GetAllFacultiesInACampus(int campus_id)
        {
            List<Faculty> faculties = new(); 

            using MySqlConnection connection = new(_connectionString);
            connection.Open();

            using MySqlCommand command = new("show_faculties_in_a_campus", connection);
            command.CommandType = CommandType.StoredProcedure;

            command.Parameters.AddWithValue("@p_campus_id", campus_id);

            using MySqlDataReader reader = command.ExecuteReader();

            // Convert the table to a list of type User
            while (reader.Read())
            {
                faculties.Add(new Faculty
                {
                    faculty_id = reader.GetInt32("faculty_id"),
                    campus_id = reader.GetInt32("campus_id"),
                    campus_name=reader.GetString("campus_name"),
                    faculty_name = reader.GetString("faculty_name"),
                    faculty_phone_number = reader.GetString("faculty_phone_number"),
                    faculty_uni_email = reader.GetString("faculty_uni_email"),
                    dean_user_id=reader.GetInt32("dean_user_id"),
                    dean_user_name=reader.GetString("dean_name")
                });
            }

            connection.Close();

            return faculties;
        }

        public bool CreateFaculty(int campus_id,string faculty_name,int dean_user_id,string faculty_phone_number,string faculty_uni_email)
        {
            using MySqlConnection connection = new(_connectionString);
            connection.Open();

            using MySqlCommand command = new("create_faculty", connection);
            command.CommandType = CommandType.StoredProcedure;

            command.Parameters.AddWithValue("@p_campus_id", campus_id);
            command.Parameters.AddWithValue("@p_dean_user_id", dean_user_id);
            command.Parameters.AddWithValue("@p_faculty_name",faculty_name);
            command.Parameters.AddWithValue("@p_faculty_phone_number", faculty_phone_number);
            command.Parameters.AddWithValue("@p_faculty_uni_email", faculty_uni_email);

            command.Parameters.Add(new MySqlParameter("@added_successfully", MySqlDbType.Bit));
            command.Parameters["@added_successfully"].Direction = ParameterDirection.Output;
            command.ExecuteNonQuery();
            bool result = Convert.ToBoolean(command.Parameters["@added_successfully"].Value);
            connection.Close();
            return result;
        }

        public async  Task<bool> DeleteFaculty(int id)
        {
            using MySqlConnection connection = new(_connectionString);
            await connection.OpenAsync();

            using MySqlCommand command = new("delete_faculty", connection);
            command.CommandType = CommandType.StoredProcedure;

            command.Parameters.AddWithValue("@p_faculty_id", id);
            command.ExecuteNonQuery();
            connection.Close();
            return true;
        }

        public void EditFaculty(int faculty_id,int campus_id, string faculty_name, int dean_user_id, string faculty_phone_number, string faculty_uni_email)
        {
            using MySqlConnection connection = new(_connectionString);
            connection.Open();

            using MySqlCommand command = new("edit_faculty", connection);
            command.CommandType = CommandType.StoredProcedure;

            command.Parameters.AddWithValue("@p_faculty_id", faculty_id);
            command.Parameters.AddWithValue("@p_campus_id", campus_id);
            command.Parameters.AddWithValue("@p_faculty_name", faculty_name);
            command.Parameters.AddWithValue("@p_dean_user_id", dean_user_id);
            command.Parameters.AddWithValue("@p_faculty_phone_number", faculty_phone_number);
            command.Parameters.AddWithValue("@p_faculty_uni_email", faculty_uni_email);

   
            command.ExecuteNonQuery();
            connection.Close();
        }

        public Faculty GetFaculty(int facultyid)
        {

            using MySqlConnection connection = new(_connectionString);
            connection.Open();

            using MySqlCommand command = new("get_faculty_by_id", connection);
            command.CommandType = CommandType.StoredProcedure;

            command.Parameters.AddWithValue("@p_faculty_id", facultyid);
            command.ExecuteNonQuery();

            using MySqlDataReader reader = command.ExecuteReader();
            reader.Read();

            Faculty faculty = new Faculty
            {
                faculty_id = reader.GetInt32("faculty_id"),
                faculty_name = reader.GetString("faculty_name"),
                campus_name = reader.GetString("campus_name"),
                campus_id = reader.GetInt32("campus_id"),
                dean_user_name = reader.GetString("dean_name"),
                dean_user_id = reader.GetInt32("dean_user_id"),
                faculty_phone_number = reader.GetString("faculty_phone_number"),
                faculty_uni_email= reader.GetString("faculty_uni_email")
            };
            connection.Close();
            return faculty;
        }
    }
}