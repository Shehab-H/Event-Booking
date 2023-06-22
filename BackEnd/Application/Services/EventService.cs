using Application.Interfaces;
using Core.Entities;
using Core.DTO_s;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Infrastructure.Data;
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
        public Task<Event> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<EventInstanceDto>> GetInstances(int eventId, int venueId)
        {
            throw new NotImplementedException();
        }
    }
}
