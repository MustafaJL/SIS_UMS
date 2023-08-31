namespace SIS_UMS.DatabaseHelper.Interfaces
{
    public interface ICampusRepository
    {
        bool CreateCampus(string? campus_name, string? campus_address, string? campus_phone_number, string? campus_email, string? campus_fax);
    }
}
