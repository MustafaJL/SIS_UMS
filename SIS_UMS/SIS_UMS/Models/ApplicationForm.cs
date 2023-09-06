using System.ComponentModel.DataAnnotations;

namespace SIS_UMS.Models
{
    /// <summary>
    /// Represents an ApplicationForm model
    /// </summary>
    public class ApplicationForm
    {
        [Key]
        public int FormId { get; set; }

        [Required(ErrorMessage = "Office Name is required!")]
        [StringLength(255, ErrorMessage = "Office Name must be less than 255 characters.")]
        public string? OfficeName { get; set; }

        [Required(ErrorMessage = "Student ID is required!")]
        [StringLength(10, ErrorMessage = "Student ID must be less than 10 characters.")]
        public string? StudentId { get; set; }

        [Required(ErrorMessage = "Application Date is required!")]
        [DataType(DataType.Date, ErrorMessage = "Invalid date format.")]
        public DateTime ApplicationDate { get; set; }

        [Required(ErrorMessage = "Application Type is required!")]
        [StringLength(255, ErrorMessage = "Application Type must be less than 255 characters.")]
        public string? ApplicationType { get; set; }

        [Required(ErrorMessage = "Status is required!")]
        [StringLength(255, ErrorMessage = "Status must be less than 255 characters.")]
        public string? Status { get; set; }

        [StringLength(1000, ErrorMessage = "Additional Application Details must be less than 1000 characters!")]
        public string? AdditionalApplicationDetails { get; set; }
    }


}
