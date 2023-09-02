using MySqlConnector;
using SIS_UMS.DatabaseHelper.Interface;
using SIS_UMS.Models;
using System.Data;

namespace SIS_UMS.DatabaseHelper.Repositories
{
    public class ApplicationFormRepository : IApplicationFormRepository
    {
        private readonly string _connectionString;
        private readonly IConfiguration _configuration;

        public ApplicationFormRepository(IConfiguration configuration)
        {
            _configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));
            _connectionString = _configuration.GetConnectionString("Default")
                ?? throw new InvalidOperationException("The 'Default' connection string is missing in configuration.");
        }

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
                applicationForms.Add(new ApplicationForm
                {
                    FormId = reader.GetInt32("form_id"),
                    OfficeName = reader.GetString("office_name"),
                    StudentId = reader.GetString("student_id"),
                    ApplicationDate = reader.GetDateTime("application_date"),
                    ApplicationType = reader.GetString("application_type"),
                    Status = Enum.Parse<ApplicationStatus>(reader.GetString("status"), true),
                    ProcessingDate = reader.GetDateTime("processing_date"),
                    AdditionalApplicationDetails = reader.GetString("additional_application_details")

                });
            }

            return applicationForms;
        }
    }
}
