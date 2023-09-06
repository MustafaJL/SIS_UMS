namespace SIS_UMS.Models
{
    public class Major
    {
        public int major_id{ get; set;}
        public int department_id{ get; set;}
        public string department_name { get; set;}
        public string major_name{ get; set;}
        public int university_requirements{ get; set;}
        public int department_requirements{ get; set;}
        public int concentration_requirements{ get; set;}
        public int elective_requirements{ get; set;}
        public bool is_deleted{ get; set;}
        public DateTime created_at{ get; set;}
    }
}
