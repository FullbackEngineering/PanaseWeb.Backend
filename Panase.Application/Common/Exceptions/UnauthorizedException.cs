using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Panase.Application.Common.Exceptions
{
    public class UnauthorizedException:ApplicationException
    {
        public UnauthorizedException(string message = "You are not authorized to perform this action.")
        : base(message)
        {
        }
    }
}
