using Panase.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Panase.Core.JwtToken
{
    public interface IJwtTokenGenerator
    {
        string GenerateToken(Guid userId, string email, string role);
    }
}
