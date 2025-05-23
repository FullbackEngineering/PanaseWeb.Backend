using AutoMapper;
using MediatR;
using Panase.Application.Features.Doctors.Dtos;
using Panase.Application.Features.Patients.Commands;
using Panase.Core.Entities;
using Panase.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Panase.Application.Features.Doctors.Commands
{
    public class CreateDoctorCommandHandler:IRequestHandler<CreateDoctorCommand, Guid>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CreateDoctorCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Guid> Handle(CreateDoctorCommand request, CancellationToken cancellationToken)
        {
            var doctor = _mapper.Map<Doctor>(request);

            await _unitOfWork.Repository<Doctor>().AddAsync(doctor);
            await _unitOfWork.SaveChangesAsync();

            return doctor.Id;
        }
    }
}
