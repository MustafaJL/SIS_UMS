using SIS_UMS.Models;

namespace SIS_UMS.DatabaseHelper.Interfaces
{
    public interface IDepartmentRepository
    {
        IEnumerable<Department> GetAllDepartmentsInAFaculty(int faculty_id);
        void CreateDepartment(int faculty_id, string department_name, string department_phone_number, string department_uni_email);
        IEnumerable<Department> GetAllDepartments();
        
        Department GetDepartment(int departmentid);

        void EditDepartment(int department_id, int faculty_id, string department_name, string department_phone_number, string department_uni_email);

        Task<bool> DeleteDepartment(int id);
    }
}
