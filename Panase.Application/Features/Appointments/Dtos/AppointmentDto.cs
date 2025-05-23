using Panase.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Panase.Application.Features.Appointments.Dtos
{
    public class AppointmentDto
    {
        public Guid Id { get; set; }
        public DateTime AppointmentDate { get; set; }
        public string Status { get; set; } = null!;
        public Guid PatientId { get; set; }
        public Guid DoctorId { get; set; }
    }
}
