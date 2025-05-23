using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Panase.Core.Entities
{
    public class Patient : BaseEntity
    {
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string PhoneNumber { get; set; } = string.Empty;

        // Randevular
        public ICollection<Appointment> Appointments { get; set; } = new List<Appointment>();

        // Zorunlu User bağlantısı (1-1)
        public Guid UserId { get; set; }
        public User User { get; set; } = null!;

    }

}
