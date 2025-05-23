using AutoMapper;
using MediatR;
using Panase.Application.Common.Exceptions;
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
    public class GetByIdDoctorQueryHandler:IRequestHandler<GetByIdDoctorQuery, DoctorDto>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetByIdDoctorQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<DoctorDto> Handle(GetByIdDoctorQuery request, CancellationToken cancellationToken)
        {
            var doctor = await _unitOfWork.Repository<Doctor>().GetByIdAsync(request.Id);
            if (doctor == null)
            {
                throw new NotFoundException(nameof(Doctor), request.Id);
            }

            return _mapper.Map<DoctorDto>(doctor);
        }
    }
}
