using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Panase.Core.Entities
{
    public class Doctor:BaseEntity
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Specialty { get; set; }

        public string Email { get; set; }

        public string PhoneNumber { get; set; }

        // Doktorun randevuları
        public ICollection<Appointment> Appointments { get; set; } = new List<Appointment>();

    }
}
