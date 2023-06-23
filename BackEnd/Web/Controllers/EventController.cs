using Application.Interfaces;
using Bogus;
using Core.Entities;
using Infrastructure.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

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
            , IEventService eventService)
        {
            _eventService = eventService;
            _bookingDbContext = bookingDbContext;
            _bookingService = bookingService;
        }

        [HttpPost]
        [Route("[action]")]
        public IActionResult SeedEventsAndVenues()
        {
            var movie1 = new Event("The Shawshank Redemption", "Movie", "/shawshank_redemption.jpg", "/shawshank_redemption_thumbnail.jpg", "Two imprisoned men bond over a number of years, finding solace and eventual redemption through acts of common decency.");
            var movie2 = new Event("The Godfather", "Movie", "/godfather.jpg", "/godfather_thumbnail.jpg", "The aging patriarch of an organized crime dynasty transfers control of his clandestine empire to his reluctant son.");
            var movie3 = new Event("The Godfather: Part II", "Movie", "/godfather_part_2.jpg", "/godfather_part_2_thumbnail.jpg", "The early life and career of Vito Corleone in 1920s New York City is portrayed, while his son, Michael, expands and tightens his grip on the family crime syndicate.");
            var movie4 = new Event("The Dark Knight", "Movie", "/dark_knight.jpg", "/dark_knight_thumbnail.jpg", "When the menace known as the Joker wreaks havoc and chaos on the people of Gotham, Batman must accept one of the greatest psychological and physical tests of his ability to fight injustice.");
            var movie5 = new Event("12 Angry Men", "Movie", "/12_angry_men.jpg", "/12_angry_men_thumbnail.jpg", "A jury holdout attempts to prevent a miscarriage of justice by forcing his colleagues to reconsider the evidence.");

            // Musical Concerts
            var concert1 = new Event("Beyoncé: Formation World Tour", "Musical Concert", "/beyonce_formation.jpg", "/beyonce_formation_thumbnail.jpg", "Beyoncé performs her biggest hits and songs from her latest album, Lemonade, in this high-energy concert tour.");
            var concert2 = new Event("Adele: Live in New York City", "Musical Concert", "/adele_live_in_nyc.jpg", "/adele_live_in_nyc_thumbnail.jpg", "Adele performs live at Radio City Music Hall in New York City, showcasing her powerful vocals and emotional ballads.");
            var concert3 = new Event("Ed Sheeran: Divide Tour", "Musical Concert", "/ed_sheeran_divide.jpg", "/ed_sheeran_divide_thumbnail.jpg", "Ed Sheeran performs hits from his album '÷' at the iconic Wembley Stadium in London.");
            var concert4 = new Event("Coldplay: A Head Full of Dreams Tour", "Musical Concert", "/coldplay_head_full_of_dreams.jpg", "/coldplay_head_full_of_dreams_thumbnail.jpg", "Coldplay performs their biggest hits and tracks from their album 'A Head Full of Dreams' in this spectacular live concert tour.");
            var concert5 = new Event("Taylor Swift: 1989 World Tour", "Musical Concert", "/taylor_swift_1989.jpg", "/taylor_swift_1989_thumbnail.jpg", "Taylor Swift performs her chart-topping hits from her album '1989', including 'Shake It Off', 'Blank Space', and 'Bad Blood'.");

            // Theater Shows
            var theater1 = new Event("Hamilton", "Theater Show", "/hamilton.jpg", "/hamilton_thumbnail.jpg", "The story of founding father Alexander Hamilton, with a hip-hop score and an ethnically diverse cast.");
            var theater2 = new Event("Les Misérables", "Theater Show", "/les_miserables.jpg", "/les_miserables_thumbnail.jpg", "Set against the backdrop of 19th-century France, Les Misérables tells an enthralling story of broken dreams and unrequited love, passion, sacrifice and redemption.");
            var theater3 = new Event("The Phantom of the Opera", "Theater Show", "/phantom_of_the_opera.jpg", "/phantom_of_the_opera_thumbnail.jpg", "A disfigured musical genius, hidden away in the Paris Opera House, terrorizes the opera company for the unwitting benefit of a young protégée whom he trains and loves.");
            var theater4 = new Event("Wicked", "Theater Show", "/wicked.jpg", "/wicked_thumbnail.jpg", "The untold story of the witches of Oz: Elphaba, born with emerald-green skin, is smart, fiery and misunderstood. Glinda is beautiful, ambitious and very popular. The remarkable odyssey of how these unexpected friends changed each other's lives for good has made Wicked one of the world's most popular musicals.");
            var theater5 = new Event("The Lion King", "Theater Show", "/lion_king.jpg", "/lion_king_thumbnail.jpg", "A young lion prince is cast out of his pride by his cruel uncle, who claims he killed his father. While the uncle rules with an iron paw, the prince grows up beyond the Savannah, living by a philosophy: No worries for the rest of your days. But when his past comes to haunt him, the young prince must decide his fate: Will he remain an outcast or face his demons and become what he needs to be?");


            _bookingDbContext.Events.AddRange(movie1, movie2, movie3, movie4, movie5,
                concert1, concert2, concert3, concert4, concert5,
                theater1, theater2, theater3, theater4, theater5
                );

            var Venue1 = new Venue("Wembly Stadium");

            List<Seat> seats = new List<Seat>();

            for (char row = 'A'; row < 'Z'; row++)
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
            catch(Exception e)
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
               _bookingService.Book(instanceId,seatIds);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            return Ok();
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


    }
}
