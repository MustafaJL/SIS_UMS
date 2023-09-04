using System;
using System.ComponentModel.DataAnnotations;

namespace SIS_UMS.Models
{
    public class SemesterCode
    {
        public int? SemesterCodeId { get; set; }

        public string? SemesterCodeName { get; set; }

        public bool? IsDeleted { get; set; }

        public DateTime? CreatedAt { get; set; }
    }
}