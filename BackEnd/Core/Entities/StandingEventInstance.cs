using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities
{
    public  class StandingEventInstance : EventInstance
    {
        public int VenueId { get; private set; }

        public Venue Venue { get; private set;}

        private ICollection<StandingReservation> _reservations;
        public IReadOnlyCollection<StandingReservation> Reservations => _reservations.ToList();

        private IDictionary<string, int> _availableTicketTypes;
        public IReadOnlyDictionary<string, int> AvailableTicketTypes => new Dictionary<string, int>(_availableTicketTypes);

        public StandingEventInstance(int venueId, TimeRange span,int eventId) : base(span, eventId)
        {
            VenueId=venueId;
        }
        private StandingEventInstance()
        {}
        public void MakeReservation(StandingReservation reservation)
        {
            
            if (!(_availableTicketTypes.ContainsKey(reservation.TicketType)))
                throw new InvalidOperationException("Invalid ticket type");

            if (_availableTicketTypes[reservation.TicketType] < reservation.Quantity)
                throw new InvalidOperationException("Insuffecient amount of tickets");

            _availableTicketTypes[reservation.TicketType] -= reservation.Quantity;
            _reservations.Add(reservation);
        }
    }
}

