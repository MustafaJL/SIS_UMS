using System;
using System.ComponentModel.DataAnnotations;

namespace SIS_UMS.Models
{
    public class Campus
    {
        public int? CampusId { get; set; }

        public string? CampusName { get; set; }

        public string? CampusAddress { get; set; }

        public string? CampusPhoneNumber { get; set; }

        public string? CampusFax { get; set; }

        public string? CampusEmail { get; set; }
    }
}