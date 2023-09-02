using SIS_UMS.Models;

namespace SIS_UMS.DatabaseHelper.Interface
{
    /// <summary>
    /// Represents a repository for application form 
    /// </summary>
    public interface IApplicationFormRepository
    {
        IEnumerable<ApplicationForm> GetAllApplicationForms();
    }
}
