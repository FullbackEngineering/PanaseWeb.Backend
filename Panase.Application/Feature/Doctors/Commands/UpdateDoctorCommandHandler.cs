using AutoMapper;
using MediatR;
using Panase.Application.Common.Exceptions;
using Panase.Core.Entities;
using Panase.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Panase.Application.Feature.Doctors.Commands
{
    public class UpdateDoctorCommandHandler: IRequestHandler<UpdateDoctorCommand,Unit>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UpdateDoctorCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(UpdateDoctorCommand request, CancellationToken cancellationToken)
        {
            var doctor = await _unitOfWork.Repository<Doctor>().GetByIdAsync(request.Id);
            if (doctor == null)
            {
                throw new NotFoundException(nameof(Doctor), request.Id);
            }

            _mapper.Map(request, doctor);

            _unitOfWork.Repository<Doctor>().Update(doctor);
            await _unitOfWork.SaveChangesAsync();

            return Unit.Value;
        }
    }
}
