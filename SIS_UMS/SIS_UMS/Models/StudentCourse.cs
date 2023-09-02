namespace SIS_UMS.Models
{
    /// <summary>
    /// Represents an StudentCoure model
    /// </summary>
    public class StudentCourse
    {
        public string? StudentId { get; set; }
        public string? CourseName { get; set; }
        public string? CourseStatus { get; set; }
        public DateTime CreatedAt { get; set; }
    }


}
