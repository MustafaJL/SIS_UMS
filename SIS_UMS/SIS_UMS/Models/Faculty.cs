namespace SIS_UMS.Models
{
    public class Faculty
    {
        public int faculty_id { get; set; }
        public int campus_id { get; set; }

        public string? campus_name { get; set; }
        public int dean_user_id { get; set; }
        public string? dean_user_name { get; set; }
        public string faculty_name { get; set; }
        public string faculty_phone_number { get; set; }
        public string faculty_uni_email { get; set; }
        public bool is_deleted { get; set; }
        public DateTime created_at { get; set; }
    }
}
