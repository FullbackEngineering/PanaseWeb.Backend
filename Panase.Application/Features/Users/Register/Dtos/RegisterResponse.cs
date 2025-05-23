using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Panase.Application.Features.Users.Register.Dtos
{
    public record RegisterResponse(
    string Token,
    string FirstName,
    string LastName,
    string Email,
    string Role
);
}
