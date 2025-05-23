using FluentValidation;
using Microsoft.AspNetCore.Identity.Data;

namespace Panase.Application.Features.Users.Register.Validators
{
    public class RegisterCommandValidator : AbstractValidator<RegisterRequest>
    {
        public RegisterCommandValidator()
        {
            RuleFor(x => x.Email)
                .NotEmpty().WithMessage("Email boş olamaz.")
                .EmailAddress().WithMessage("Geçerli bir email girin.");

            RuleFor(x => x.Password)
                .NotEmpty().WithMessage("Şifre boş olamaz.")
                .MinimumLength(6).WithMessage("Şifre en az 6 karakter olmalı.");

        }

    }
}
