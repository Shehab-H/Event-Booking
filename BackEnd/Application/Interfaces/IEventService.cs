using Core.Entities;
using Core.DTO_s;

namespace Application.Interfaces
{
    public interface IEventService
    {
       public Event GetById(int id);
       public ICollection<EventRunTimesDto> GetRunTimes(int eventId, int venueId);
       public ICollection<SeatedVenueNamesDto> GetVenues(int eventId);
    }
}
