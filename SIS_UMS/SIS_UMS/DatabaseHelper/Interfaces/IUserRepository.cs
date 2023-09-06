using SIS_UMS.Models;

namespace SIS_UMS.DatabaseHelper.Interfaces
{
    public interface IUserRepository
    {
        IEnumerable<User> GetAllUsers();
        string GetUserName(int userid);
    }
}
