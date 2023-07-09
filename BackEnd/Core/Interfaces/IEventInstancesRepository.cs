using Core.DTO_s;
using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interfaces
{
    public interface IEventInstancesRepository
    {
        public Task<ICollection<EventRunTimesDto>> GetTimeSpans(int venueId, int eventId);

        public Task<SeatedEventInstance> GetSeatedInstance(int id);
        public Task<StandingEventInstance> GetStandingInstance(int id);
        public Task<SeatsDto> GetEventInstanceSeats(int eventInstanceId);
        public Task<int> SaveChangesAsync();
    }
}
