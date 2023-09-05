using MySqlConnector;
using SIS_UMS.DatabaseHelper.Interfaces;
using System.Data;

namespace SIS_UMS.DatabaseHelper.Repositories
{
    public class UserRepository:IUserRepository

    {
        private readonly string _connectionString;
        private readonly IConfiguration _configuration;

        public UserRepository(IConfiguration configuration)
        {
            _configuration = configuration;
            _connectionString = _configuration.GetConnectionString("Default")
                ?? throw new InvalidOperationException("The 'Default' connection string is missing in configuration.");
        }
        public string GetUserName(int userid)
        {
            using MySqlConnection connection = new(_connectionString);
            connection.Open();

            using MySqlCommand command = new("get_user_name_from_ID", connection);
            command.CommandType = CommandType.StoredProcedure;

            command.Parameters.AddWithValue("@p_user_id", userid);

            // Execute the command and get the result (user name)
            string userName = command.ExecuteScalar() as string;

            connection.Close();

            return userName;
        }
    }
}
