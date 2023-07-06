using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities
{
    public class SeatedReservation : Reservation
    {

        private ICollection<Seat> _bookedSeats;
        public IReadOnlyCollection<Seat> BookedSeats => _bookedSeats.ToList().AsReadOnly();

        public SeatedReservation(ICollection<Seat> seats) : base()
        {
            _bookedSeats = seats;
        }
        private SeatedReservation() { }
    }
}
