using System.Reflection;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Panase.Application.Common.Mapping;
using Panase.Application.Features.Appointments.Validators;
using Panase.Application.Features.Doctors.Validators;
using Panase.Application.Features.Patients.Validators;
using Panase.Application.Features.SessionNotes.Validators;
using Panase.Application.Features.Users.Login.Validators;
using Panase.Application.Features.Users.Register.Validators;
using Panase.Core.JwtToken;

namespace Panase.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            // MediatR handler'larını otomatik kaydet
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));

            // AutoMapper kayıtları
            services.AddAutoMapper(typeof(MappingProfile).Assembly);

            services.AddScoped<IJwtTokenGenerator, JwtTokenGenerator>();

            // FluentValidation kayıtları (örneğin Patient validator)
            services.AddValidatorsFromAssemblyContaining<CreatePatientCommandValidator>();
            services.AddValidatorsFromAssemblyContaining<CreateAppointmentCommandValidator>();
            services.AddValidatorsFromAssemblyContaining<CreateDoctorCommandValidator>();
            services.AddValidatorsFromAssemblyContaining<CreateSessionNoteCommandValidator>();
            services.AddValidatorsFromAssemblyContaining<RegisterCommandValidator>();
            services.AddValidatorsFromAssemblyContaining<LoginRequestValidator>();
            


            return services;
        }
    }
}
