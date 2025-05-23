using MediatR;
using Microsoft.EntityFrameworkCore;
using Panase.Application.Features.Users.Login.Dtos;
using Panase.Core.JwtToken;
using Panase.Infrastructure.Data;
using System.Security.Cryptography;
using System.Text;

namespace Panase.Application.Features.Users.Login.Queries
{
    public class LoginQueryHandler : IRequestHandler<LoginQuery, LoginResponse>
    {
        private readonly ApiContext _context;
        private readonly IJwtTokenGenerator _jwtTokenGenerator;

        public LoginQueryHandler(ApiContext context, IJwtTokenGenerator jwtTokenGenerator)
        {
            _context = context;
            _jwtTokenGenerator = jwtTokenGenerator;
        }

        public async Task<LoginResponse> Handle(LoginQuery request, CancellationToken cancellationToken)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Email == request.LoginRequest.Email, cancellationToken);

            if (user == null)
                throw new Exception("Invalid credentials.");

            // Basit password hash kontrolü örneği (gelişmiş hash önerilir)
            var hashedPassword = HashPassword(request.LoginRequest.Password);

            if (user.PasswordHash != hashedPassword)
                throw new Exception("Invalid credentials.");

            var token = _jwtTokenGenerator.GenerateToken(user.Id, user.Email, user.Role);


            return new LoginResponse(
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
