using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities
{
    public class Seat
    {
        public string Row { get; private set; }

        public string Number { get; private set; }

        public Seat(string row, string number)
        {
            Row = row;
            Number = number;
        }
        private Seat(){ }

        public bool Matches(Seat seat)
        {
            if (this.Row == seat.Row && this.Number == Number)
                return true;

            else return false;
        }
    }
}
