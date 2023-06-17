using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities
{
    public class SeatedReservation
    {
        public int Id { get; private set;}
        public Guid SerialNumber { get; private set;}

        public ICollection<Seat> Seats { get; private set;}

        public SeatedReservation(ICollection<Seat> seats)
        {
            Seats = seats;
            SerialNumber = Guid.NewGuid();
        }
        private SeatedReservation() { }
    }
}
