using MediatR;
using Panase.Application.Common.Exceptions;
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
    public class DeleteDoctorCommandHandler: IRequestHandler<DeleteDoctorCommand,Unit>
    {
        private readonly IUnitOfWork _unitOfWork;

        public DeleteDoctorCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Unit> Handle(DeleteDoctorCommand request, CancellationToken cancellationToken)
        {
            var doctor = await _unitOfWork.Repository<Doctor>().GetByIdAsync(request.Id);
            if (doctor == null)
            {
                throw new NotFoundException(nameof(Doctor), request.Id);
            }

            _unitOfWork.Repository<Doctor>().Remove(doctor);
            await _unitOfWork.SaveChangesAsync();

            return Unit.Value;
        }
    }
}
