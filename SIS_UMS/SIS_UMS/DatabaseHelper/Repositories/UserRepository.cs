using Microsoft.Extensions.Configuration;
using MySqlConnector;
using System;
using System.Data;
using SIS_UMS.DatabaseHelper.Interfaces;
using SIS_UMS.Models;

namespace SIS_UMS.DatabaseHelper.Repositories
{
    /// <summary>
    /// Represents a repository for performing database operations related to user data.
    /// </summary>
    public class UserRepository : IUserRepository
    {
        private readonly string _connectionString;

        /// <summary>
        /// Initializes a new instance of the UserRepository class.
        /// </summary>
        /// <param name="configuration">An instance of IConfiguration for accessing configuration settings.</param>
        public UserRepository(IConfiguration configuration)
        {
            // Get the database connection string from the configuration, or throw an exception if it's missing.
            _connectionString = configuration.GetConnectionString("Default")
                ?? throw new InvalidOperationException("The 'Default' connection string is missing in configuration.");
        }

        /// <summary>
        /// Checks if a username exists in the database.
        /// </summary>
        /// <param name="username">The username to check.</param>
        /// <returns>True if the username exists; otherwise, false.</returns>
        public bool Check_Username(int username)
        {
            using MySqlConnection connection = new MySqlConnection(_connectionString);
            try
            {
                connection.Open();

                using MySqlCommand command = new MySqlCommand("Check_Username", connection);

                command.CommandType = CommandType.StoredProcedure;

                // Adding the username as a parameter parameter for the input_username of the stored procedure.
                command.Parameters.AddWithValue("@input_username", username);

                // Adding an output parameter to capture the result of the stored procedure.
                command.Parameters.Add("@is_valid", MySqlDbType.Bit);
                command.Parameters["@is_valid"].Direction = ParameterDirection.Output;

                // Execute the stored procedure.
                command.ExecuteNonQuery();

                // Convert the output parameter to a boolean value and return it.
                return Convert.ToBoolean(command.Parameters["@is_valid"].Value);
            }
            catch (MySqlException ex)
            {
                // Handle or log the database exception and rethrow as an application-specific exception.
                throw new ApplicationException("Error checking username.", ex);
            }
        }

        /// <summary>
        /// Validates a user's password against the stored password hash.
        /// </summary>
        /// <param name="username">The username of the user.</param>
        /// <param name="user_password">The user's password to validate.</param>
        /// <returns>True if the password is valid; otherwise, false.</returns>
        public bool ValidatePassword(int username, string user_password)
        {
            using MySqlConnection connection = new MySqlConnection(_connectionString);
            try
            {
                connection.Open();

                using MySqlCommand command = new MySqlCommand("ValidatePassword", connection);
                command.CommandType = CommandType.StoredProcedure;

                // Adding the username as a parameter parameter for the input_username of the stored procedure.
                command.Parameters.AddWithValue("@input_username", username);

                // Adding the user_password as a parameter parameter for the input_password of the stored procedure.
                command.Parameters.AddWithValue("@input_password", user_password);

                // Adding an output parameter to capture the result of the stored procedure.
                command.Parameters.Add(new MySqlParameter("@is_valid", MySqlDbType.Bit));
                command.Parameters["@is_valid"].Direction = ParameterDirection.Output;

                // Execute the stored procedure.
                command.ExecuteNonQuery();

                // Convert the output parameter to a boolean value and return it.
                return Convert.ToBoolean(command.Parameters["@is_valid"].Value);
            }
            catch (MySqlException ex)
            {
                // Handle or log the database exception and rethrow as an application-specific exception.
                throw new ApplicationException("Error validating password.", ex);
            }
        }
    }
}
