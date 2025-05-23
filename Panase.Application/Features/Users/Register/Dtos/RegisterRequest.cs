using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Panase.Application.Features.Users.Register.Dtos
{
    public sealed class RegisterRequest:IRequest<RegisterResponse>
    {
        public required string Email { get; init; }
        public required string Password { get; init; }
        public required string FirstName { get; init; }
        public required string LastName { get; init; }
    }

}
