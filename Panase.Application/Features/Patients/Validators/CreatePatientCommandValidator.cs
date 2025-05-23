using FluentValidation;
using Panase.Application.Features.Patients.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Panase.Application.Features.Patients.Validators
{
   public class CreatePatientCommandValidator: AbstractValidator<CreatePatientCommand>
    {
        public CreatePatientCommandValidator()
        {
            RuleFor(x => x.FirstName)
                .NotEmpty().WithMessage("Ad  boş olamaz.")
                .MaximumLength(100).WithMessage("Ad en fazla 100 karakter olabilir."); 

            RuleFor(x => x.LastName)
                .NotEmpty().WithMessage("Soyad  boş olamaz.")
                .MaximumLength(100).WithMessage("Ad en fazla 100 karakter olabilir.");

            RuleFor(x => x.Email)
                .EmailAddress().WithMessage("Geçerli bir email giriniz.");

            RuleFor(x => x.DateOfBirth)
                .LessThan(DateTime.Now).WithMessage("Doğum tarihi bugünden sonra olamaz.");
        }
    }
}
