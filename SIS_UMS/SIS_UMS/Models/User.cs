using System;

namespace SIS_UMS.Models
{
    public class User
    {
        public int user_id { get; set; }

        public string user_password { get; set; } = "changeme";

        public string? password_salt { get; set; }

        public int campus_id { get; set; }

        public int? manager_user_id { get; set; }

        public string first_name { get; set; } = "";

        public string middle_name { get; set; } = "";

        public string last_name { get; set; } = "";

        public string mother_name { get; set; } = "";

        public string emergency_contact_name { get; set; } = "";

        public string? personal_email { get; set; }

        public string? university_email { get; set; }

        public string gender { get; set; }

        public DateTime date_of_birth { get; set; }

        public int? ssn { get; set; }

        public string city { get; set; } = "";

        public string area { get; set; } = "";

        public string street { get; set; } = "";

        public string near_by { get; set; } = "";

        public string building { get; set; } = "";

        public int floor { get; set; }

        public string? marital_status { get; set; }

        public int children_count { get; set; }

        public string blood_type { get; set; }

        public string family_registration { get; set; } = "";

        public string place_of_birth { get; set; } = "";

        public string social_security_type { get; set; } = "";

        public decimal? rating { get; set; }

        public string? additional_info { get; set; }

        public bool? is_deleted { get; set; }

        public DateTime? created_at { get; set; }
    }
}