using MediatR;

namespace Panase.Application.Feature.Appointments.Commands
{
    public class CreateAppointmentCommand : IRequest<Guid>
    {
        public DateTime AppointmentDate { get; set; }
        public string Status { get; set; } = null!;
        public Guid PatientId { get; set; }
        public Guid DoctorId { get; set; }
    }
}
