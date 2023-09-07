namespace SIS_UMS.Models.ViewModels
{
    public class BlockViewModel
    {
        public int block_id { get; set; }
        public int campus_id { get; set; }
        public DateTime created_at { get; set; }
        public string block_code { get; set; }
        public int floor_count { get; set; }
        public int room_count { get; set; }
        public string campus_name { get; set; }
    }
}