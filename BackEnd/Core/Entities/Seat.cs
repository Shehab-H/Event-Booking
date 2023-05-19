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
        public char Row { get;private set; }
        public int Number { get; private set; }

        public Seat(char row,int number)
        {
            Row = row;
            Number = number;
        }

        public bool Equals(Seat? other)
        {
            return (other != null && other.Row == Row && other.Number == Number);
        }

        public override int GetHashCode()
        {
            return Row.GetHashCode() ^ Number.GetHashCode();
        }

        public override string ToString()
        {
            return ($"Row : {Row} \nNumber : {Number}");
        }
    }
}
