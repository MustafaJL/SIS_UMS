namespace SIS_UMS.Models
{
    public class Campus
    {
        public int? campus_id { get; set; }
        public string? campus_name { get; set; }
        public string? campus_address { get; set; }
        public string? campus_phone_number { get; set; }
        public string? campus_email { get; set; }
        public string? campus_fax{ get; set; }
        public Boolean? is_deleted { get; set; }
        public DateTime? created_at { get;set; }  
    }
}
