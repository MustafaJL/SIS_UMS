namespace SIS_UMS.Models.View_Model
{
    public class FacultyUserCampusViewModel
    {
        public Faculty? faculty { get; set; }
        public IEnumerable<User>? users { get; set; }
        public IEnumerable<Campus>? campuses { get; set; }
    }
}
