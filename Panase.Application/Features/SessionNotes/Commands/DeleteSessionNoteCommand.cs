﻿using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Panase.Application.Features.SessionNotes.Commands
{
    public class DeleteSessionNoteCommand: IRequest<Unit>
    {
        public Guid Id { get; set; }
    }
}
