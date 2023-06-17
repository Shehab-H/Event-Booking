using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities
{
    public class Venue
    {
        public int Id { get; private set; }
        public string Name { get; private set; }

        private ICollection<TimeRange> _bookedSlots;
        public IReadOnlyCollection<TimeRange> BookedSlots => _bookedSlots.ToList();

        public Venue(string name)
        {
            Name = name;
        }
        protected Venue(){}

        public void BookSlot(TimeRange slot)
        {
            if (_bookedSlots.Any(s => s.Overlaps(slot)))
                throw new InvalidOperationException("slot overlaps with another booked slot");

            _bookedSlots.Add(slot);
        }
    }
}
