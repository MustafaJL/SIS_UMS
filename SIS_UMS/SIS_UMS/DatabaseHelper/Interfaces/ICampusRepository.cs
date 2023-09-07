using SIS_UMS.Models;

namespace SIS_UMS.DatabaseHelper.Interfaces
{
    public interface ICampusRepository
    {
        bool CreateCampus(string? campus_name, string? campus_address, string? campus_phone_number, string? campus_email, string? campus_fax);
        Task <IEnumerable<Campus>> GetAllCampuses();
        Task<Campus> GetCampus(int campus_id);
        bool EditCampus(int campus_id,Campus campus);
        void DeleteCampus(int campus_id);

    }
}
