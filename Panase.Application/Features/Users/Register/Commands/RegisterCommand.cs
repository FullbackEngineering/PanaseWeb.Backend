using MediatR;
using Panase.Application.Features.Users.Register.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Panase.Application.Features.Users.Register.Commands
{
    public record RegisterCommand(RegisterRequest RegisterRequest)
    : IRequest<RegisterResponse>;


}
