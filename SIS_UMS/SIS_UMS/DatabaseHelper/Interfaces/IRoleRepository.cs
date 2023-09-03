using SIS_UMS.Models;

namespace SIS_UMS.DatabaseHelper.Interfaces
{
    
    public interface IRoleRepository
    {
        IEnumerable<Role> GetAllRoles();

        void CreateRole(string? role_name);

        bool DeleteRole(int? role_id);

        
    }
}
