using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities
{
    public class EventITerationWithoutSeats : EventIteration
    {
        public Venue Venue { get; private set; }
        private IDictionary<string, int> _availableTicketTypes;
        public EventITerationWithoutSeats(Venue venue, DateTime start, DateTime end) : base(start, end)
        {
            Venue = venue;
        }
        
        private EventITerationWithoutSeats() { 
        }
        public void Book(string ticketType,int quntity = 1)
        {
            if (!(_availableTicketTypes.ContainsKey(ticketType)))
                throw new InvalidOperationException("Invalid ticket type");

            _availableTicketTypes[ticketType] -= quntity;
        }

        public void addTicketType(string ticketType,int quntity)
        {
            _availableTicketTypes.Add(ticketType, quntity);
        }
        
    }
}
