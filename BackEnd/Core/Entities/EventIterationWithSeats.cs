using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities
{
    public class EventIterationWithSeats :EventIteration
    {
        private ICollection<Seat> _availbleSeats;
        public IReadOnlyCollection<Seat> AvailbleSeats => _availbleSeats.ToList();
        
        public VenueWithSeats Venue { get; private set; }

        public EventIterationWithSeats(VenueWithSeats venue, DateTime start, DateTime end) : base(start, end)
        {
            _availbleSeats = venue.Seats.ToList();
        }

        private EventIterationWithSeats() {}

        public void Book(Seat seat)
        {
            if (!(_availbleSeats.Contains(seat)))
                throw new InvalidOperationException("Seat is not available");
            _availbleSeats.Remove(seat);
        }

    }
}
