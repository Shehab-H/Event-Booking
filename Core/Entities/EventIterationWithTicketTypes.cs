using Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities
{
    public class EventIterationWithTicketTypes : EventIteration
    {
        private IDictionary<string, int> _tickets;
        public IReadOnlyDictionary<string, int> Tickets => new ReadOnlyDictionary<string,int>(_tickets);
        public EventIterationWithTicketTypes(DateTime start, DateTime end) : base(start, end)
        {
        }
        public override bool IsSoldOut()
        {
            if (_tickets.Values.Sum() > 0)
                return false;
            return true;
        }
        public bool IsSoldOut(string ticketType)
        {
            if (_tickets[ticketType] == 0)
                return true;
            else return false;
        }

        public void Book(string  ticketType)
        {
            if (!_tickets.ContainsKey(ticketType))
            {
                throw new InvalidOperationException($"there is no such ticket type as {ticketType}");
            }
            if (IsSoldOut(ticketType))
            {
                throw new InvalidOperationException("Tickets are sold out");
            }
            _tickets[ticketType] -= 1;
        }

        public void AddTicketType(string ticketType,int number)
        {
            _tickets.Add(ticketType, number);
        }

    }
}
