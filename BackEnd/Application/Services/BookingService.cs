using Application.Interfaces;
using Core.Entities;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class BookingService : IbookingService
    {
        private readonly BookingDbContext _dbContext;
        public BookingService(BookingDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public void Book(int eventInstanceId,string ticketType,uint quantity)
        {
            var eventInstance = _dbContext.StandingEventInstances
                .Include(e=>e.reservations)
                .SingleOrDefault(i=>i.Id == eventInstanceId);

            if (eventInstance == null)
            {
                throw new Exception("event instance not found");
            }

            StandingReservation reservation = new StandingReservation(ticketType,quantity);

            eventInstance.Book(reservation);

            _dbContext.SaveChanges();
        }

        public void Book(int eventInstanceId, ICollection<int> seatIds)
        {
            var seats = _dbContext.Seats.Where(s=> seatIds.Contains(s.Id)).ToList();

            var missingSeatIds = seatIds.Except(seats.Select(s => s.Id));

            if(missingSeatIds.Any())
            {
                throw new Exception($"some of the seats provided doesn't exist doesn't exist");
            }

            var eventInstance = _dbContext.SeatedEventInstances
                .Include(s => s.Reservations).ThenInclude(r => r.Seats)
                .Include(s => s.Venue).ThenInclude(v => v.Seats)
                .SingleOrDefault(e => e.Id == eventInstanceId);

            if(eventInstance == null)
            {
                throw new Exception("event instance doesn't exist");
            }

            eventInstance.Book(new SeatedReservation(seats));

            _dbContext.SaveChanges();

        }

    }
}
