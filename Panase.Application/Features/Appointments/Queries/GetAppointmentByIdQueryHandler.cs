using AutoMapper;
using MediatR;
using Panase.Application.Common.Exceptions;
using Panase.Application.Features.Appointments.Dtos;
using Panase.Application.Features.Patients.Dtos;
using Panase.Application.Features.Patients.Queries;
using Panase.Core.Entities;
using Panase.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Panase.Application.Features.Appointments.Queries
{
    public class GetAppointmentByIdQueryHandler:IRequestHandler<GetAppointmentByIdQuery, AppointmentDto>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetAppointmentByIdQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<AppointmentDto> Handle(GetAppointmentByIdQuery request, CancellationToken cancellationToken)
        {
            var appointment = await _unitOfWork.Repository<Appointment>().GetByIdAsync(request.Id);
            if (appointment == null)
            {
                throw new NotFoundException(nameof(Appointment), request.Id);
            }

            return _mapper.Map<AppointmentDto>(appointment);
        }
    }
}
