using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities
{
    public abstract class EventIteration
    {
        public int Id { get; private set; }

        public DateTime StartDateTime { get; private set; }
        public DateTime EndDateTime { get; private set; }
       
        //not presisted 
        public bool Started => DateTime.Now > StartDateTime; 


        public EventIteration(DateTime start , DateTime end)
        {
            StartDateTime = start;
            EndDateTime = end;
        }

        private EventIteration() {}


        public abstract bool IsSoldOut();
       
    }
}
