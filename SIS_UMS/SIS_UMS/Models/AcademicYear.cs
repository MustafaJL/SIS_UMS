using System;
using System.ComponentModel.DataAnnotations;

namespace SIS_UMS.Models
{
    public class AcademicYear
    {
        public int? AcademicYearId { get; set; }
        public string? AcademicYearRange { get; set; }
        public bool? IsDeleted { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
