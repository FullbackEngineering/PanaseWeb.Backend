using FluentValidation;
using Panase.Application.Features.SessionNotes.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Panase.Application.Features.SessionNotes.Validators
{
    public class DeleteSessionNoteCommandValidator : AbstractValidator<DeleteSessionNoteCommand>
    {
        public DeleteSessionNoteCommandValidator()
        {
            RuleFor(x => x.Id)
                .NotEmpty().WithMessage("Id boş olamaz.");
        }
    }

}
