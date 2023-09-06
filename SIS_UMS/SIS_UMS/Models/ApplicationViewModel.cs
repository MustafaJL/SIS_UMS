﻿using System.Security.Cryptography.X509Certificates;

namespace SIS_UMS.Models
{
    public class ApplicationViewModel
    {
        public User user { get; set; }
        public ProspectiveStudent student { get; set; }
        public UserPhoneNumbers PersonalPhoneNumber { get; set; }
        public UserPhoneNumbers EmergencyPhoneNumber { get; set; }
        public IEnumerable<Campus> campuses { get; set; }
        public IEnumerable<Faculty> faculties { get; set; }
        public IEnumerable<Department> departments { get; set; }
        public IEnumerable<Major> majors { get; set; }
        public IEnumerable<Semester> semesters { get; set; }
    }
}