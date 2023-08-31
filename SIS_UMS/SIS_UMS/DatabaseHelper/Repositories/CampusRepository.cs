using SIS_UMS.DatabaseHelper.Interfaces;
using System.Data;
using Microsoft.AspNetCore.SignalR;
using MySqlConnector;
using System.Data;

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
        public bool CreateCampus(string? campus_name, string? campus_address, string? campus_phone_number, string? campus_email, string? campus_fax)
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
    }
}
