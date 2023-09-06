namespace SIS_UMS.Models
{
    public class block
    {
        public int block_id { get; set; }
        public int campus_id { get; set; }
        public string block_code { get; set; }
        public int floor_count { get; set; }
        public int room_count { get; set; }
        public bool is_deleted { get; set; } = false;
        public DateTime created_at { get; set; } = DateTime.Now;
    }
}
