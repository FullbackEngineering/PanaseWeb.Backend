using AutoMapper;
using MediatR;
using Panase.Core.Entities;
using Panase.Core.Interfaces;

namespace Panase.Application.Features.Appointments.Commands
{
    public class UpdateAppointmentCommandHandler : IRequestHandler<UpdateAppointmentCommand, Unit>
    {

        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UpdateAppointmentCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {

            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(UpdateAppointmentCommand request, CancellationToken cancellationToken)
        {
            var appointment = await _unitOfWork.Repository<Appointment>().GetByIdAsync(request.Id);
            if (appointment == null)

                throw new Exception("Appointment not found");

            // Map update fields from request to entity
            _mapper.Map(request, appointment);

            await _unitOfWork.SaveChangesAsync();

            return Unit.Value;
        }
    }
}