using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Panase.Application.Features.Doctors.Commands;
using Panase.Application.Features.Doctors.Queries;

namespace Panase.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DoctorsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public DoctorsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // GET: api/Doctor
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _mediator.Send(new GetAllDoctorsQuery());
            return Ok(result);
        }

        // GET: api/Doctor/{id}
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var result = await _mediator.Send(new GetByIdDoctorQuery { Id = id });
            return Ok(result);
        }

        // POST: api/Doctor
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateDoctorCommand command)
        {
            var id = await _mediator.Send(command);
            return CreatedAtAction(nameof(GetById), new { id }, id);
        }

        // PUT: api/Doctor/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id, [FromBody] UpdateDoctorCommand command)
        {
            if (id != command.Id)
                return BadRequest("Id mismatch");

            await _mediator.Send(command);
            return NoContent();
        }

        // DELETE: api/Doctor/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            await _mediator.Send(new DeleteDoctorCommand { Id = id });
            return NoContent();
        }
    }
}
