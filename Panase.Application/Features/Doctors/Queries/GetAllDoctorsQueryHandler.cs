using AutoMapper;
using MediatR;
using Panase.Application.Features.Doctors.Dtos;
using Panase.Application.Features.Patients.Dtos;
using Panase.Application.Features.Patients.Queries;
using Panase.Core.Entities;
using Panase.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Panase.Application.Features.Doctors.Queries
{
    public class GetAllDoctorsQueryHandler : IRequestHandler<GetAllDoctorsQuery, IEnumerable<DoctorDto>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetAllDoctorsQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<IEnumerable<DoctorDto>> Handle(GetAllDoctorsQuery request, CancellationToken cancellationToken)
        {
            var doctors = await _unitOfWork.Repository<Doctor>().GetAllAsync();
            return _mapper.Map<IEnumerable<DoctorDto>>(doctors);
        }
    }
}
