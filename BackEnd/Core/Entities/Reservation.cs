﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities
{
    public abstract class Reservation
    {
        public int Id { get; set; }
        public Guid SerialNumber { get; private set; }

        public DateTime DateCreated { get;private set; }
        public Reservation()
        {
            DateCreated=DateTime.Now;
            SerialNumber = Guid.NewGuid();
        }
     
    }
}
