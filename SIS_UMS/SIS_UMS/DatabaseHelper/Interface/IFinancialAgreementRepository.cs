using SIS_UMS.Models;

namespace SIS_UMS.DatabaseHelper.Interface
{
    /// <summary>
    /// Represents the interface for managing financial agreements.
    /// </summary>
    public interface IFinancialAgreementRepository
    {
        /// <summary>
        /// Creates a new financial agreement.
        /// </summary>
        /// <param name="officeName">The name of the office.</param>
        /// <param name="studentId">The student's ID.</param>
        /// <param name="applicationDate">The date of the application.</param>
        /// <param name="applicationDetails">Details of the application.</param>
        /// <param name="startDate">The start date of the agreement.</param>
        /// <param name="endDate">The end date of the agreement.</param>
        /// <param name="isActive">Indicates whether the agreement is active.</param>
        void CreateFinancialAgreement(string? officeName, string? studentId, DateTime? applicationDate, string? applicationDetails, DateTime? startDate,
            DateTime? endDate, bool isActive);

        /// <summary>
        /// Retrieves all financial agreements.
        /// </summary>
        /// <returns>An enumerable collection of financial agreements.</returns>
        IEnumerable<FinancialAgreement> GetAllFinancialAgreements();

        /// <summary>
        /// Retrieves a financial agreement by its ID.
        /// </summary>
        /// <param name="financialAgreementId">The ID of the financial agreement to retrieve.</param>
        /// <returns>The financial agreement with the specified ID, or null if not found.</returns>
        FinancialAgreement? GetFinancialAgreementById(int financialAgreementId);

        /// <summary>
        /// Updates a financial agreement.
        /// </summary>
        /// <param name="FinancialAgreement">The financial agreement to update.</param>
        /// <returns>True if the update was successful, false otherwise.</returns>
        bool UpdateFinancialAgreement(FinancialAgreement? FinancialAgreement);

        /// <summary>
        /// Deletes a financial agreement by its ID.
        /// </summary>
        /// <param name="financialAgreementId">The ID of the financial agreement to delete.</param>
        /// <returns>True if the deletion was successful, false otherwise.</returns>
        bool DeleteFinancialAgreement(int financialAgreementId);
    }
}
