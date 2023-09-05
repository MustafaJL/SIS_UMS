using Microsoft.Extensions.Configuration;
using MySqlConnector;
using System;
using System.Data;
using SIS_UMS.DatabaseHelper.Interfaces;
using SIS_UMS.Models;

namespace SIS_UMS.DatabaseHelper.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly string _connectionString;

        public UserRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("Default")
                ?? throw new InvalidOperationException("The 'Default' connection string is missing in configuration.");
        }

        public bool Check_Username(int username)
        {
            using MySqlConnection connection = new MySqlConnection(_connectionString);
            try
            {
                connection.Open();

                using MySqlCommand command = new MySqlCommand("Check_Username", connection);
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.AddWithValue("@input_username", username);
                command.Parameters.Add("@is_valid", MySqlDbType.Bit);
                command.Parameters["@is_valid"].Direction = ParameterDirection.Output;

                command.ExecuteNonQuery();

                return Convert.ToBoolean(command.Parameters["@is_valid"].Value);
            }
            catch (MySqlException ex)
            {
                // Handle or log the database exception
                throw new ApplicationException("Error checking username.", ex);
            }
        }

        public bool ValidatePassword( int username, string user_password)
        {
            using MySqlConnection connection = new MySqlConnection(_connectionString);
            try
            {
                connection.Open();

                using MySqlCommand command = new MySqlCommand("ValidatePassword", connection);
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.AddWithValue("@input_username", username);
                command.Parameters.AddWithValue("@input_password", user_password);
                command.Parameters.Add(new MySqlParameter("@is_valid", MySqlDbType.Bit));
                command.Parameters["@is_valid"].Direction = ParameterDirection.Output;

                command.ExecuteNonQuery();

                return Convert.ToBoolean(command.Parameters["@is_valid"].Value);
            }
            catch (MySqlException ex)
            {
                // Handle or log the database exception
                throw new ApplicationException("Error validating password.", ex);
            }
        }
    }
}