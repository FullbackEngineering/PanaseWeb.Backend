using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Panase.Core.Entities
{
    public class Appointment:BaseEntity
    {
        public DateTime AppointmentDate { get; set; }
        public string Status { get; set; } = null!;

        // Foreign keys
        public Guid PatientId { get; set; }
        public Guid DoctorId { get; set; }

        // Navigation properties
        public Patient Patient { get; set; } = null!;
        public Doctor Doctor { get; set; } = null!;
        public ICollection<SessionNote> SessionNotes { get; set; } = new List<SessionNote>();
    }
}
