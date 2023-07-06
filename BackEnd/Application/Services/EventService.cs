using Application.Interfaces;
using Core.Entities;
using Core.DTO_s;
using Core.Interfaces;

namespace Application.Services
{
    public class EventService : IEventService
    {
        private readonly IEventRepository _eventRepository;
        public EventService(IEventRepository EventRepository)
        {
            _eventRepository = EventRepository;
        }
        public Event GetById(int id)
        {
            return _eventRepository.GetEvent(id);
        }

        public ICollection<EventRunTimesDto> GetRunTimes(int eventId, int venueId)
        {
            return _eventRepository.GetTimeSpans(venueId, eventId);
        }

        public SeatsDto GetSeats(int eventInstanceId)
        {
            return _eventRepository.GetSeats(eventInstanceId);
        }

        public ICollection<SeatedVenueNamesDto> GetVenues(int eventId)
        {
            return _eventRepository.GetVenueNames(eventId);
        }
 
    }
}
