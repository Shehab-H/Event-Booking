using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities
{
    public class TicketWithType : Ticket
    {
  

        public string Type { get; private set; }
        public TicketWithType(int Price,string type) : base(Price)
        {
            Type = type;
        }
        public override bool Equals(Ticket? other)
        {
            if (!(other is TicketWithType))
            {
                return false;
            }
            TicketWithType ticket = (TicketWithType)other;
            return (ticket.Type==ticket.Type);
        }
        public override string ToString()
        {
            return (Type);
        }
    }
}
