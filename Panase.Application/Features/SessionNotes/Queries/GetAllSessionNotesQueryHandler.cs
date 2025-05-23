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
    public class GetAllSessionNotesQueryHandler : IRequestHandler<GetAllSessionNotesQuery, List<SessionNoteDto>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetAllSessionNotesQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<List<SessionNoteDto>> Handle(GetAllSessionNotesQuery request, CancellationToken cancellationToken)
        {
            var list = await _unitOfWork.Repository<SessionNote>().GetAllAsync();
            return _mapper.Map<List<SessionNoteDto>>(list);
        }
    }

}

