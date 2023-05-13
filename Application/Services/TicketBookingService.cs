using Core.Entities;
using Core.Interfaces;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Application.Services
{
    public class TicketBookingService : ITicketBookingService
    {
        private readonly BookingDbContext _bookingDbContext;

        public TicketBookingService(BookingDbContext bookingDbContext)
        {
            _bookingDbContext= bookingDbContext;
        }
        public void Book(int eventIterationID, Seat seat)
        {
            var eventIteration = _bookingDbContext.eventIterations.Where(i=>i.Id== eventIterationID)
                .Include(eventIteration=>eventIteration.Venu)
                .ThenInclude(venu=>venu.Seats)
                .Include(eventIteration => eventIteration.AvailableSeats).FirstOrDefault();

            if(eventIteration==null)
            {
                throw new Exception("Event iteration was not found");
            }
            if (eventIteration.IsSoldOut())
            {
                throw new InvalidOperationException("Event is sold out");
            }


            eventIteration.Book(seat);
            _bookingDbContext.SaveChanges();
        }
    }
}
