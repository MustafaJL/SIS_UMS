using SIS_UMS.Models;

namespace SIS_UMS.DatabaseHelper.Interface
{
    /// <summary>
    /// Represents a repository for Scholarships .
    /// </summary>
    public interface IScholarshipsRepository
    {
        /// <summary>
        /// Retrieves all Scholarships from the repository.
        /// </summary>
        /// <returns>An enumerable collection of Scholarships objects contains [scholarship_id, scholarship_type, percentage_in_dollar,percentage_in_lebanese].</returns>
        IEnumerable<Scholarships> GetAllScholarships();

        /// <summary>
        /// Creates a new user with the specified name and age.
        /// </summary>
        /// <param name="StudentId">The id of the student.</param>
        /// <param name="scholarship_type">The type of the scholarship.</param>
        /// <param name="percentage_in_dollar">The % in $ of the scholarship.</param>
        /// <param name="percentage_in_lebanese">The % in L.L of the scholarship.</param>
        void AddScholarship(string? scholarship_type,decimal? percentage_in_dollar,decimal? percentage_in_lebanese);


    }
}