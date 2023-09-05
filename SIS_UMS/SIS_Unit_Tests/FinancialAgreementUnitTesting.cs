using Moq;
using MySqlConnector;
using System.Data;

namespace SIS_Unit_Tests
{
    public class FinancialAgreementUnitTesting
    {
        [Fact]
        public void CreateFinancialAgreement_Should_Execute_StoredProcedure()
        {
            // Arrange
            var connectionString = "your_connection_string_here"; // Replace with your actual connection string
            var officeName = "SampleOffice";
            var studentId = "SampleStudentId";
            var applicationDate = DateTime.Now;
            var applicationDetails = "SampleDetails";
            var startDate = DateTime.Now;
            var endDate = DateTime.Now.AddDays(30);
            var isActive = true;

            var mockConnection = new Mock<MySqlConnection>();
            var mockCommand = new Mock<MySqlCommand>();

            mockConnection.Setup(conn => conn.Open());

            mockCommand.Setup(cmd => cmd.Parameters.AddWithValue("@sp_office_name", officeName));
            mockCommand.Setup(cmd => cmd.Parameters.AddWithValue("@sp_student_id", studentId));
            mockCommand.Setup(cmd => cmd.Parameters.AddWithValue("@sp_agreement_date", applicationDate));
            mockCommand.Setup(cmd => cmd.Parameters.AddWithValue("@sp_agreement_details", applicationDetails));
            mockCommand.Setup(cmd => cmd.Parameters.AddWithValue("@sp_start_date", startDate));
            mockCommand.Setup(cmd => cmd.Parameters.AddWithValue("@sp_end_date", endDate));
            mockCommand.Setup(cmd => cmd.Parameters.AddWithValue("@sp_is_active", isActive));

            mockCommand.Setup(cmd => cmd.Parameters.Add(It.IsAny<MySqlParameter>()));
            mockCommand.Setup(cmd => cmd.Parameters["@newFormId"].Direction).Returns(ParameterDirection.Output);


            mockCommand.Setup(cmd => cmd.ExecuteNonQuery());

            mockConnection.Setup(conn => conn.CreateCommand()).Returns(mockCommand.Object);

            var financialAgreementRespository = new FinancialAgreementRespository(connectionString, mockConnection.Object);

            // Act
            financialAgreementRespository.CreateFinancialAgreement(
                officeName,
                studentId,
                applicationDate,
                applicationDetails,
                startDate,
                endDate,
                isActive
            );

            // Assert
            // Verify that ExecuteNonQuery was called on the mockCommand exactly once.
            mockCommand.Verify(cmd => cmd.ExecuteNonQuery(), Times.Once);
        }
    }
}
