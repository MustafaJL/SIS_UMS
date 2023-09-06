namespace SIS_UMS.Models.View_Model
{
    public class DepartmentFacultyViewModel
    {
        public Department department { get; set; }
        public IEnumerable<Faculty> faculties { get; set; }
    }
}
