namespace SIS_UMS.Models
{
    public class Department
    {
        public int department_id{get; set;}
        public int faculty_id{get; set;}
        public string faculty_name { get; set; }
        public string department_name{get; set;}
        public string department_phone_number{get; set;}
        public string department_uni_email{get; set;}
        public bool is_deleted{get; set;}
        public DateTime created_at{get; set;}
    }
}
