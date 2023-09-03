using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities
{
    public abstract class EventInstance
    {
        public int Id { get; private set; }

        public TimeRange Span { get;private set;}

        public int EventId { get; private set; }
        public Event Event { get; private set; }
        public EventInstance(TimeRange span, int eventId)
        {
            if (span.Start < DateTime.UtcNow || span.End < DateTime.UtcNow)
                throw new ArgumentException("invalid time span");

            Span = span;
            EventId = eventId;
        }
        protected EventInstance() {}

    }
}
