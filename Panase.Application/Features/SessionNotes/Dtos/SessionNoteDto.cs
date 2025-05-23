using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Panase.Application.Features.SessionNotes.Dtos
{
    public class SessionNoteDto
    {
        public Guid Id { get; set; }
        public string Note { get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; }
        public Guid AppointmentId { get; set; }
    }
}
