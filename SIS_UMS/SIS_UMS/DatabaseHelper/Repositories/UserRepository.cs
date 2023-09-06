using MySqlConnector;
using SIS_UMS.DatabaseHelper.Interfaces;
using SIS_UMS.Models;
using System.Data;
using static System.Net.Mime.MediaTypeNames;
using System.Runtime.Intrinsics.X86;
using System.IO;
using NuGet.Packaging.Signing;

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

        public IEnumerable<User> GetAllUsers()
        {
            List<User> users = new ();

            using MySqlConnection connection = new(_connectionString);
            connection.Open();

            using MySqlCommand command = new("get_all_users", connection);
            command.CommandType = CommandType.StoredProcedure;

            using MySqlDataReader reader = command.ExecuteReader();

            // Convert the table to a list of type User
            while (reader.Read())
            {
                users.Add(new User
                {
                    user_id = reader.GetInt32("user_id"),
                    campus_id = reader.GetInt32("campus_id"),
                    user_password = reader.GetString("user_password"),
                    password_salt = reader.GetString("password_salt"),
                    mother_name = reader.GetString("mother_name"),
                    emergency_contact_name = reader.GetString("emergency_contact_name"),
                    manager_user_id = reader.GetInt32("manager_user_id"),
                    first_name = reader.GetString("first_name"),
                    middle_name = reader.GetString("middle_name"),
                    last_name = reader.GetString("last_name"),
                    gender = reader.GetString("gender"),
                    personal_email= reader.GetString("personal_email"),
                    university_email = reader.GetString("university_email"),
                    ssn = reader.GetInt32("ssn"),
                    date_of_birth=reader.GetDateOnly("date_of_birth"),
                    city=reader.GetString("city"),
                    area=reader.GetString("area"),
                    street=reader.GetString("street"),
                    near_by=reader.GetString("near_by"),
                    building=reader.GetString("building"),
                    floor=reader.GetInt32("floor"),
                    marital_status=reader.GetString("marital_status"),
                    children_count=reader.GetInt32("children_count"),
                    family_registration=reader.GetString("family_registration"),
                    place_of_birth=reader.GetString("place_of_birth"),
                    social_security_type=reader.GetString("social_security_type"),
                    rating=reader.GetDecimal("rating"),
                    additional_info=reader.GetString("additional_info"),
                    is_deleted=reader.GetBoolean("is_deleted"),
                    created_at=reader.GetDateTime("created_at")
                });
            }

            connection.Close();


            connection.Close();

            return users;
        }
    }
}
