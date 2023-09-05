using MySqlConnector;
using SIS_UMS.DatabaseHelper.Interface;
using SIS_UMS.Models;
using System.Data;

namespace SIS_UMS.DatabaseHelper.Repositories
{
    /// <summary>
    /// Repository for managing application forms in the database.
    /// </summary>
    public class ApplicationFormRepository : IApplicationFormRepository
    {
        private readonly string _connectionString;
        private readonly IConfiguration _configuration;

        /// <summary>
        /// Initializes a new instance of the <see cref="ApplicationFormRepository"/> class.
        /// </summary>
        /// <param name="configuration">The configuration containing the connection string.</param>
        public ApplicationFormRepository(IConfiguration configuration)
        {
            _configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));
            _connectionString = _configuration.GetConnectionString("Default")
                ?? throw new InvalidOperationException("The 'Default' connection string is missing in configuration.");
        }

        /// <inheritdoc/>
        public void CreateApplicationForm(string? officeName, string? studentId, string? applicationType, string? status, string? additionalApplicationDetails)
        {
            try
            {
                using MySqlConnection connection = new MySqlConnection(_connectionString);
                connection.Open();

                using MySqlCommand command = new MySqlCommand("add_new_application_form", connection);
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.AddWithValue("@sp_office_name", officeName);
                command.Parameters.AddWithValue("@sp_student_id", studentId);
                command.Parameters.AddWithValue("@sp_application_type", applicationType);
                command.Parameters.AddWithValue("@sp_status", status);
                command.Parameters.AddWithValue("@sp_additional_application_details", additionalApplicationDetails);

                command.Parameters.Add(new MySqlParameter("@newFormId", MySqlDbType.Int32));
                command.Parameters["@newFormId"].Direction = ParameterDirection.Output;

                command.ExecuteNonQuery();
            }
            catch (MySqlException ex)
            {
                Console.WriteLine("CreateApplicationForm(): An error occurred while creating the application form: " + ex.Message);
            }
        }


        /// <inheritdoc/>
        public IEnumerable<ApplicationForm> GetAllApplicationForms()
        {
            List<ApplicationForm> applicationForms = new List<ApplicationForm>();

            using MySqlConnection connection = new MySqlConnection(_connectionString);
            connection.Open();

            using MySqlCommand command = new MySqlCommand("get_all_application_forms", connection);
            command.CommandType = CommandType.StoredProcedure;

            using MySqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {

                try
                {
                    applicationForms.Add(new ApplicationForm
                    {
                        FormId = reader.GetInt32("form_id"),
                        OfficeName = reader.IsDBNull(reader.GetOrdinal("office_name"))
                            ? null : reader.GetString("office_name"),
                        StudentId = reader.IsDBNull(reader.GetOrdinal("student_id"))
                             ? null : reader.GetString("student_id"),
                        ApplicationDate = reader.GetDateTime("application_date"),
                        ApplicationType = reader.IsDBNull(reader.GetOrdinal("application_type"))
                            ? null : reader.GetString("application_type"),
                        Status = reader.IsDBNull(reader.GetOrdinal("status"))
                            ? null : reader.GetString("status"),
                        AdditionalApplicationDetails = reader.IsDBNull(reader.GetOrdinal("additional_application_details"))
                            ? null : reader.GetString("additional_application_details")
                    });
                }
                catch (InvalidCastException ex)
                {
                    Console.WriteLine("GetAllApplicationForms(): InvalidCastException: " + ex.Message);
                    Console.WriteLine("GetAllApplicationForms(): InvalidCastException Details: " + ex.StackTrace);

                    Console.WriteLine("form_id: " + reader["form_id"]);
                    Console.WriteLine("office_name: " + reader["office_name"]);

                    throw;
                }
            }

            return applicationForms;
        }


        /// <inheritdoc/>
        public ApplicationForm? GetApplicationFormById(int formId)
        {
            using MySqlConnection connection = new MySqlConnection(_connectionString);
            connection.Open();

            using MySqlCommand command = new MySqlCommand("get_application_form_by_id", connection);
            command.CommandType = CommandType.StoredProcedure;

            command.Parameters.AddWithValue("@sp_form_id", formId);

            using MySqlDataReader reader = command.ExecuteReader();

            if (reader.Read())
            {
                try
                {
                    return new ApplicationForm
                    {
                        OfficeName = reader.IsDBNull(reader.GetOrdinal("office_name"))
                            ? null : reader.GetString("office_name"),
                        StudentId = reader.IsDBNull(reader.GetOrdinal("student_id"))
                            ? null : reader.GetString("student_id"),
                        ApplicationDate = reader.GetDateTime("application_date"),
                        ApplicationType = reader.IsDBNull(reader.GetOrdinal("application_type"))
                            ? null : reader.GetString("application_type"),
                        Status = reader.IsDBNull(reader.GetOrdinal("status"))
                            ? null : reader.GetString("status"),
                        AdditionalApplicationDetails = reader.IsDBNull(reader.GetOrdinal("additional_application_details"))
                            ? null : reader.GetString("additional_application_details")
                    };
                }
                catch (InvalidCastException ex)
                {
                    Console.WriteLine("GetApplicationFormById(): InvalidCastException: " + ex.Message);
                    Console.WriteLine("GetApplicationFormById(): InvalidCastException Details: " + ex.StackTrace);

                    Console.WriteLine("office_name: " + reader["office_name"]);
                    Console.WriteLine("student_id: " + reader["student_id"]);
                    Console.WriteLine("application_type: " + reader["application_type"]);
                    Console.WriteLine("status: " + reader["status"]);
                    Console.WriteLine("additional_application_details: " + reader["additional_application_details"]);

                    throw;
                }
            }

            return null;
        }


        /// <inheritdoc/>
        public bool UpdateApplicationForm(ApplicationForm? applicationForm)
        {
            if (applicationForm == null)
            {
                return false;
            }

            using MySqlConnection connection = new MySqlConnection(_connectionString);

            try
            {
                connection.Open();

                using MySqlCommand command = new MySqlCommand("edit_application_form", connection);
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.AddWithValue("@sp_form_id", applicationForm.FormId);
                command.Parameters.AddWithValue("@sp_office_name", applicationForm.OfficeName);
                command.Parameters.AddWithValue("@sp_student_id", applicationForm.StudentId);
                command.Parameters.AddWithValue("@sp_application_type", applicationForm.ApplicationType);
                command.Parameters.AddWithValue("@sp_status", applicationForm.Status);
                command.Parameters.AddWithValue("@sp_additional_application_details", applicationForm.AdditionalApplicationDetails);

                int rowsAffected = command.ExecuteNonQuery();

                return rowsAffected > 0;
            }
            catch (MySqlException ex)
            {
                Console.WriteLine("UpdateApplicationForm(): MySQL Error updating application form: " + ex.Message);
                throw;
            }
            catch (Exception ex)
            {
                Console.WriteLine("UpdateApplicationForm(): Error updating application form: " + ex.Message);
                throw;
            }
            finally
            {
                if (connection.State == ConnectionState.Open)
                {
                    connection.Close();
                }
            }
        }


        /// <inheritdoc/>
        public bool DeleteApplicationForm(int formId)
        {
            try
            {
                using MySqlConnection connection = new MySqlConnection(_connectionString);
                connection.Open();

                using MySqlCommand command = new MySqlCommand("delete_application_form", connection);
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.AddWithValue("@sp_form_id", formId);

                int rowsAffected = command.ExecuteNonQuery();

                return rowsAffected > 0;
            }
            catch (MySqlException ex)
            {
                Console.WriteLine("DeleteApplicationForm(): An error occurred while deleting the application form: " + ex.Message);
                return false;
            }
        }

    }
}
