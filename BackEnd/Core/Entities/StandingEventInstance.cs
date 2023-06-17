using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities
{
    public class StandingEventInstance 
    {
        public int Id { get; private set; }
        public Event Event { get; private set; }

        public TimeRange Span { get; private set; }

        public int VenueID { get;private set; }
        public Venue Venue { get; private set; }

        private IDictionary<string, uint> _availableTicketTypes;

        public IReadOnlyDictionary<string, uint> AvailableTicketTypes => new Dictionary<string, uint>(_availableTicketTypes);
        public ICollection<StandingReservation> reservations { get; private set; }
        public StandingEventInstance(Venue venue,TimeRange span,IDictionary<string,uint> ticketTypes)
        {
            Venue = venue;
            Span = span;
            _availableTicketTypes=ticketTypes;
        }
        
        private StandingEventInstance() { 
        }
        public void Book(StandingReservation reservation)
        {
            if (!(_availableTicketTypes.ContainsKey(reservation.TicketType)))
                throw new InvalidOperationException("Invalid ticket type");

            _availableTicketTypes[reservation.TicketType] -= reservation.Quantity;
            reservations.Add(reservation);
        }

        public void addTicketType(string ticketType,uint quntity)
        {
            _availableTicketTypes.Add(ticketType, quntity);
        }
        
    }
}
