using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities
{
    public class EventIterationWithSeats : EventIteration
    {
        private ICollection<Seat> _availableSeats;
        public IReadOnlyCollection<Seat> AvailableSeats => _availableSeats.ToList();
        public VenuWithSeats Venu { get; private set; }

        public EventIterationWithSeats(DateTime start, DateTime end, VenuWithSeats venu):base(start, end)
        {
            this.Venu = venu;
            this._availableSeats = Venu.Seats.ToList();
        }

        public void Book(Seat seat)
        {
            var seatToRemove = _availableSeats.Where(s => s.Matches(seat)).FirstOrDefault();
            if (seatToRemove == default(Seat))
            {
                throw new InvalidOperationException("Seat is no longer available");
            }
            _availableSeats.Remove(seatToRemove);
        }
        public void Book(ICollection<Seat> seats)
        {
            foreach (var seat in seats)
            {
                Book(seat);
            }
        }

        public override bool IsSoldOut()
        {
            if (_availableSeats.Count() > 0)
                return false;
            else return true;
        }
    }
}
