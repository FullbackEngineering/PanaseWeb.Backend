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
    public class DeleteSessionNoteCommandHandler : IRequestHandler<DeleteSessionNoteCommand, Unit>
    {
        private readonly IUnitOfWork _unitOfWork;

        public DeleteSessionNoteCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Unit> Handle(DeleteSessionNoteCommand request, CancellationToken cancellationToken)
        {
            var note = await _unitOfWork.Repository<SessionNote>().GetByIdAsync(request.Id);
            if (note == null)
                throw new NotFoundException(nameof(SessionNote), request.Id);

            _unitOfWork.Repository<SessionNote>().Remove(note);
            await _unitOfWork.SaveChangesAsync();
            return Unit.Value;
        }
    }

}
