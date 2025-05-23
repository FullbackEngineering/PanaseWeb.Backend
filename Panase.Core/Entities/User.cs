using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Panase.Core.Entities
{
    public class User : BaseEntity
    {
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string PasswordHash { get; set; } = string.Empty;

        // Role: "Admin", "Doctor", "Patient" vs.
        public string Role { get; set; } = string.Empty;

        // Navigation (opsiyonel)
        public Doctor? DoctorProfile { get; set; }
        public Patient? PatientProfile { get; set; }
    }

}
