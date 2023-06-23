
using Core.DTO_s;
using Core.Entities;
using Core.Interfaces;
using Infrastructure.Data;
using Infrastructure.Extensions;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class EventRepository : IEventRepository
    {
        private readonly BookingDbContext _bookingDbContext;

        public EventRepository(BookingDbContext dbContext)
        {
            _bookingDbContext = dbContext;
        }

        public SeatedEventInstance GetSeatedInstance(int id)
        {
            var instance = _bookingDbContext.SeatedEventInstances.
                 Include(i => i.Venue).ThenInclude(v => v.Seats)
                 .Include(i => i.Reservations).SingleOrDefault(i => i.Id == id);
            if (instance == null)
                throw new Exception("event instance was not found");

            return instance;

        }

        public StandingEventInstance GetStandingInstance(int id)
        {
            var instance = _bookingDbContext.StandingEventInstances
                 .Include(i => i.Reservations).
                 SingleOrDefault(i => i.Id == id);

            if (instance == null)
                throw new Exception("event instance was not found");

            return instance;
        }

        public int SaveChanges()
        {
           return _bookingDbContext.SaveChanges();
        }

        public ICollection<Seat> GetSeats(ICollection<int> seatIds)
        {

            var seats = _bookingDbContext.Seats.Where(s => seatIds.Contains(s.Id)).ToList();

            return seats;

        }

        public Event GetEvent(int id)
        {
            var @event = _bookingDbContext.Events.AsNoTracking().SingleOrDefault(e=>e.Id==id);
            if(@event == null)
            {
                throw new ArgumentException($"Event with id : {id} was not found ");
            }
            return @event;
        }

        public ICollection<EventRunTimesDto> GetTimeSpans(int venueId, int eventId)
        {
            var runTimes = _bookingDbContext.SeatedEventInstances
                .AsNoTracking().
                Where(i => i.EventId == eventId && i.VenueId == venueId)
               .MapToDto()
               .ToList();

            if (runTimes == null)
            {
                throw new Exception($"there are no instances running in the venue with" +
                    $" id : {venueId} and event id : {venueId}");
            }

            return runTimes;
        }

        public ICollection<SeatedVenueNamesDto> GetVenueNames(int eventId)
        {
            var venues = _bookingDbContext
                .SeatedEventInstances
                .Where(e => e.EventId == eventId)
                .MapToSeatedVenueDto()
                .ToList();

            return venues;
        }
    }
}
