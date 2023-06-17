using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities
{
    public class StandingReservation
    {
        public int ID { get; private set; }
        public Guid SerialNumber { get; private set; }

        public string TicketType { get; private set; }

        public uint Quantity { get; private set; }
        public StandingReservation(string ticketType, uint quantity)
        {
            SerialNumber=Guid.NewGuid();
            this.TicketType = ticketType;
            this.Quantity = quantity;
        }
        private StandingReservation() {}
    }
}
