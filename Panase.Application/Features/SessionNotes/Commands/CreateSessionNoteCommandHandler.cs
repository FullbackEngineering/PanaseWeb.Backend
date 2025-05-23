using AutoMapper;
using MediatR;
using Panase.Core.Entities;
using Panase.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Panase.Application.Features.SessionNotes.Commands
{
    public class CreateSessionNoteCommandHandler : IRequestHandler<CreateSessionNoteCommand, Guid>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CreateSessionNoteCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Guid> Handle(CreateSessionNoteCommand request, CancellationToken cancellationToken)
        {
            var note = _mapper.Map<SessionNote>(request);
            await _unitOfWork.Repository<SessionNote>().AddAsync(note);
            await _unitOfWork.SaveChangesAsync();
            return note.Id;
        }
    }

}
