using SIS_UMS.DatabaseHelper.Interfaces;
using SIS_UMS.Models;
using MySqlConnector;
using System.Data;

namespace SIS_UMS.DatabaseHelper.Repositories
{
    /// <summary>
    /// Repository for managing roles data.
    /// </summary>
    public class RoleRepository : IRoleRepository
    {
        private readonly string _connectionString;
        private readonly IConfiguration _configuration;

        public RoleRepository(IConfiguration configuration)
        {
            _configuration = configuration;
            _connectionString = _configuration.GetConnectionString("Default")
                ?? throw new InvalidOperationException("The 'Default' connection string is missing in configuration.");
        }
        public IEnumerable<Role> GetAllRoles()
        {
            List<Role> roles = new();

            using MySqlConnection connection = new(_connectionString);
            connection.Open();

            using MySqlCommand command = new("GetAllRoles", connection);
            command.CommandType = CommandType.StoredProcedure;

            using MySqlDataReader reader = command.ExecuteReader();

            // Convert the table to a list of type Role
            while (reader.Read())
            {
                roles.Add(new Role
                {
                    role_id = reader.GetInt32("role_id"),
                    role_name = reader.GetString("role_name"),

                });
            }

            connection.Close();

            return roles;
        }

        /// <inheritdoc/>
        public void CreateRole(string? role_name)
        {

            using MySqlConnection connection = new(_connectionString);
            connection.Open();

            using MySqlCommand command = new("CreateRole", connection);
            command.CommandType = CommandType.StoredProcedure;

            command.Parameters.AddWithValue("@sp_role_name", role_name);

            command.ExecuteNonQuery();
            connection.Close();
        }
        /// <inheritdoc/>
        public bool DeleteRole(int? role_id)
        {
            try
            {
                using MySqlConnection connection = new(_connectionString);
                connection.Open();

                using MySqlCommand command = new("DeleteRole", connection);
                command.CommandType = CommandType.StoredProcedure;

                // Add parameters to the stored procedure
                command.Parameters.AddWithValue("@sp_role_id", role_id);

                // Execute the stored procedure
                command.ExecuteNonQuery();

                return true; // Deletion was successful
            }
            catch (MySqlException ex)
            {
                // Handle MySQL-specific exceptions here
                Console.WriteLine("MySQL Exception: " + ex.Message);
                return false; // Deletion failed
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception: " + ex.Message);
                return false; // Deletion failed
            }

        }
        

    }
}
