using Microsoft.AspNetCore.Mvc.RazorPages;
using MySql.Data.MySqlClient;
using SIS_UMS.DatabaseHelper.Interfaces;
using SIS_UMS.Models;
using System.Data;
using System.Xml.Linq;


namespace SIS_UMS.DatabaseHelper.Repositories
{
    public class CampusRepository : ICampusRepository
    {
        private readonly string _connectionString;
        private readonly IConfiguration _configuration;

        public CampusRepository(IConfiguration configuration)
        {
            _configuration = configuration;
            _connectionString = _configuration.GetConnectionString("Default")
                ?? throw new InvalidOperationException("The 'Default' connection string is missing in configuration.");
        }










        public async Task<IEnumerable<campus>> GetAllCampus()
        {
            List<campus> campus = new();

            using MySqlConnection connection = new(_connectionString);
            await connection.OpenAsync();

            using MySqlCommand command = new("getAllCampus", connection);
            command.CommandType = CommandType.StoredProcedure;

            using MySqlDataReader reader = command.ExecuteReader();

            // Convert the table to a list of type 
            while (reader.Read())
            {
                campus.Add(new campus
                {
                    campus_id = reader.GetInt32("campus_id"),
                    campus_name = reader.GetString("campus_name"),
                    campus_email=reader.GetString("campus_email"),
                    campus_address = reader.GetString("campus_address"),
                    campus_fax=reader.GetString("campus_fax"),
                    campus_phone_number = reader.GetString("campus_phone_number"),




                });
            }

            connection.Close();

            return campus;

        }


        public async Task CreateCampus(campus c)
        {
            using MySqlConnection connection = new(_connectionString);
            await connection.OpenAsync();

            using MySqlCommand command = new("add_campus", connection);
            command.CommandType = CommandType.StoredProcedure;


            // Add parameters for the stored procedure
            command.Parameters.AddWithValue("@sp_campus_name", c.campus_name);
            command.Parameters.AddWithValue("@sp_campus_address", c.campus_address);
            command.Parameters.AddWithValue("@sp_campus_phone_number", c.campus_phone_number);

            command.Parameters.AddWithValue("@sp_campus_fax", c.campus_fax);


            command.Parameters.AddWithValue("@sp_campus_email", c.campus_email);



            await command.ExecuteNonQueryAsync(); // Execute the stored procedure asynchronously



            connection.Close();

        }

        public async Task<campus> GetCampusById(int campus_id)
        {
           

            using MySqlConnection connection = new(_connectionString);
            await  connection.OpenAsync();

            using MySqlCommand command = new("get_campus_by_id", connection);
            command.CommandType = CommandType.StoredProcedure;

            command.Parameters.AddWithValue("@sp_campus_id", campus_id);


            using MySqlDataReader reader = command.ExecuteReader();
       
            while (reader.Read())
            {
               campus campus =new campus
                {

                    campus_id = reader.GetInt32("campus_id"),
                    campus_name = reader.GetString("campus_name"),
                    campus_address = reader.GetString("campus_address"),
                    campus_phone_number = reader.GetString("campus_phone_number"),
                    campus_fax = reader.GetString("campus_fax"),
                    campus_email = reader.GetString("campus_email")

                };
                return campus;

            }

            connection.Close();

            return null;


        }



        public async Task UpdateCampus(campus c)
        {
            using MySqlConnection connection = new MySqlConnection(_connectionString);
            await connection.OpenAsync();

            using MySqlCommand command = new MySqlCommand("UpdateCampus", connection);
            command.CommandType = CommandType.StoredProcedure;

            // Add parameters for the stored procedure
            command.Parameters.AddWithValue("@sp_campus_id", c.campus_id); // ID of the campus to update - you can keep this line if needed
            command.Parameters.AddWithValue("@sp_campus_name", c.campus_name);
            command.Parameters.AddWithValue("@sp_campus_address", c.campus_address);
            command.Parameters.AddWithValue("@sp_campus_phone_number", c.campus_phone_number);
            command.Parameters.AddWithValue("@sp_campus_fax", c.campus_fax);
            command.Parameters.AddWithValue("@sp_campus_email", c.campus_email);

            await command.ExecuteNonQueryAsync(); // Execute the stored procedure asynchronously

            connection.Close();
        }

        public async Task DeleteCampus(campus c)
        {
            using MySqlConnection connection = new MySqlConnection(_connectionString);
            await connection.OpenAsync();

            using MySqlCommand command = new MySqlCommand("DeleteCampus", connection);
            command.CommandType = CommandType.StoredProcedure;

            command.Parameters.AddWithValue("@sp_campus_id", c.campus_id);
        

            await command.ExecuteNonQueryAsync(); // Execute the stored procedure asynchronously

            connection.Close();
        }




    }
}