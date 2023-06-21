using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IEventService
    {
       public Task<Event> GetById(int id);
       public Task<EventInstance<T>> GetInstances<T>(int eventId, int venueId) where T : Reservation;

    }
}
