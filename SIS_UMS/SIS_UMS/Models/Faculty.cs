using System;

namespace SIS_UMS.Models
{
    public class Faculty
    {
        public int? FacultyId { get; set; }
        public int? CampusId { get; set; }
        public int? DeanUserId { get; set; }
        public string? FacultyName { get; set; }
        public string? FacultyPhoneNumber { get; set; }
        public string? FacultyUniEmail { get; set; }
        public bool? IsDeleted { get; set; }
        public DateTime? CreatedAt { get; set; }
    }
}