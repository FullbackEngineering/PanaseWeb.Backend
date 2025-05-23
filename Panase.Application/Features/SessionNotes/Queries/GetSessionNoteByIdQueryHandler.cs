using AutoMapper;
using MediatR;
using Panase.Application.Common.Exceptions;
using Panase.Application.Features.SessionNotes.Dtos;
using Panase.Core.Entities;
using Panase.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Panase.Application.Features.SessionNotes.Queries
{
    public class GetSessionNoteByIdQueryHandler : IRequestHandler<GetSessionNoteByIdQuery, SessionNoteDto>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetSessionNoteByIdQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<SessionNoteDto> Handle(GetSessionNoteByIdQuery request, CancellationToken cancellationToken)
        {
            var entity = await _unitOfWork.Repository<SessionNote>().GetByIdAsync(request.Id);
            if (entity == null)
                throw new NotFoundException(nameof(SessionNote), request.Id);

            return _mapper.Map<SessionNoteDto>(entity);
        }
    }
}
