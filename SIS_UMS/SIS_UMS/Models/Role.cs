namespace SIS_UMS.Models
{
    public class Role
    {
        public int? role_id { get; set; }
        public string? role_name { get; set; }
        public Boolean? is_deleted { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}