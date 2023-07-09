using Core.DTO_s;
using Core.Entities;
using Core.Interfaces;
using Infrastructure.Data;
using Infrastructure.Extensions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class EventInstancesRepository : IEventInstancesRepository
    {
        private readonly BookingDbContext _dbContext;
        public EventInstancesRepository(BookingDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<SeatsDto> GetEventInstanceSeats(int eventInstanceId)
        {
            var seats = await _dbContext
                .SeatedEventInstances
                .Where(i => i.Id == eventInstanceId)
                .Select(i => new SeatsDto(i.Venue.Seats.ToList()
                , i.Reservations.SelectMany(r => r.BookedSeats).ToList()
                ))
                .AsNoTracking()
                .SingleOrDefaultAsync();

            if (seats == null)
            {
                throw new Exception("seats was not found");
            }
            return seats;
        }
        

        public async Task<SeatedEventInstance> GetSeatedInstance(int id)
        {
            var instance = await _dbContext.SeatedEventInstances.
                 Include(i => i.Venue).ThenInclude(v => v.Seats)
                 .Include(i => i.Reservations)
                 .ThenInclude(r => r.BookedSeats)
                 .SingleOrDefaultAsync(i => i.Id == id);

            if (instance == null)
                throw new Exception("event instance was not found");

            return instance;
        }

        public async Task<StandingEventInstance> GetStandingInstance(int id)
        {
            var instance = await _dbContext.StandingEventInstances
                 .Include(i => i.Reservations).
                 SingleOrDefaultAsync(i => i.Id == id);

            if (instance == null)
                throw new Exception("event instance was not found");

            return instance;
        }

        public async Task<int> SaveChangesAsync()
        {
            return await _dbContext.SaveChangesAsync();
        }

        public async Task<ICollection<EventRunTimesDto>> GetTimeSpans(int venueId, int eventId)
        {
            var runTimes = await _dbContext.SeatedEventInstances
                .AsNoTracking().
                Where(i => i.EventId == eventId && i.VenueId == venueId)
               .MapToDto()
               .AsNoTracking()
               .ToListAsync();

            if (runTimes == null)
            {
                throw new Exception($"there are no instances running in the venue with" +
                    $" id : {venueId} and event id : {venueId}");
            }

            return runTimes;
        }
    }
}
