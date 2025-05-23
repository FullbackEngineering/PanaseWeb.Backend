using MediatR;
using Panase.Application.Features.SessionNotes.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Panase.Application.Features.SessionNotes.Queries
{
    public class GetAllSessionNotesQuery : IRequest<List<SessionNoteDto>> { }

}
