using AutoMapper;
using MediatR;
using Panase.Application.Features.Patients.Dtos;
using Panase.Core.Entities;
using Panase.Core.Interfaces;

namespace Panase.Application.Features.Patients.Queries
{
    public class GetAllPatientsQueryHandler : IRequestHandler<GetAllPatientsQuery, IEnumerable<PatientDto>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetAllPatientsQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<IEnumerable<PatientDto>> Handle(GetAllPatientsQuery request, CancellationToken cancellationToken)
        {
            var patients = await _unitOfWork.Repository<Patient>().GetAllAsync();
            return _mapper.Map<IEnumerable<PatientDto>>(patients);
        }
    }
}
