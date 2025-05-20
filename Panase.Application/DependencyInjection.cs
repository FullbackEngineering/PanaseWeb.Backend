using System.Reflection;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Panase.Application.Common.Mapping;
using Panase.Application.Feature.Appointments.Validators;
using Panase.Application.Feature.Doctors.Validators;
using Panase.Application.Feature.Patients.Validators;

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

            // FluentValidation kayıtları (örneğin Patient validator)
            services.AddValidatorsFromAssemblyContaining<CreatePatientCommandValidator>();
            services.AddValidatorsFromAssemblyContaining<CreateAppointmentCommandValidator>();
            services.AddValidatorsFromAssemblyContaining<CreateDoctorCommandValidator>();

            return services;
        }
    }
}
