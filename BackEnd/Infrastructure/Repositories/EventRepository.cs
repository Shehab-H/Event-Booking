
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
                 .Include(i => i.Reservations)
                 .ThenInclude(r=>r.BookedSeats)
                 .SingleOrDefault(i => i.Id == id);
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
               .AsNoTracking()
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
                .Distinct()
                .AsNoTracking()
                .ToList();

            return venues;
        }

        public SeatsDto GetSeats(int eventIterationId)
        {
            var seats = _bookingDbContext
                .SeatedEventInstances
                .Where(i => i.Id == eventIterationId)
                .Select(i => new SeatsDto(i.Venue.Seats.ToList()
                ,i.Reservations.SelectMany(r=>r.BookedSeats).ToList()
                ))
                .AsNoTracking()
                .SingleOrDefault();

            if (seats == null)
            {
                throw new Exception("seats was not found");
            }
            
            return new SeatsDto(seats.AvailableSeats.Except(seats.ReservedSeats).ToList(),seats.ReservedSeats);
        }

        public Reservation GetReservation(Guid serialNumer)
        {
           var reservations = _bookingDbContext.Reservations.SingleOrDefault(r=>r.SerialNumber == serialNumer);
           if(reservations == null)
            {
                throw new Exception("reservation not found");
            }
           return reservations;
        }
    }
}
