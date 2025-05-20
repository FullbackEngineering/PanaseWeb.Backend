using MediatR;
using Panase.Application.Feature.Appointments.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Panase.Application.Feature.Appointments.Queries
{
    public class GetAllAppointmentsQuery:IRequest<IEnumerable<AppointmentDto>>
    {
    }
}
