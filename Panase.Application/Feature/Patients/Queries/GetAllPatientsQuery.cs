using MediatR;
using Panase.Application.Feature.Patients.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Panase.Application.Feature.Patients.Queries
{
    public class GetAllPatientsQuery: IRequest<IEnumerable<PatientDto>> 
    {
    }
}
