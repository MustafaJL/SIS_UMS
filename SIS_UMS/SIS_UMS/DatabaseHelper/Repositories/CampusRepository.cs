using SIS_UMS.DatabaseHelper.Interfaces;
using System.Data;
using MySqlConnector;
using SIS_UMS.Models;

namespace SIS_UMS.DatabaseHelper.Repositories
{
    
    public class CampusRepository:ICampusRepository
    {
        private readonly string _connectionString;
        private readonly IConfiguration _configuration;
        public CampusRepository(IConfiguration configuration)
        {
            _configuration = configuration;
            _connectionString = _configuration.GetConnectionString("Default")
                ?? throw new InvalidOperationException("The 'Default' connection string is missing in configuration.");
        }

        /// <inheritdoc/>
        public IEnumerable<Campus> GetAllCampuses()
        {
            List<Campus> campuses = new();

            using MySqlConnection connection = new(_connectionString);
            connection.Open();

            using MySqlCommand command = new("getAllCampuses", connection);
            command.CommandType = CommandType.StoredProcedure;

            using MySqlDataReader reader = command.ExecuteReader();

            // Convert the table to a list of type User
            while (reader.Read())
            {
                campuses.Add(new Campus
                {
                   campus_id= reader.GetInt32("campus_id"),
                   campus_name=reader.GetString("campus_name"),
                   campus_address = reader.GetString("campus_address"),
                   campus_phone_number = reader.GetString("campus_phone_number"),
                   campus_fax = reader.GetString("campus_fax"),
                   campus_email = reader.GetString("campus_email")
                });
            }

            connection.Close();

            return campuses;
        }

        /// <inheritdoc/>
        public bool CreateCampus(string? campus_name, string? campus_address, string? campus_phone_number, string? campus_fax ,string? campus_email)
        {
            using MySqlConnection connection = new(_connectionString);
            connection.Open();

            using MySqlCommand command = new("create_campus", connection);
            command.CommandType = CommandType.StoredProcedure;

            command.Parameters.AddWithValue("@p_campus_name", campus_name);
            command.Parameters.AddWithValue("@p_campus_address", campus_address);
            command.Parameters.AddWithValue("@p_campus_phone_number", campus_phone_number);
            command.Parameters.AddWithValue("@p_campus_email", campus_email);
            command.Parameters.AddWithValue("@p_campus_fax", campus_fax);

            command.Parameters.Add(new MySqlParameter("@added_successfully", MySqlDbType.Bit));
            command.Parameters["@added_successfully"].Direction = ParameterDirection.Output;
            command.ExecuteNonQuery();
            bool result = Convert.ToBoolean(command.Parameters["@added_successfully"].Value);
            connection.Close();
            return result;
        }
        public Campus GetCampus(int campus_id)
        {
            using MySqlConnection connection = new(_connectionString);
            connection.Open();
            using MySqlCommand command = new("get_campus_from_id", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@p_campus_id", campus_id);
            command.ExecuteNonQuery();
            using MySqlDataReader reader = command.ExecuteReader();
            reader.Read();
            Campus campus = new Campus
            {
                campus_id = reader.GetInt32("campus_id"),
                campus_name = reader.GetString("campus_name"),
                campus_address = reader.GetString("campus_address"),
                campus_phone_number = reader.GetString("campus_phone_number"),
                campus_fax = reader.GetString("campus_fax"),
                campus_email = reader.GetString("campus_email")
            };
            connection.Close();

            return campus;
        }

        public bool EditCampus(int? campus_id, string? campus_name, string? campus_address, string? campus_phone_number, string? campus_fax, string? campus_email)
        {
            using MySqlConnection connection = new(_connectionString);
            connection.Open();

            using MySqlCommand command = new("edit_campus", connection);
            command.CommandType = CommandType.StoredProcedure;

            command.Parameters.AddWithValue("@p_campus_id", campus_id);
            command.Parameters.AddWithValue("@p_campus_name", campus_name);
            command.Parameters.AddWithValue("@p_campus_address", campus_address);
            command.Parameters.AddWithValue("@p_campus_phone_number", campus_phone_number);
            command.Parameters.AddWithValue("@p_campus_email", campus_email);
            command.Parameters.AddWithValue("@p_campus_fax", campus_fax);

            command.Parameters.Add(new MySqlParameter("@edited_successfully", MySqlDbType.Bit));
            command.Parameters["@edited_successfully"].Direction = ParameterDirection.Output;
            command.ExecuteNonQuery();
            bool result = Convert.ToBoolean(command.Parameters["@edited_successfully"].Value);
            connection.Close();
            return result;
        }

        public void DeleteCampus(int campus_id)
        {
            using MySqlConnection connection = new(_connectionString);
            connection.Open();

            using MySqlCommand command = new("delete_campus", connection);
            command.CommandType = CommandType.StoredProcedure;

            command.Parameters.AddWithValue("@p_campus_id", campus_id);

            command.ExecuteNonQuery();
            connection.Close();
        }
    }
}
