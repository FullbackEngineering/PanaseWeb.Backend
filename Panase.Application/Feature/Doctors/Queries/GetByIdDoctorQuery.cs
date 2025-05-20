using MediatR;
using Panase.Application.Feature.Doctors.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace Panase.Application.Feature.Doctors.Queries
{
    public class GetByIdDoctorQuery:IRequest<DoctorDto>
    {
        public Guid Id { get; set; }
    }
}
