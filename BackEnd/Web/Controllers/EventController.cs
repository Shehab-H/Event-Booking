using Application.Commands;
using Application.Queries;
using Core.Entities;
using Infrastructure.Data;
using MediatR;
using Microsoft.AspNetCore.Mvc;


namespace Web.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class EventController : ControllerBase
    {
        private readonly IMediator _mediator;

        private readonly BookingDbContext _bookingDbContext;
        
        public EventController( BookingDbContext bookingDbContext 
            ,IMediator mediator)
        {
            _mediator = mediator;
            _bookingDbContext = bookingDbContext;
        }

        #region seed data
        [HttpPost]
        [Route("[action]")]
        public IActionResult SeedEventsAndVenues()
        {
            var movie1 = new Event("The Shawshank Redemption", "Movie", "/shawshank_redemption.jpg", "/shawshank_redemption_thumbnail.jpg", "Two imprisoned men bond over a number of years, finding solace and eventual redemption through acts of common decency.","");
            var movie2 = new Event("The Godfather", "Movie", "/godfather.jpg", "/godfather_thumbnail.jpg", "The aging patriarch of an organized crime dynasty transfers control of his clandestine empire to his reluctant son.", "");


            _bookingDbContext.Events.AddRange(movie1, movie2
                
                );

            var Venue1 = new Venue("Wembly Stadium");

            List<Seat> seats = new List<Seat>();

            for (char row = 'A'; row < 'C'; row++)
            {
                for (int n = 1; n < 11; n++)
                {
                    seats.Add(new Seat(row, n));
                }
            }

            for (char row = 'E'; row < 'H'; row++)
            {
                for (int n = 1; n < 11; n++)
                {
                    seats.Add(new Seat(row, n));
                }
            }
            var Venue2 = new VenueWithSeats("Point 90 Cinema", seats, "Lounge1");


            _bookingDbContext.Venues.AddRange(Venue1, Venue2);
            try
            {
                _bookingDbContext.SaveChanges();
            }
            catch (Exception e)
            {
                return Ok(e);
            }
            return Ok();
        }

        [HttpPatch]
        [Route("[action]")]
        public void SeedEventInstances()
        {
            var @event = _bookingDbContext.Events.Where(e => e.Name == "the shawshank redemption")
                .SingleOrDefault();

            var venue = _bookingDbContext.VenuesWithSeats.FirstOrDefault();

            var timeRange = new TimeRange(new DateTime(2023, 8, 20, 10, 30, 0), new DateTime(2023, 8, 20, 12, 30, 0));
            var seatedEventInstance = new SeatedEventInstance(venue.Id, timeRange, @event.Id);

            venue.BookSlot(timeRange);

            _bookingDbContext.Add(seatedEventInstance);

            _bookingDbContext.SaveChanges();
        }
        #endregion

        [HttpPatch]
        [Route("[action]/{instanceId}/{ticketType}/{quantity}")]

        public async Task<IActionResult> Book(int instanceId,string ticketType,int quantity)
        {
            try
            {
                await _mediator.Send(new BookEventByTypeCommand(instanceId, ticketType, quantity));
                return Ok();

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPatch]
        [Route("[action]/{instanceId}/")]

        public async Task<IActionResult> Book(int instanceId,[FromBody]ICollection<int> seatIds)
        {
            try
            {
                await _mediator.Send(new BookEventBySeatsCommand(instanceId, seatIds));
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("[action]/{start}/{end}")]

        public async Task<IActionResult> Get(DateTime start, DateTime end, CancellationToken cancellationToken)
        {
            var response = await _mediator.Send(new GetEventsByDateRangeQuery(new TimeRange(start, end)), cancellationToken);
            return Ok(response);
        }

        [HttpGet]
        [Route("[action]/{eventId}")]

        public async Task<IActionResult> Get(int eventId)
        {
            try
            {
                var @event = await  _mediator.Send(new GetEventByIdQuery(eventId));
                return Ok(@event);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);  
            }
        }

        [HttpGet]
        [Route("[action]/{eventId}")]

        public async Task<IActionResult> GetVenues(int eventId)
        {
            try
            {
               var venues = await _mediator.Send(new GetVenuesQuery(eventId));
                return Ok(venues);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        [HttpGet]
        [Route("[action]/{eventId}/{venueId}")]
        public async Task<IActionResult> GetRunTimes(int eventId,int venueId)
        {
            try
            {
                var runtimes = await _mediator.Send(new GetEventRunTimesQuery(eventId, venueId));
                return Ok(runtimes);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet]
        [Route("[action]/{eventInstanceId}")]
        public async Task<IActionResult> GetSeats(int eventInstanceId)
        {
            try
            {
                var seats = await _mediator.Send(new GetSeatsQuery(eventInstanceId));
                return Ok(seats);
            }
            catch(Exception e)
            {
                return BadRequest();
            }
        }

        [HttpGet]
        [Route("[action]")]
        public async Task<IActionResult> GetTrendingEvents()
        {
            try
            {
                var events = await _mediator.Send(new GetTrendingEventsQuery());
                return Ok(events);
            }
            catch(Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
