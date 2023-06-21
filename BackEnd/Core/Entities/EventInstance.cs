using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities
{
    public abstract class EventInstance<T> where T : Reservation
    {
        public int Id { get; private set; }

        public TimeRange Span { get;private set;}
        protected ICollection<T> _reservations;

        public IReadOnlyCollection<T> Reservations => _reservations.ToList();

        public EventInstance(TimeRange span)
        {
            Span = span;
        }
        protected EventInstance() {}
        public abstract void MakeReservation(T reservation);

    }
}
