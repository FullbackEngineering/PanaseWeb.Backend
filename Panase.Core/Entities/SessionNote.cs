using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Panase.Core.Entities
{
    public class SessionNote:BaseEntity
    {
        public string Note { get; set; } = null!;
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        // Foreign key
        public Guid AppointmentId { get; set; }

        // Navigation property
        public Appointment Appointment { get; set; } = null!;
    }
}
