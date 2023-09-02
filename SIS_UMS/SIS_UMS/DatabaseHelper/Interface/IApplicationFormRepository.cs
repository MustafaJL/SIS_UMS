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
        void CreateApplicationForm(string officeName, string studentId, DateTime applicationDate, string applicationType, ApplicationStatus status, DateTime processingDate,
     string additionalApplicationDetails);



        /// <summary>
        /// Gets all application forms.
        /// </summary>
        /// <returns>An IEnumerable of ApplicationForm objects representing all application forms.</returns>
        IEnumerable<ApplicationForm> GetAllApplicationForms();
    }
}
