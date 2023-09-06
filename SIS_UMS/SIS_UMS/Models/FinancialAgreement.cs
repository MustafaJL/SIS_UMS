using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SIS_UMS.Models;

/// <summary>
/// Represents a Financial Agreement form.
/// </summary>
public class FinancialAgreement
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [Display(Name = "Financial Agreement ID")]
    public int FinancialAgreementId { get; set; }

    [Required(ErrorMessage = "Office Name is required.")]
    [Display(Name = "Office Name")]
    public string? OfficeName { get; set; }

    [Required(ErrorMessage = "Student ID is required.")]
    [StringLength(10, ErrorMessage = "Student ID must be a maximum of 10 characters.")]
    [Display(Name = "Student ID")]
    public string? StudentId { get; set; }

    [Required(ErrorMessage = "Agreement Date is required.")]
    [Display(Name = "Agreement Date")]
    [DataType(DataType.Date)]
    public DateTime AgreementDate { get; set; }

    [Display(Name = "Agreement Details")]
    public string? AgreementDetails { get; set; }

    [Required(ErrorMessage = "Start Date is required.")]
    [Display(Name = "Start Date")]
    [DataType(DataType.Date)]
    public DateTime StartDate { get; set; }

    [Required(ErrorMessage = "End Date is required.")]
    [Display(Name = "End Date")]
    [DataType(DataType.Date)]
    public DateTime EndDate { get; set; }

    [Display(Name = "Is Active")]
    public bool IsActive { get; set; }
}
