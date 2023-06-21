using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IbookingService
    {
        public Task Book(int eventInstanceId, ICollection<int> seatIds);
        public Task Book(int eventInstanceID, string ticketType , uint quantity);


    }
}
