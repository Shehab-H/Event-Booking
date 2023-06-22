using Core.Entities;
using Core.DTO_s;

namespace Application.Interfaces
{
    public interface IEventService
    {
       public Task<Event> GetById(int id);
       public Task<List<EventInstanceDto>> GetInstances(int eventId, int venueId);
       

       
    }
}
