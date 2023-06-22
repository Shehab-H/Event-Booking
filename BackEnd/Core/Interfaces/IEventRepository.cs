using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interfaces
{
    public interface IEventRepository
    {
        public SeatedEventInstance GetSeatedInstance(int id);
        public StandingEventInstance GetStandingInstance(int id);

        public ICollection<Seat> GetSeats(ICollection<int> seatIds);

        public void SaveChanges();
    }
}
