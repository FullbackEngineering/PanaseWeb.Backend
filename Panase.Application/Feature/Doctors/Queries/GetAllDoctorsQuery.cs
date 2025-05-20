using MediatR;
using Panase.Application.Feature.Doctors.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Panase.Application.Feature.Doctors.Queries
{
    public class GetAllDoctorsQuery:IRequest<IEnumerable<DoctorDto>> 
    {
    }
}
