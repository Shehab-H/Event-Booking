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
        public string Lounge { get; private set; }


        public VenueWithSeats(string name , ICollection<Seat> seats, string lounge) : base(name)
        {
            if(seats.Count() > seats.Distinct().Count())
            {
                throw new ArgumentException("Cannot have duplicate seats");
            }
            _seats = seats;            Lounge = lounge;

        }

        /// <summary>
        /// returns false if any of the seats provided doesn't belong to that venue
        /// </summary>
        /// <param name="seats"></param>
        /// <returns>true or false</returns>
        public bool HasSeats(ICollection<Seat> seats)
        {
            return !seats.Select(s => s.Id).Except(_seats.Select(s => s.Id)).Any();
        }
        private VenueWithSeats() {}
    }
}
