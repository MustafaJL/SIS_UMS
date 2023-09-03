namespace SIS_UMS.Models
{
    /// <summary>
    /// Represents an ApplicationForm model
    /// </summary>
    public class ApplicationForm
    {
        public int FormId { get; set; }
        public string? OfficeName { get; set; }
        public string? StudentId { get; set; }
        public DateTime ApplicationDate { get; set; }
        public string? ApplicationType { get; set; }
        public string? Status { get; set; }
        public string? AdditionalApplicationDetails { get; set; }
    }


}
