using FluentValidation;
using Panase.Application.Features.Appointments.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Panase.Application.Features.Appointments.Validators
{
    public class DeleteAppointmentCommandValidator : AbstractValidator<DeleteAppointmentCommand>
    {
        public DeleteAppointmentCommandValidator()
        {
            RuleFor(x => x.Id)
            .NotEmpty().WithMessage("Appointment Id is required.");
        }
    }
}
