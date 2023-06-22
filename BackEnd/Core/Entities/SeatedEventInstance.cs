using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities
{
    public class SeatedEventInstance : EventInstance
    {

        public int VenueId { get; private set; }

        private ICollection<SeatedReservation> _reservations;

        public VenueWithSeats Venue { get; private set; }

        public IReadOnlyCollection<SeatedReservation> Reservations => _reservations.ToList();
        public ICollection<Seat> AllReservedSeats => _reservations.SelectMany(r => r.Seats).ToList();

        public SeatedEventInstance(int venueId,TimeRange span , int eventId) : base(span, eventId)
        {
            VenueId = venueId;
        }
        private SeatedEventInstance()
        {}

        public  void MakeReservation(SeatedReservation reservation)
        {
            if ((!Venue.HasSeats(reservation.Seats)) || IsSeatsReserved(reservation.Seats))
                throw new InvalidOperationException("some or all of the seats are not available");


            _reservations.Add(reservation);
        }
        private bool IsSeatsReserved(ICollection<Seat> seats)
        {
            return seats.Select(s => s.Id).Intersect(AllReservedSeats.Select(s => s.Id)).Any();
        }
    }
}
