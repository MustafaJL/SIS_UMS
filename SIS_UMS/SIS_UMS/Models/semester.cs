using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SIS_UMS.Models
{
    public class Semester
    {
        public int SemesterId { get; set; }
        public int AcademicYearId { get; set; }
        public string SemesterName { get; set; }
        public int SemesterCodeId { get; set; }
        public bool IsCourseWithdrawWithRefundEndDate { get; set; }
        public bool IsSemesterWithdrawWithRefundEndDate { get; set; }
        public bool IsRegistrationStartDate { get; set; }
        public bool IsRegistrationEndDate { get; set; }
        public bool? IsDeleted { get; set; }
        public DateTime? CreatedAt { get; set; }
        [ForeignKey("AcademicYearId")]
        public AcademicYear AcademicYear { get; set; }
        [ForeignKey("SemesterCodeId")]
        public SemesterCode SemesterCode { get; set; }
    }
}