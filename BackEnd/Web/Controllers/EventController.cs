using Core.Entities;
using Infrastructure.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class EventController : ControllerBase
    {
        BookingDbContext _context;
        public EventController(BookingDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        public void SeeData()
        {
            List<Seat> Seats = new List<Seat>();
            for (int i = 1; i <= 150; i++)
            {
                for (char c = 'A'; c <= 'Z'; c++)
                {
                    Seats.Add(new Seat(c, i));
                }
            }
            VenueWithSeats Venue = new VenueWithSeats("Imax Americana Blaza", Seats);
            _context.Venues.Add(Venue);
            _context.SaveChanges();

        }

    }
}
