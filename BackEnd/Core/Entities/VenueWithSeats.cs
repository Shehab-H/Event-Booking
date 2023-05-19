using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities
{
    public class VenueWithSeats : Venue
    {
        private ICollection<Seat> _seats;

        public IReadOnlyCollection<Seat> Seats => _seats.ToList();
        public VenueWithSeats(string name , ICollection<Seat> seats) : base(name)
        {
            if(seats.Count() > seats.Distinct().Count())
            {
                throw new ArgumentException("Cannot have duplicate seats");
            }

            _seats = seats;
        }
        private VenueWithSeats() {}
    }
}
