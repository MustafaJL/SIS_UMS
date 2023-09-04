using System.ComponentModel.DataAnnotations;

namespace SIS_UMS.Models
{
    /// <summary>
    /// Represents an StudentCoure model
    /// </summary>
    public class StudentCourse
    {
        [Required(ErrorMessage = "StudentId is required!")]
        public string? StudentId { get; set; }

        [Required(ErrorMessage = "CourseName is required.")]
        [StringLength(100, ErrorMessage = "CourseName is required!")]
        public string? CourseName { get; set; }

        [Required(ErrorMessage = "CourseStatus is required.")]
        [StringLength(100, ErrorMessage = "Course Status is required!")]
        public string? CourseStatus { get; set; }

        [Required(ErrorMessage = "CreatedAt is required!")]
        [Display(Name = "Course Created At")]
        [DataType(DataType.DateTime)]
        public DateTime CreatedAt { get; set; }
    }


}
