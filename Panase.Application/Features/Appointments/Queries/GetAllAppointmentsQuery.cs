using MediatR;
using Panase.Application.Features.Appointments.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Panase.Application.Features.Appointments.Queries
{
    public class GetAllAppointmentsQuery:IRequest<IEnumerable<AppointmentDto>>
    {
    }
}
