using FluentValidation;
using Panase.Application.Features.Appointments.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Panase.Application.Features.Appointments.Validators
{
    public class CreateAppointmentCommandValidator: AbstractValidator<CreateAppointmentCommand>
    {
        public CreateAppointmentCommandValidator()
        {
            RuleFor(x => x.AppointmentDate)
                .NotEmpty().WithMessage("Appointment date is required.")
                .GreaterThan(DateTime.Now).WithMessage("Appointment date must be in the future.");

            RuleFor(x => x.Status)
                .NotEmpty().WithMessage("Status is required.")
                .MaximumLength(50).WithMessage("Status must not exceed 50 characters.");

            RuleFor(x => x.PatientId)
                .NotEmpty().WithMessage("PatientId is required.");

            RuleFor(x => x.DoctorId)
                .NotEmpty().WithMessage("DoctorId is required.");
        }
    }
}
