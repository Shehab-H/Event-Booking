using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities
{
    public class StandingReservation : Reservation
    {
        public string TicketType { get; private set; }

        public uint Quantity { get; private set; }
        public StandingReservation(string ticketType, uint quantity) : base()
        {
            this.TicketType = ticketType;
            this.Quantity = quantity;
        }
        private StandingReservation() {}
    }
}
