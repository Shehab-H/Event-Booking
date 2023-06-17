using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities
{
    public class TimeRange
    {
        public DateTime Start { get; private set; }
        public DateTime End { get; private set; }

        public TimeRange(DateTime start, DateTime end)
        {
            if (start >= end)
            {
                throw new ArgumentException("End time must be greater than start time.");
            }

            Start = start;
            End = end;
        }

        public bool Overlaps(TimeRange other)
        {
            return other.Start < End && Start < other.End;
        }
    }
}
