using Application.Commands;
using Infrastructure.Data;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class SeatedEventController : Controller
    {
        private readonly IMediator _mediator;

        public SeatedEventController( IMediator mediator)
        {
            _mediator = mediator;
        }

        [Authorize(Policy ="UserOnly")]
        [HttpPost]
        [Route("[action]")]
        public async Task<IActionResult> Schedule(ScheduleSeatedEventCommand command)
        {
            try
            {
                await _mediator.Send(command);
                return Ok();
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}
