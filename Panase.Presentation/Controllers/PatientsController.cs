using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Panase.Application.Feature.Patients.Commands;
using Panase.Application.Feature.Patients.Queries;

namespace Panase.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PatientsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public PatientsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // GET: api/patients
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _mediator.Send(new GetAllPatientsQuery());
            return Ok(result);
        }

        // GET: api/patients/{id}
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var result = await _mediator.Send(new GetPatientByIdQuery { Id = id });
            return Ok(result);
        }

        // POST: api/patients
        [HttpPost]
        public async Task<IActionResult> Create(CreatePatientCommand command)
        {
            var result = await _mediator.Send(command);
            return CreatedAtAction(nameof(GetById), new { id = result }, result);
        }

        // PUT: api/patients/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id, UpdatePatientCommand command)
        {
            if (id != command.Id)
                return BadRequest("ID uyuşmuyor.");

            await _mediator.Send(command);
            return NoContent();
        }

        // DELETE: api/patients/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            await _mediator.Send(new DeletePatientCommand { Id = id });
            return NoContent();
        }
    }
}
