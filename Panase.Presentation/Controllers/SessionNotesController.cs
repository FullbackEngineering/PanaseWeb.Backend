using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Panase.Application.Features.SessionNotes.Commands;
using Panase.Application.Features.SessionNotes.Queries;

namespace Panase.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SessionNotesController : ControllerBase
    {
        private readonly IMediator _mediator;

        public SessionNotesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // GET: api/SessionNote
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _mediator.Send(new GetAllSessionNotesQuery());
            return Ok(result);
        }

        // GET: api/SessionNote/{id}
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var result = await _mediator.Send(new GetSessionNoteByIdQuery { Id = id });
            return Ok(result);
        }

        // POST: api/SessionNote
        [HttpPost]
        public async Task<IActionResult> Create(CreateSessionNoteCommand command)
        {
            var result = await _mediator.Send(command);
            return CreatedAtAction(nameof(GetById), new { id = result }, null);
        }

        // PUT: api/SessionNote
        [HttpPut]
        public async Task<IActionResult> Update(UpdateSessionNoteCommand command)
        {
            await _mediator.Send(command);
            return NoContent();
        }

        // DELETE: api/SessionNote/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            await _mediator.Send(new DeleteSessionNoteCommand { Id = id });
            return NoContent();
        }
    }
}
