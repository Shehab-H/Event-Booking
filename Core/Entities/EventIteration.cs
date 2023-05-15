using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities
{
    public  class EventIteration
    {
        public int Id { get; private set; }

        public DateTime StartDateTime { get; private set; }
        public DateTime EndDateTime { get; private set; }

        public ICollection<Ticket> _tickets;

        public Venu Venu { get; private set; }
        //not presisted 
        public bool Started => DateTime.Now > StartDateTime;


        public EventIteration(DateTime start, DateTime end, Venu venu ,ICollection<Ticket> tickets)
        {
            StartDateTime = start;
            EndDateTime = end;
            Venu = venu;
            _tickets = tickets;
        }
        public void Book(Ticket ticket)
        {
            if (_tickets.Contains(ticket))
                _tickets.Remove(ticket);
            else
                throw new InvalidOperationException("Ticket is no longer available");         
        }

        private EventIteration() {}
     
    }
}
