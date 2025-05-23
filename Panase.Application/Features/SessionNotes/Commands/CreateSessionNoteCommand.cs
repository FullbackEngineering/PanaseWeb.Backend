using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Panase.Application.Features.SessionNotes.Commands
{
    public class CreateSessionNoteCommand:IRequest<Guid>
    {
        public string Note { get; set; } = string.Empty;
        public Guid AppointmentId { get; set; }
    }
}
