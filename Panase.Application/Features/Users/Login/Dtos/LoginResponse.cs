using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Panase.Application.Features.Users.Login.Dtos
{
    public record LoginResponse(
    string Token,
    string FirstName,
    string LastName,
    string Email,
    string Role
);
}
