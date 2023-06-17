using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities
{
    public sealed class Seat
    {
        public int Id { get; private set; }
        public char Row { get;private set; }
        public int Number { get; private set; }

        public Seat(char row,int number)
        {
            Row = row;
            Number = number;
        }
    }
}
