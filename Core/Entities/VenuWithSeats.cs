using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities
{
     public class VenuWithSeats : Venu
    {

        private ICollection<Seat> _seats;

        public IReadOnlyCollection<Seat> Seats => _seats.ToList();

        public VenuWithSeats(string name, ICollection<Seat> seats):base(name)
        {
            _seats = seats;
        }

    }
}
