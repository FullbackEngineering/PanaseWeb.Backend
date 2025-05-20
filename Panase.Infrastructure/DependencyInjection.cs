using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Panase.Core.Interfaces;
using Panase.Infrastructure.Data;
using Panase.Infrastructure.Repositories;
namespace Panase.Infrastructure
    {
        public static class DependencyInjection
        {
            public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
            {
                // PostgreSQL bağlantısı
                // Repository & UnitOfWork
                services.AddScoped(typeof(IRepository<>), typeof(GenericRepository<>));
                services.AddScoped<IUnitOfWork, UnitOfWork>();

                // Örnek: Email servisi aktifse
                // services.AddScoped<IEmailService, EmailService>();

                return services;
            }
        }
    }



