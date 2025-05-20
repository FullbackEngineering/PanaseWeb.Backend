using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Panase.Application.Feature.Doctors.Commands
{
    public class DeleteDoctorCommand: IRequest<Unit>
    {
        public Guid Id { get; set; }
    }
}
