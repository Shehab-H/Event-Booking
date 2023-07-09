
using Core.DTO_s;
using Core.Entities;
using Core.Interfaces;
using Infrastructure.Data;
using Infrastructure.Extensions;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Linq.Expressions;

namespace Infrastructure.Repositories
{
    public class EventRepository : IEventRepository
    {
        private readonly BookingDbContext _bookingDbContext;

        public EventRepository(BookingDbContext dbContext)
        {
            _bookingDbContext = dbContext;
        }

        public int SaveChanges()
        {
           return _bookingDbContext.SaveChanges();
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

        public async Task<ICollection<Event>> GetByDateRange(TimeRange Range)
        {
            var events = await _bookingDbContext.EventsInstances
                .Where(i => i.Span.Start > Range.Start && i.Span.Start < Range.End)
                .Select(i => i.Event)
                .Distinct()
                .AsNoTracking()
                .ToListAsync();
            return events;
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

        public Reservation GetReservation(Guid serialNumer)
        {
           var reservations = _bookingDbContext
                .Reservations.
                AsNoTracking().
                SingleOrDefault(r=>r.SerialNumber == serialNumer);
           if(reservations == null)
            {
                throw new Exception("reservation not found");
            }
           return reservations;
        }

        public  async Task<ICollection<Event>> GetTrendingEvents( int take = 10)
        {
            var events = await  _bookingDbContext
                .SeatedEventInstances
                .Where(i => i.Reservations
                .Where(r => r.DateCreated >= DateTime.Now.AddDays(-3)).Any())
                .OrderByDescending(i => i.Reservations.SelectMany(r => r.BookedSeats).Count())
                .Distinct()
                .Select(i => i.Event)
                .Concat(
                    _bookingDbContext
                    .StandingEventInstances
                    .Where(i => i.Reservations
                         .Where(r => r.DateCreated >= DateTime.Now.AddDays(-3)).Any())
                    .OrderByDescending(i => i.Reservations.Select(r => r.Quantity).Sum())
                    .Distinct()
                    .Select(i => i.Event)
                ).Take(10).ToListAsync();
              
            return events;
        }
    }
}
