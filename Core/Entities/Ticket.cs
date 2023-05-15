using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace Core.Entities
{
    public abstract class Ticket :IEquatable<Ticket>
    {
        public Guid Id {get;private set;}
        public int Price { get;private set;}
        public Ticket(int Price)
        {
            Id = Guid.NewGuid();
        }
        public abstract bool Equals(Ticket? other);

        public override string ToString()
        {
            return base.ToString();
        }

    }
}
