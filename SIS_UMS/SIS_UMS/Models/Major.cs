using System;

namespace SIS_UMS.Models
{
    public class Major
    {
        public int? MajorId { get; set; }
        public int? DepartmentId { get; set; }
        public string? MajorName { get; set; }
        public int? UniversityRequirements { get; set; }
        public int? DepartmentRequirements { get; set; }
        public int? ConcentrationRequirements { get; set; }
        public int? ElectiveRequirements { get; set; }
        public bool? IsDeleted { get; set; }
        public DateTime? CreatedAt { get; set; }
    }
}