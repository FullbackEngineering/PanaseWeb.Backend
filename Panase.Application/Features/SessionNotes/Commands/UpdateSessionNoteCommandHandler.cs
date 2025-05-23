using AutoMapper;
using MediatR;
using Panase.Application.Common.Exceptions;
using Panase.Core.Entities;
using Panase.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Panase.Application.Features.SessionNotes.Commands
{
    public class UpdateSessionNoteCommandHandler : IRequestHandler<UpdateSessionNoteCommand, Unit>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UpdateSessionNoteCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(UpdateSessionNoteCommand request, CancellationToken cancellationToken)
        {
            var note = await _unitOfWork.Repository<SessionNote>().GetByIdAsync(request.Id);
            if (note == null)
                throw new NotFoundException(nameof(SessionNote), request.Id);

            _mapper.Map(request, note);
            _unitOfWork.Repository<SessionNote>().Update(note);
            await _unitOfWork.SaveChangesAsync();
            return Unit.Value;
        }
    }

}
