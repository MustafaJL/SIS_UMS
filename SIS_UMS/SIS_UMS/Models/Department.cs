using System;

namespace SIS_UMS.Models
{
    public class Department
    {
        public int? DepartmentId { get; set; }
        public int? FacultyId { get; set; }
        public string? DepartmentName { get; set; }
        public string? DepartmentPhoneNumber { get; set; }
        public string? DepartmentUniEmail { get; set; }
        public bool? IsDeleted { get; set; }
        public DateTime? CreatedAt { get; set; }
    }
}