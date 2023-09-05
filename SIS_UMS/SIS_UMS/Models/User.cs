using System;
using System.ComponentModel.DataAnnotations;

namespace SIS_UMS.Models
{
    public class User
    {
        public int username { get; set; }
        public string password_salt { get; set; }

        [Display(Name = "Password")]
        public string user_password { get; set; }

       
    }
}
