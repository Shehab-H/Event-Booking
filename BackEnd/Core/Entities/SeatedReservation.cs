using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities
{
    public class SeatedReservation : Reservation
    {

        public ICollection<Seat> Seats { get; private set;}

        public SeatedReservation(ICollection<Seat> seats) : base()
        {
            Seats = seats;
        }
        private SeatedReservation() { }
    }
}
