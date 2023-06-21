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
        public async Task Book(int eventInstanceId,string ticketType,uint quantity)
        {
            EventInstance<StandingReservation>? instance = await _dbContext.StandingEventInstances
                .Include(e=>e.Reservations)
                .SingleOrDefaultAsync(i=>i.Id == eventInstanceId);

            if (instance == null)
            {
                throw new Exception("event instance not found");
            }


            instance.MakeReservation(new StandingReservation(ticketType, quantity));

            await _dbContext.SaveChangesAsync();
        }

        public async Task Book(int eventInstanceId, ICollection<int> seatIds)
        {
            var seats = await GetSeats(seatIds);

            EventInstance<SeatedReservation>? instance = await _dbContext.SeatedEventInstances
                .Include(s => s.Reservations).ThenInclude(r => r.Seats)
                .Include(s => s.Venue).ThenInclude(v => v.Seats)
                .SingleOrDefaultAsync(e => e.Id == eventInstanceId);

            if(instance == null)
            {
                throw new Exception("event instance doesn't exist");
            }

            instance.MakeReservation(new SeatedReservation(seats));

            await _dbContext.SaveChangesAsync();
        }

        private async Task<ICollection<Seat>> GetSeats(ICollection<int> seatIds)
        {
            var seats = await _dbContext.Seats.Where(s => seatIds.Contains(s.Id)).ToListAsync();

            var missingSeatIds = seatIds.Except(seats.Select(s => s.Id));

            if (missingSeatIds.Any())
            {
                throw new Exception($"some of the seats provided doesn't exist");
            }
            return seats;
        }

    }
}
