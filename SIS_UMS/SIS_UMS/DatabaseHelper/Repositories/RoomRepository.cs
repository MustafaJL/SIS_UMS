using Microsoft.AspNetCore.Mvc.RazorPages;
using MySql.Data.MySqlClient;
using SIS_UMS.DatabaseHelper.Interfaces;
using SIS_UMS.Models;
using System.Data;
using System.Xml.Linq;


namespace SIS_UMS.DatabaseHelper.Repositories
{
    public class RoomRepository : IRoomRepository
    {
        private readonly string _connectionString;
        private readonly IConfiguration _configuration;

        public RoomRepository(IConfiguration configuration)
        {
            _configuration = configuration;
            _connectionString = _configuration.GetConnectionString("Default")
                ?? throw new InvalidOperationException("The 'Default' connection string is missing in configuration.");
        }










        public async Task<IEnumerable<RoomViewModel>> GetAllRoom()
        {
      
            List<RoomViewModel> room = new List<RoomViewModel>();

            using MySqlConnection connection = new(_connectionString);
            await connection.OpenAsync();

            using MySqlCommand command = new("getAllRoom", connection);
            command.CommandType = CommandType.StoredProcedure;

            using MySqlDataReader reader = command.ExecuteReader();

            // Convert the table to a list of type 
            while (reader.Read())
            {
                room.Add(new RoomViewModel
                {
                    room_id = reader.GetInt32("room_id"),
                    block_id = reader.GetInt32("block_id"),
                    room_code = reader.GetString("room_code"),
                    floor_number= reader.GetInt32("floor_number"),
                    room_capacity = reader.GetInt32("room_capacity"),
                    created_at = reader.GetDateTime("created_at"),
                    block_code = reader.GetChar("block_code"),




                });
            }

            connection.Close();

            return room;

        }


        public async Task CreateRoom(room r)
        {
            using MySqlConnection connection = new(_connectionString);
            await connection.OpenAsync();

            using MySqlCommand command = new("add_room", connection);
            command.CommandType = CommandType.StoredProcedure;

            // Add parameters for the stored procedure
            command.Parameters.AddWithValue("@sp_block_id", r.block_id);
            command.Parameters.AddWithValue("@sp_room_code", r.room_code);
           
            command.Parameters.AddWithValue("@sp_floor_number", r.floor_number);
            command.Parameters.AddWithValue("@sp_room_capacity",r.room_capacity );
            command.Parameters.AddWithValue("@sp_created_at", r.created_at);

            await command.ExecuteNonQueryAsync(); 


            connection.Close();

        }
     


        public async Task<room> GetRoomById(int room_id)
        {


            using MySqlConnection connection = new(_connectionString);
            await connection.OpenAsync();

            using MySqlCommand command = new("get_room_by_id", connection);
            command.CommandType = CommandType.StoredProcedure;

            command.Parameters.AddWithValue("@sp_room_id", room_id);


            using MySqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                room room = new room
                {

               
                    room_id = reader.GetInt32("room_id"),
                    block_id = reader.GetInt32("block_id"),
                    room_code = reader.GetString("room_code"),
                    floor_number = reader.GetInt32("floor_number"),
                    room_capacity = reader.GetInt32("room_capacity"),
                    created_at = reader.GetDateTime("created_at")

                };
                return room;

            }

            connection.Close();

            return null;


        }



        public async Task UpdateRoom(room r)
        {
            using MySqlConnection connection = new MySqlConnection(_connectionString);
            await connection.OpenAsync();

            using MySqlCommand command = new MySqlCommand("update_room", connection);
            command.CommandType = CommandType.StoredProcedure;

            // Add parameters for the stored procedure
            command.Parameters.AddWithValue("@sp_room_id" , r.room_id);
            command.Parameters.AddWithValue("@sp_room_code", r.room_code);
            command.Parameters.AddWithValue("@sp_block_id", r.block_id);
            command.Parameters.AddWithValue("@sp_floor_number", r.floor_number);
            command.Parameters.AddWithValue("@sp_room_capacity", r.room_capacity);
            command.Parameters.AddWithValue("@sp_created_at", r.created_at);

            await command.ExecuteNonQueryAsync(); // Execute the stored procedure asynchronously

            connection.Close();
        }

        public async Task DeleteRoom(room r)
        {
            using MySqlConnection connection = new MySqlConnection(_connectionString);
            await connection.OpenAsync();

            using MySqlCommand command = new MySqlCommand("DeleteRoom", connection);
            command.CommandType = CommandType.StoredProcedure;

            command.Parameters.AddWithValue("@sp_room_id", r.room_id);


            await command.ExecuteNonQueryAsync(); // Execute the stored procedure asynchronously

            connection.Close();
        }




    }
}