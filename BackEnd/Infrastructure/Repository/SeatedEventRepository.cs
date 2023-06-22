using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Entities;
using Core.Interfaces;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repository
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

        public void SaveChanges()
        {
            _bookingDbContext.SaveChanges();
        }

        public ICollection<Seat> GetSeats(ICollection<int> seatIds)
        {

            var seats = _bookingDbContext.Seats.Where(s => seatIds.Contains(s.Id)).ToList();

            return seats;

        }
    }
}
