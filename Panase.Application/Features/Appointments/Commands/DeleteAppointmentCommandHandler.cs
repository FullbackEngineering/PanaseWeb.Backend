using MediatR;
using Panase.Application.Common.Exceptions;
using Panase.Core.Entities;
using Panase.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Panase.Application.Features.Appointments.Commands
{
    public class DeleteAppointmentCommandHandler : IRequestHandler<DeleteAppointmentCommand, Unit>
    {
        private readonly IUnitOfWork _unitOfWork;

        public DeleteAppointmentCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Unit> Handle(DeleteAppointmentCommand request, CancellationToken cancellationToken)
        {
            var appointment = await _unitOfWork.Repository<Appointment>().GetByIdAsync(request.Id);
            if (appointment == null)
            {
                throw new NotFoundException(nameof(Appointment), request.Id);
            }

            _unitOfWork.Repository<Appointment>().Remove(appointment);
            await _unitOfWork.SaveChangesAsync();

            return Unit.Value;
        }
    }
}