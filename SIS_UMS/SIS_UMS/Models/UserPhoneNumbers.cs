using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace SIS_UMS.Models
{
    public class UserPhoneNumbers
    {
        public int UserPhoneNumberId { get; set; }

        public int UserId { get; set; }

        public string PhoneNumber { get; set; }

        public bool IsPrimaryPhone { get; set; }

        public bool IsPersonalPhone { get; set; }

        public bool IsEmergencyPhone { get; set; }

        public bool IsLandLine { get; set; }

        public bool? IsDeleted { get; set; }

        public DateTime CreatedAt { get; set; }
    }
}
