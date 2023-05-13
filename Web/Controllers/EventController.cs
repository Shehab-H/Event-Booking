using Core.Entities;
using Core.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class EventController : ControllerBase
    {
        private readonly ITicketBookingService _ticketBookingService;
        public EventController(ITicketBookingService ticketBookingService)
        {
            _ticketBookingService = ticketBookingService;
        }
        [Route("[controller]/[action]")]
        [HttpPut]
        public IActionResult Book(int eventIterationID,Seat seat)
        {
            _ticketBookingService.Book(eventIterationID, seat);
            return Ok();
        }
    }
}
