using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SIS_UMS.Models;

/// <summary>
/// Represents Scholarships .
/// </summary>
public class Scholarships
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [Display(Name = "Scholarship Id")]
    public int? scholarship_id { get; set; }

    [Required(ErrorMessage = "scholarship type is required.")]
    [StringLength(100, ErrorMessage = "scholarship type is required!")]
    public string? scholarship_type { get; set; }

    [Required(ErrorMessage = "percentage in dollar is required.")]
    [StringLength(100, ErrorMessage = "percentage in dollar is required!")]
    public decimal? percentage_in_dollar { get; set; }

    [Required(ErrorMessage = "percentage in lebanese is required.")]
    [StringLength(100, ErrorMessage = "percentage in lebanese is required!")]
    public decimal? percentage_in_lebanese { get; set; }


    [Required(ErrorMessage = "CreatedAt is required!")]
    [Display(Name = "Course Created At")]
    [DataType(DataType.DateTime)]
    public DateTime created_at { get; set; }


}
