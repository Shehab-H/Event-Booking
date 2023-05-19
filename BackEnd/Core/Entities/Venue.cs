using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities
{
    public class Venue
    {
        public int Id { get; private set; }
        public string Name { get; private set; }

        public Venue(string name)
        {
            Name = name;
        }
        protected Venue(){}
    }
}
