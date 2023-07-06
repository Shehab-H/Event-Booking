using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities
{
    public sealed class Seat : IEquatable<Seat>
    {
        public int Id { get; private set; }
        public char Row { get;private set; }
        public int Number { get; private set; }

        public Seat(char row,int number)
        {
            Row = row;
            Number = number;
        }

        public bool Equals(Seat? other)
        {
            return Id == other?.Id && Row==other.Row && Number==other.Number;
        }
        public override int GetHashCode()
        {
            return Id.GetHashCode()^Row.GetHashCode()^Number.GetHashCode();
        }
    }
}
