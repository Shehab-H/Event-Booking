using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities
{
    public class Venu
    {
        public int Id { get; private set; }
        public string Name { get; private set; }

        public Venu(string name)
        {
            Name = name;
        }
        private Venu(){}
    }
}
