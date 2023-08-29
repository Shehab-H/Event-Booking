using Core.Entities;
using Core.Interfaces;
using Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class SeatedVenueRepository : ISeatedVenueRepository
    {
        private readonly BookingDbContext _dbContext;
        public SeatedVenueRepository(BookingDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<VenueWithSeats> Get(int venueId)
        {
            var venue = await _dbContext.VenuesWithSeats.FindAsync(venueId);
            if(venue == null)
            {
                throw new Exception($"venue with id : {venueId} was not found");
            }
            return venue;
        }

        public Task<int> SaveChangesAsync()
        {
            return _dbContext.SaveChangesAsync();
        }
    }
}
