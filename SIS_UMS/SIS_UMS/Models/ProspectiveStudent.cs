namespace SIS_UMS.Models
{
    public class ProspectiveStudent
    {
        public int? ProspectiveStudentId { get; set; }
        public int? UserId { get; set; }
        public int? SemesterId { get; set; }
        public int? FacultyId { get; set; }
        public int? MajorId { get; set; }
        public string? EnglishLevel { get; set; }
        public string? ArabicLevel { get; set; }
        public string? FrenchLevel { get; set; }
        public string? AdditionalLanguage { get; set; }
        public string? StudentStatus { get; set; }
        public bool? IsDeleted { get; set; }
        public DateTime? CreatedAt { get; set; }
    }

}
