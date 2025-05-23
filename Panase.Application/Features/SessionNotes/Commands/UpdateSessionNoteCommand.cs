using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Panase.Application.Features.SessionNotes.Commands
{
    public class UpdateSessionNoteCommand:IRequest<Unit>
    {
        public Guid Id { get; set; }
        public string Note { get; set; } = string.Empty;
    }
}
