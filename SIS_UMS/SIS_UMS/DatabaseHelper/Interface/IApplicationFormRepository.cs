using SIS_UMS.Models;

namespace SIS_UMS.DatabaseHelper.Interface
{
    /// <summary>
    /// Represents a repository for application forms.
    /// </summary>
    public interface IApplicationFormRepository
    {
        /// <summary>
        /// Creates a new application form.
        /// </summary>
        /// <param name="officeName">The Name of the office associated with the form.</param>
        /// <param name="studentId">The ID of the student submitting the form.</param>
        /// <param name="applicationDate">The date of the application.</param>
        /// <param name="applicationType">The type of the application.</param>
        /// <param name="status">The status of the application (e.g., 'Pending', 'Accepted', 'Rejected').</param>
        /// <param name="processingDate">The date when the application is processed.</param>
        /// <param name="additionalApplicationDetails">Additional details for the application (optional).</param>
        /// <returns>The ID of the newly created application form, or -1 if creation fails.</returns>
        void CreateApplicationForm(string? officeName, string? studentId, string? applicationType, string? status, string? additionalApplicationDetails);

        /// <summary>
        /// Gets all application forms.
        /// </summary>
        /// <returns>An IEnumerable of ApplicationForm objects representing all application forms.</returns>
        IEnumerable<ApplicationForm> GetAllApplicationForms();

        /// <summary>
        /// Gets a single application form by its ID.
        /// </summary>
        /// <param name="formId">The ID of the application form to retrieve.</param>
        /// <returns>The ApplicationForm object corresponding to the given ID, or null if not found.</returns>
        ApplicationForm? GetApplicationFormById(int formId);

        /// <summary>
        /// Updates an existing application form with new values.
        /// </summary>
        /// <param name="updatedForm">The ApplicationForm object containing the updated values.</param>
        /// <returns>True if the application form was successfully updated; otherwise, false.</returns>
        bool UpdateApplicationForm(ApplicationForm? applicationForm);

        /// <summary>
        /// Deletes an application form from the database based on its FormId.
        /// </summary>
        /// <param name="formId">The unique identifier of the application form to delete.</param>
        /// <returns>True if the application form was successfully deleted; otherwise, false.</returns>
        bool DeleteApplicationForm(int formId);


    }
}
