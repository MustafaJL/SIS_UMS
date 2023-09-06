namespace SIS_UMS.Models
{
    public class RoomViewModel
    {
        public int room_id { get; set; }

        public int block_id { get; set; }
        public string room_code { get; set; }
        public int floor_number { get; set; }
        public int room_capacity { get; set; }
        public char block_code { get; set; }
        public DateTime created_at { get; set; }


    }
}
