using Application.Interfaces;
using Application.Services;
using Core.Entities;
using Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;


namespace Web.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class EventController : ControllerBase
    {
        private readonly IbookingService _bookingService;
        private readonly IEventService _eventService;
        private readonly BookingDbContext _bookingDbContext;
        
        public EventController(IbookingService bookingService 
            , BookingDbContext bookingDbContext 
            , IEventService eventService
            )
        {
            _eventService = eventService;
            _bookingDbContext = bookingDbContext;
            _bookingService = bookingService;
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

        public IActionResult Book(int instanceId,string ticketType,uint quantity)
        {
            try
            {
                _bookingService.Book(instanceId, ticketType, quantity);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            return Ok();
        }

        [HttpPatch]
        [Route("[action]/{instanceId}/")]

        public  IActionResult Book(int instanceId,[FromBody]ICollection<int> seatIds)
        {
            try
            {
                _bookingService.Book(instanceId, seatIds);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }



        [HttpGet]
        [Route("[action]/{eventId}")]

        public IActionResult Get(int eventId)
        {
            try
            {
                return Ok(_eventService.GetById(eventId));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);  
            }
        }

        [HttpGet]
        [Route("[action]/{eventId}")]

        public IActionResult GetVenues(int eventId)
        {
            try
            {
                return Ok(_eventService.GetVenues(eventId));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        [HttpGet]
        [Route("[action]/{eventId}/{venueId}")]
        public IActionResult GetRunTimes(int eventId,int venueId)
        {
            try
            {
                return Ok(_eventService.GetRunTimes(eventId, venueId));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet]
        [Route("[action]/{eventInstanceId}")]
        public IActionResult GetSeats(int eventInstanceId)
        {
      
                return Ok(_eventService.GetSeats(eventInstanceId));

           
        }
    }
}
