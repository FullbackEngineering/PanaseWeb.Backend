using MediatR;
using Panase.Application.Features.Patients.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Panase.Application.Features.Patients.Queries
{
    public class GetPatientByIdQuery:IRequest<PatientDto>
    {
        public Guid Id { get; set; }
    }
}
