using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Panase.Application.Features.Users.Register.Dtos;
using Panase.Core.Entities;
using Panase.Core.Interfaces;
using Panase.Core.JwtToken;
using Panase.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Panase.Application.Features.Users.Register.Commands
{
    public class RegisterCommandHandler : IRequestHandler<RegisterRequest, RegisterResponse>
    {
        private readonly ApiContext _context;
        private readonly IJwtTokenGenerator _jwtTokenGenerator;

        public RegisterCommandHandler(ApiContext context, IJwtTokenGenerator jwtTokenGenerator)
        {
            _context = context;
            _jwtTokenGenerator = jwtTokenGenerator;
        }

        public async Task<RegisterResponse> Handle(RegisterRequest request, CancellationToken cancellationToken)
        {
            // Kullanıcının daha önce var olup olmadığını kontrol et
            if (await _context.Users.AnyAsync(u => u.Email == request.Email, cancellationToken))
            {
                throw new Exception("Bu email adresi zaten kayıtlı.");
            }

            // Şifreyi hashle
            var hashedPassword = HashPassword(request.Password);

            // Yeni kullanıcı oluştur
            var user = new User
            {
                Id = Guid.NewGuid(),
                FirstName = request.FirstName,
                LastName = request.LastName,
                Email = request.Email,
                PasswordHash = hashedPassword,
                Role = "Patient" // Sabit olarak atanıyor

            };

            _context.Users.Add(user);
            await _context.SaveChangesAsync(cancellationToken);

            // JWT oluştur
            var token = _jwtTokenGenerator.GenerateToken(user.Id, user.Email, user.Role);

            return new RegisterResponse(
                token,
                user.FirstName,
                user.LastName,
                user.Email,
                user.Role

                
            );
        }

        private string HashPassword(string password)
        {
            using var sha256 = SHA256.Create();
            var bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
            return Convert.ToBase64String(bytes);
        }
    }
}
