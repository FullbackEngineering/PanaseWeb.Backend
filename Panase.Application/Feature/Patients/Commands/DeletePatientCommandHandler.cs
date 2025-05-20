using MediatR;
using Panase.Application.Common.Exceptions;
using Panase.Core.Entities;
using Panase.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Panase.Application.Feature.Patients.Commands
{
    public class DeletePatientCommandHandler: IRequestHandler<DeletePatientCommand, Unit>
    {
        private readonly IUnitOfWork _unitOfWork;

        public DeletePatientCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Unit> Handle(DeletePatientCommand request, CancellationToken cancellationToken)
        {
            var patient = await _unitOfWork.Repository<Patient>().GetByIdAsync(request.Id);
            if (patient == null)
            {
                throw new NotFoundException(nameof(Patient), request.Id);
            }

            _unitOfWork.Repository<Patient>().Remove(patient);
            await _unitOfWork.SaveChangesAsync();

            return Unit.Value;
        }
    }
}
