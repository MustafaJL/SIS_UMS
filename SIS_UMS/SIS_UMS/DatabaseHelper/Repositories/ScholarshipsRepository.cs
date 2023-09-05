using SIS_UMS.DatabaseHelper.Interfaces;
using SIS_UMS.Models;
using MySqlConnector;
using System.Data;

namespace SIS_UMS.DatabaseHelper.Repositories
{
    /// <summary>
    /// Represents a repository for managing Scholarships using a MySQL database.
    /// </summary>
    public class ScholarshipsRepository : IScholarshipsRepository
    {
        private readonly string _connectionString;
        private readonly IConfiguration _configuration;

        public ScholarshipsRepository(IConfiguration configuration)
        {
            _configuration = configuration;
            _connectionString = _configuration.GetConnectionString("Default")
                ?? throw new InvalidOperationException("The 'Default' connection string is missing in configuration.");
        }
        
        
        /// <inheritdoc/>
        public IEnumerable<Scholarships> GetAllScholarships()
        {
            List<Scholarships> scholarships = new();

            using MySqlConnection connection = new(_connectionString);
            connection.Open();

            using MySqlCommand command = new("GetAllScholarships", connection);
            command.CommandType = CommandType.StoredProcedure;

            using MySqlDataReader reader = command.ExecuteReader();

            // Convert the table to a list of type Scholarship
            while (reader.Read())
            {
                scholarships.Add(new Scholarships
                {
                    scholarship_id = reader.GetInt32("scholarship_id"),
                    scholarship_type = reader.GetString("scholarship_type"),
                    percentage_in_dollar = reader.GetDecimal("percentage_in_dollar"),
                    percentage_in_lebanese=reader.GetDecimal("percentage_in_lebanese"),
                    created_at=reader.GetDateTime("created_at")
                });
            }

            connection.Close();
            
            return scholarships;
        }

        /// <inheritdoc/>
        public void AddScholarship(string? scholarship_type,decimal? percentage_in_dollar,decimal? percentage_in_lebanese)
        {
            using MySqlConnection connection = new(_connectionString);
            connection.Open();

            using MySqlCommand command = new("AddScholarship", connection);
            command.CommandType = CommandType.StoredProcedure;

            command.Parameters.AddWithValue("@sp_scholarship_type", scholarship_type);
            command.Parameters.AddWithValue("@sp_percentage_in_dollar", percentage_in_dollar);
            command.Parameters.AddWithValue("@sp_percentage_in_lebanese", percentage_in_lebanese);

            command.ExecuteNonQuery();
            connection.Close();
        }

        /// <inheritdoc/>
        public bool DeleteScholarship(int? scholarship_id){
             try
            {
                using MySqlConnection connection = new(_connectionString);
                connection.Open();

                using MySqlCommand command = new("DeleteScholarship", connection);
                command.CommandType = CommandType.StoredProcedure;

                // Add parameters to the stored procedure
                command.Parameters.AddWithValue("@sp_scholarship_id", scholarship_id);

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