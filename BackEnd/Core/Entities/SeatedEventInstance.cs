using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities
{
    public class SeatedEventInstance
    {
        public int Id { get; private set; }
        public Event Event { get; private set; }

        public TimeRange Span { get;private set; }
        public int VenueID { get; private set; }

        public VenueWithSeats Venue { get; private set; }

        private ICollection<SeatedReservation> reservations;

        public IReadOnlyCollection<SeatedReservation> Reservations => reservations.ToList();

        public ICollection<Seat> AllReservedSeats => reservations.SelectMany(r => r.Seats).ToList();

        public SeatedEventInstance(VenueWithSeats venue, Event @event, TimeRange span)
        {
            Venue = venue;
            Event = @event;
            Span = span;
        }

        private SeatedEventInstance() { }

        public void Book(SeatedReservation reservation)
        {
            // make sure that every seat in the reservation is in the venue and not resreved already
            if ((!Venue.HasSeats(reservation.Seats)) || IsSeatsReserved(reservation.Seats))
                throw new InvalidOperationException("some or all of the seats are not available");


            reservations.Add(reservation);
        }

        private bool IsSeatsReserved(ICollection<Seat> seats)
        {
            return seats.Select(s => s.Id).Intersect(AllReservedSeats.Select(s => s.Id)).Any();
        }

    }
}
