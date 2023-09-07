namespace SIS_UMS.Models.View_Model
{
    public class MajorDepartmentViewModel
    {
        public Major major { get; set; }
        public IEnumerable<Department> departments { get; set; }
    }
}
