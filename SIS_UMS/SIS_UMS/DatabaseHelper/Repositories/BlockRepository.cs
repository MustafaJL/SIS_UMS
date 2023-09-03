using Microsoft.AspNetCore.Mvc.RazorPages;
using MySql.Data.MySqlClient;
using SIS_UMS.DatabaseHelper.Interfaces;
using SIS_UMS.Models;
using System.Data;
using System.Xml.Linq;


namespace SIS_UMS.DatabaseHelper.Repositories
{
    public class BlockRepository : IBlockRepository
    {
        private readonly string _connectionString;
        private readonly IConfiguration _configuration;

        public BlockRepository(IConfiguration configuration)
        {
            _configuration = configuration;
            _connectionString = _configuration.GetConnectionString("Default")
                ?? throw new InvalidOperationException("The 'Default' connection string is missing in configuration.");
        }










        public async Task<IEnumerable<block>> GetAllBlocks()
        {
            List<block> block = new();

            using MySqlConnection connection = new(_connectionString);
            await connection.OpenAsync();

            using MySqlCommand command = new("GetAllblocks", connection);
            command.CommandType = CommandType.StoredProcedure;

            using MySqlDataReader reader = command.ExecuteReader();

            // Convert the table to a list of type 
            while (reader.Read())
            {
                block.Add(new block
                {
                    block_id = reader.GetInt32("block_id"),
                    campus_id = reader.GetInt32("campus_id"),
                    created_at = reader.GetDateTime("created_at"),
                    block_code = reader.GetString("block_code"),
                    floor_count = reader.GetInt32("floor_count"),
                    room_count = reader.GetInt32("room_count")



                });
            }

            connection.Close();

            return block;

        }


        public async Task CreateBlock(block c)
        {
            using MySqlConnection connection = new(_connectionString);
            await connection.OpenAsync();

            using MySqlCommand command = new("add_block", connection);
            command.CommandType = CommandType.StoredProcedure;


            // Add parameters for the stored procedure
          
            command.Parameters.AddWithValue("@sp_campus_id", c.campus_id);
            command.Parameters.AddWithValue("@sp_block_code", Convert.ToChar(c.block_code));
            command.Parameters.AddWithValue("@sp_floor_count", c.floor_count);
            command.Parameters.AddWithValue("@sp_room_count", c.room_count);
            command.Parameters.AddWithValue("@sp_created_at", c.created_at);

            await command.ExecuteNonQueryAsync();




            connection.Close();

        }

        public async Task<block> GetBlockById(int block_id)
        {


            using MySqlConnection connection = new(_connectionString);
            await connection.OpenAsync();

            using MySqlCommand command = new("get_block_by_id", connection);
            command.CommandType = CommandType.StoredProcedure;

            command.Parameters.AddWithValue("@sp_block_id", block_id);


            using MySqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                block block = new block
                {

                    block_id = reader.GetInt32("block_id"),
                    campus_id = reader.GetInt32("campus_id"),
                    created_at = reader.GetDateTime("created_at"),
                     block_code = reader.GetString("block_code"),
                     floor_count = reader.GetInt32("floor_count"),
                    room_count  = reader.GetInt32("room_count")

                };
                return block;

            }

            connection.Close();

            return null;


        }



        public async Task UpdateBlock(block c)
        {
            using MySqlConnection connection = new MySqlConnection(_connectionString);
            await connection.OpenAsync();

            using MySqlCommand command = new MySqlCommand("Updateblock", connection);
            command.CommandType = CommandType.StoredProcedure;

            // Add parameters for the stored procedure
            command.Parameters.AddWithValue("@sp_block_id", c.block_id); // ID of the block to update - you can keep this line if needed
            command.Parameters.AddWithValue("@sp_campus_id", c.campus_id);
            command.Parameters.AddWithValue("@sp_block_code", c.block_code);
            command.Parameters.AddWithValue("@sp_floor_count", c.floor_count);
            command.Parameters.AddWithValue("@sp_room_count", c.room_count);
            command.Parameters.AddWithValue("@sp_created_at", c.created_at);


            await command.ExecuteNonQueryAsync(); // Execute the stored procedure asynchronously

            connection.Close();
        }

        public async Task DeleteBlock(block c)
        {
            using MySqlConnection connection = new MySqlConnection(_connectionString);
            await connection.OpenAsync();

            using MySqlCommand command = new MySqlCommand("DeleteBlock", connection);
            command.CommandType = CommandType.StoredProcedure;

            command.Parameters.AddWithValue("@sp_block_id", c.block_id);


            await command.ExecuteNonQueryAsync(); // Execute the stored procedure asynchronously

            connection.Close();
        }

      

       
    }
}