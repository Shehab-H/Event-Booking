using Core.Entities;
using Core.Interfaces;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class SeatsRepository : ISeatsRepository
    {
        private readonly BookingDbContext _dbContext;

        public SeatsRepository(BookingDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<ICollection<Seat>> GetSeats(ICollection<int> seatIds)
        {
            var seats = await _dbContext.Seats.Where(s => seatIds.Contains(s.Id)).ToListAsync();

            return seats;
        }
    }
}
