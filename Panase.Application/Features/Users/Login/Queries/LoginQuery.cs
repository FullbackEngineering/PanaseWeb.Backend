using MediatR;
using Panase.Application.Features.Users.Login.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Panase.Application.Features.Users.Login.Queries
{
    public record LoginQuery(LoginRequest LoginRequest) : IRequest<LoginResponse>;
}
