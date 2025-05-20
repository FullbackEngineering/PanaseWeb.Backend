using FluentValidation;
using Panase.Application.Feature.Doctors.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Panase.Application.Feature.Doctors.Validators
{
    public class DeleteDoctorCommandValidator : AbstractValidator<DeleteDoctorCommand>
    {
        public DeleteDoctorCommandValidator()
        {
            RuleFor(x => x.Id)
            .NotEmpty().WithMessage("Silinecek doktorun ID'si boş olamaz.");

        }
    }
}
