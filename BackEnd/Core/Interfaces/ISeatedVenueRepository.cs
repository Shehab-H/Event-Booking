using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interfaces
{
    public  interface ISeatedVenueRepository
    {
        public Task<VenueWithSeats> Get(int venueId);
        public Task<int> SaveChangesAsync();
    }
}
