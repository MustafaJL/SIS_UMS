using MySqlConnector;
using SIS_UMS.DatabaseHelper.Interface;
using SIS_UMS.Models;
using System.Data;

namespace SIS_UMS.DatabaseHelper.Repositories
{
    /// <summary>
    /// Repository for managing financial agreements in the database.
    /// </summary>
    public class FinancialAgreementRespository : IFinancialAgreementRepository
    {
        private readonly string _connectionString;
        private readonly IConfiguration _configuration;

        /// <summary>
        /// Initializes a new instance of the <see cref="FinancialAgreementRespository"/> class.
        /// </summary>
        /// <param name="configuration">The configuration containing the connection string.</param>
        public FinancialAgreementRespository(IConfiguration configuration)
        {
            _configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));
            _connectionString = _configuration.GetConnectionString("Default")
                ?? throw new InvalidOperationException("The 'Default' connection string is missing in configuration.");
        }

        /// <inheritdoc/>
        public void CreateFinancialAgreement(string? officeName, string? studentId, DateTime? applicationDate, string? applicationDetails, DateTime? startDate, DateTime? endDate, bool isActive)
        {
            try
            {
                using MySqlConnection connection = new MySqlConnection(_connectionString);
                connection.Open();

                using MySqlCommand command = new MySqlCommand("add_new_financial_agreement", connection);
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.AddWithValue("@sp_office_name", officeName);
                command.Parameters.AddWithValue("@sp_student_id", studentId);
                command.Parameters.AddWithValue("@sp_agreement_date", applicationDate);
                command.Parameters.AddWithValue("@sp_agreement_details", applicationDetails);
                command.Parameters.AddWithValue("@sp_start_date", startDate);
                command.Parameters.AddWithValue("@sp_end_date", endDate);
                command.Parameters.AddWithValue("@sp_is_active", isActive);

                command.Parameters.Add(new MySqlParameter("@newFormId", MySqlDbType.Int32));
                command.Parameters["@newFormId"].Direction = ParameterDirection.Output;

                command.ExecuteNonQuery();
            }
            catch (MySqlException ex)
            {
                Console.WriteLine("CreateFinancialAgreement(): An error occurred while creating the financial agreement: " + ex.Message);
            }
        }

        /// <inheritdoc/>
        public IEnumerable<FinancialAgreement> GetAllFinancialAgreements()
        {
            List<FinancialAgreement> financialAgreements = new List<FinancialAgreement>();

            using MySqlConnection connection = new MySqlConnection(_connectionString);
            connection.Open();

            using MySqlCommand command = new MySqlCommand("get_all_financial_agreements", connection);
            command.CommandType = CommandType.StoredProcedure;

            using MySqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {

                try
                {
                    financialAgreements.Add(new FinancialAgreement
                    {
                        FinancialAgreementId = reader.GetInt32("financial_agreement_id"),
                        OfficeName = reader.IsDBNull(reader.GetOrdinal("office_name"))
                            ? null : reader.GetString("office_name"),
                        StudentId = reader.IsDBNull(reader.GetOrdinal("student_id"))
                             ? null : reader.GetString("student_id"),
                        AgreementDate = reader.GetDateTime("agreement_date"),
                        AgreementDetails = reader.IsDBNull(reader.GetOrdinal("agreement_details"))
                            ? null : reader.GetString("agreement_details"),
                        StartDate = reader.GetDateTime("start_date"),
                        EndDate = reader.GetDateTime("end_date"),
                        IsActive = reader.GetBoolean("is_active")
                    });
                }
                catch (InvalidCastException ex)
                {
                    Console.WriteLine("GetAllFinancialAgreement(): InvalidCastException: " + ex.Message);
                    Console.WriteLine("GetAllFinancialAgreement(): InvalidCastException Details: " + ex.StackTrace);

                    Console.WriteLine("agreement_id: " + reader["agreement_id"]);
                    Console.WriteLine("office_name: " + reader["office_name"]);

                    throw;
                }
            }

            return financialAgreements;
        }

        /// <inheritdoc/>
        public FinancialAgreement? GetFinancialAgreementById(int financialAgreementId)
        {
            using MySqlConnection connection = new MySqlConnection(_connectionString);
            connection.Open();

            using MySqlCommand command = new MySqlCommand("get_financial_agreements_by_id", connection);
            command.CommandType = CommandType.StoredProcedure;

            command.Parameters.AddWithValue("@sp_financial_agreement_id", financialAgreementId);

            using MySqlDataReader reader = command.ExecuteReader();

            if (reader.Read())
            {
                try
                {
                    return new FinancialAgreement
                    {
                        OfficeName = reader.IsDBNull(reader.GetOrdinal("office_name"))
                            ? null : reader.GetString("office_name"),
                        StudentId = reader.IsDBNull(reader.GetOrdinal("student_id"))
                            ? null : reader.GetString("student_id"),
                        AgreementDate = reader.GetDateTime("agreement_date"),
                        AgreementDetails = reader.IsDBNull(reader.GetOrdinal("agreement_details"))
                            ? null : reader.GetString("agreement_details"),
                        StartDate = reader.GetDateTime("start_date"),
                        EndDate = reader.GetDateTime("end_date"),
                        IsActive = reader.GetBoolean("is_active")
                    };
                }
                catch (InvalidCastException ex)
                {
                    Console.WriteLine("GetFinancailAgreementById(): InvalidCastException: " + ex.Message);
                    Console.WriteLine("GetFinancailAgreementById(): InvalidCastException Details: " + ex.StackTrace);

                    Console.WriteLine("office_name: " + reader["office_name"]);
                    Console.WriteLine("student_id: " + reader["student_id"]);
                    Console.WriteLine("agreement_date: " + reader["agreement_date"]);
                    Console.WriteLine("agreement_details: " + reader["agreement_details"]);
                    Console.WriteLine("agreement_details: " + reader["agreement_details"]);
                    Console.WriteLine("start_date: " + reader["start_date"]);
                    Console.WriteLine("end_date: " + reader["end_date"]);
                    Console.WriteLine("is_active: " + reader["is_active"]);

                    throw;
                }
            }

            return null;
        }

        /// <inheritdoc/>
        public bool UpdateFinancialAgreement(FinancialAgreement? financialAgreement)
        {
            if (financialAgreement == null)
            {
                return false;
            }

            using MySqlConnection connection = new MySqlConnection(_connectionString);

            try
            {
                connection.Open();

                using MySqlCommand command = new MySqlCommand("edit_financial_statement", connection);
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.AddWithValue("@sp_financial_agreement_id", financialAgreement.FinancialAgreementId);
                command.Parameters.AddWithValue("@sp_office_name", financialAgreement.OfficeName);
                command.Parameters.AddWithValue("@sp_student_id", financialAgreement.StudentId);
                command.Parameters.AddWithValue("@sp_agreement_date", financialAgreement.AgreementDate);
                command.Parameters.AddWithValue("@sp_agreement_details", financialAgreement.AgreementDetails);
                command.Parameters.AddWithValue("@sp_start_date", financialAgreement.StartDate);
                command.Parameters.AddWithValue("@sp_end_date", financialAgreement.EndDate);
                command.Parameters.AddWithValue("@sp_is_active", financialAgreement.IsActive);


                int rowsAffected = command.ExecuteNonQuery();

                return rowsAffected > 0;
            }
            catch (MySqlException ex)
            {
                Console.WriteLine("UpdateFinancialAgreement(): MySQL Error updating financial agreement: " + ex.Message);
                throw;
            }
            catch (Exception ex)
            {
                Console.WriteLine("UpdateFinancialAgreement(): Error updating financial agreement: " + ex.Message);
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
        public bool DeleteFinancialAgreement(int financialAgreementId)
        {
            try
            {
                using MySqlConnection connection = new MySqlConnection(_connectionString);
                connection.Open();

                using MySqlCommand command = new MySqlCommand("delete_financial_agreement", connection);
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.AddWithValue("@sp_financial_agreement", financialAgreementId);

                int rowsAffected = command.ExecuteNonQuery();

                return rowsAffected > 0;
            }
            catch (MySqlException ex)
            {
                Console.WriteLine("DeleteFinancialAgreement(): An error occurred while deleting the application form: " + ex.Message);
                return false;
            }
        }
    }
}
