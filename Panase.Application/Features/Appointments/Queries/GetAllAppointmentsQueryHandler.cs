using AutoMapper;
using MediatR;
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
    public class GetAllAppointmentsQueryHandler : IRequestHandler<GetAllAppointmentsQuery, IEnumerable<AppointmentDto>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetAllAppointmentsQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<IEnumerable<AppointmentDto>> Handle(GetAllAppointmentsQuery request, CancellationToken cancellationToken)
        {
            var appointments = await _unitOfWork.Repository<Appointment>().GetAllAsync();
            return _mapper.Map<IEnumerable<AppointmentDto>>(appointments);
        }
    }
}
