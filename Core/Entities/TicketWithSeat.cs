using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities
{
    public class TicketWithSeat : Ticket 
    {
        public char Row { get; private set; }
        public string Number { get; private set; }
        public TicketWithSeat(int Price,char row,string number) : base(Price)
        {
            Row = row;
            Number = number;
        }

        public override bool Equals(Ticket? other)
        {
            if(!(other is TicketWithSeat))
            {
                return false;
            }
            TicketWithSeat ticket =(TicketWithSeat)other;
            return(ticket.Row == Row && ticket.Number == Number);
        }
    }
}
