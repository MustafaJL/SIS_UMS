using SIS_UMS.Models;

namespace SIS_UMS.DatabaseHelper.Interfaces
{
    public interface ICampusRepository
    {
        bool CreateCampus(string? campus_name, string? campus_address, string? campus_phone_number, string? campus_email, string? campus_fax);
        IEnumerable<Campus> GetAllCampuses();
        Campus GetCampus(int campus_id);
        bool EditCampus(int? campus_id,string? campus_name, string? campus_address, string? campus_phone_number, string? campus_fax, string? campus_email);
        void DeleteCampus(int campus_id);

    }
}
