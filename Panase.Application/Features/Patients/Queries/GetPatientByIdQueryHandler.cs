using AutoMapper;
using MediatR;
using Panase.Application.Common.Exceptions;
using Panase.Application.Features.Patients.Dtos;
using Panase.Core.Entities;
using Panase.Core.Interfaces;

namespace Panase.Application.Features.Patients.Queries
{
    public class GetPatientByIdQueryHandler : IRequestHandler<GetPatientByIdQuery, PatientDto>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetPatientByIdQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<PatientDto> Handle(GetPatientByIdQuery request, CancellationToken cancellationToken)
        {
            var patient = await _unitOfWork.Repository<Patient>().GetByIdAsync(request.Id);
            if (patient == null)
            {
                throw new NotFoundException(nameof(Patient), request.Id);
            }

            return _mapper.Map<PatientDto>(patient);
        }
    }
}
