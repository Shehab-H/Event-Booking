using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities
{
    public  class StandingEventInstance : EventInstance<StandingReservation>
    {
        public int VenueId { get; private set; }

        public Venue Venue { get; private set; }


        private IDictionary<string, uint> _availableTicketTypes;
        public IReadOnlyDictionary<string, uint> AvailableTicketTypes => new Dictionary<string, uint>(_availableTicketTypes);

        public StandingEventInstance(int venueId, TimeRange span) : base(span)
        {
            VenueId=venueId;
        }
        private StandingEventInstance()
        {}
        public override void MakeReservation(StandingReservation reservation)
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

