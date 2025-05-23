using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Panase.Application.Features.Patients.Commands
{
    public class DeletePatientCommand: IRequest<Unit>
    {
        public Guid Id { get; set; }
    }
}
