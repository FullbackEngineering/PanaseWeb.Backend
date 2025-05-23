using FluentValidation;
using Panase.Application.Features.SessionNotes.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Panase.Application.Features.SessionNotes.Validators
{
    public class CreateSessionNoteCommandValidator : AbstractValidator<CreateSessionNoteCommand>
    {
        public CreateSessionNoteCommandValidator()
        {
            RuleFor(x => x.Note)
                .NotEmpty().WithMessage("Not alanı boş olamaz.")
                .MaximumLength(1000).WithMessage("Not en fazla 1000 karakter olabilir.");

            RuleFor(x => x.AppointmentId)
                .NotEmpty().WithMessage("AppointmentId boş olamaz.");
        }
    }


}
